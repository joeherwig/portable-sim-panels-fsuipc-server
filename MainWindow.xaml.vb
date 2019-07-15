Imports NCalc
Imports System.Globalization
Imports System.Reflection
Imports System.Windows.Threading
Imports System.Threading
Imports FSUIPC
Imports Newtonsoft.Json
Imports WebSocketSharp
Imports WebSocketSharp.Server
Imports Unosquare.Labs.EmbedIO
Imports Unosquare.Labs.EmbedIO.Modules

''' <summary>
''' Interaction logic for MainWindow.xaml
''' </summary>
Partial Public Class MainWindow
    Inherits Window
    ' Set up a main timer
    Private timerMain As New DispatcherTimer()
    ' And another to look for a connection
    Private timerConnection As New DispatcherTimer()
    Dim values As New FSUIPC()
    Dim previousValues As New Dictionary(Of String, String)
    Dim dictionary As New Dictionary(Of String, String)
    Public Property config As New Object
    Dim wssv As New WebSocketServer(8080)
    Dim ws As New WebSocketSharp.WebSocket("ws://localhost:8080/fsuipc")

    Public Class wss
        Inherits WebSocketBehavior
    End Class

    Private Function wssStart(ByVal args As String)
        Console.WriteLine(args)
        wssv.AddWebSocketService(Of wss)("/fsuipc")
        wssv.Start()
        Return wssv
    End Function

    Public Function getUpdate()
        Return JsonConvert.SerializeObject(dictionary, Formatting.None)
    End Function

    Public Function getConfig()
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("config.json", System.Text.Encoding.UTF8)
        config = JsonConvert.DeserializeObject(fileReader)
        Return config
    End Function

    Private Function GetPropertyValue(ByVal obj As Object, ByVal PropName As String) As Object
        Dim objType As Type = obj.GetType()
        Dim pInfo As System.Reflection.PropertyInfo = objType.GetProperty(PropName)
        Dim PropValue As Object = pInfo.GetValue(obj, Reflection.BindingFlags.GetProperty, Nothing, Nothing, Nothing)
        Return PropValue
    End Function

    Public Sub New()
        InitializeComponent()
        config = getConfig()
        Dim newCulture As CultureInfo = CultureInfo.CreateSpecificCulture("en-US")
        Thread.CurrentThread.CurrentUICulture = newCulture
        Thread.CurrentThread.CurrentCulture = newCulture
        Dim localWS As New LocalWebServer(config.selectToken("webserver").selectToken("port").ToString(), config.selectToken("webserver").selectToken("servingFromDirectory").ToString())
        localWS.StartWebServer()
        wssStart("")
        ConfigureForm()
        'lblWebsocketConfig.Text = "websocket running on: " & config.selectToken("websocket").selectToken("url").ToString() & ":" & config.selectToken("websocket").selectToken("port").ToString()
        lblWebsocketConfig.Text = "Gauges are served from " + config.selectToken("webserver").selectToken("servingFromDirectory").ToString() + " at "
        btnOpenUrl.Content = "Open Gauges from : " & System.Environment.MachineName.ToString() & ":" & config.selectToken("webserver").selectToken("port").ToString()
        If config.selectToken("websocket").selectToken("url") = "localhost" Then
        End If

        timerMain.Interval = TimeSpan.FromMilliseconds(25)
        AddHandler timerMain.Tick, AddressOf TimerMain_Tick
        timerConnection.Interval = TimeSpan.FromMilliseconds(1000)
        AddHandler timerConnection.Tick, AddressOf TimerConnection_Tick

        timerConnection.Start()
    End Sub


    Public Function updateDeltaObject(ByVal key, ByVal rawValue)
        Dim result = calculateValue(key, rawValue)
        If previousValues.ContainsKey(key) Then
            If previousValues.Item(key) = result Then
                dictionary.Remove(key)
            Else
                dictionary(key) = result
                previousValues(key) = result
            End If
        Else
            dictionary.Add(key, result)
            previousValues.Add(key, result)
        End If
        Return True
    End Function

    Public Sub TimerConnection_Tick(sender As Object, e As EventArgs)
        ' Try to open the connection
        Try
            FSUIPCConnection.Open()
            ' If there was no problem, stop this timer and start the main timer
            Me.timerConnection.[Stop]()
            Me.timerMain.Start()
            ' Update the connection status
            ConfigureForm()
            ' No connection found. Don't need to do anything, just keep trying
        Catch
        End Try
    End Sub

    Public Sub TimerMain_Tick(sender As Object, e As EventArgs)
        ' Call process() to read/write data to/from FSUIPC
        ' We do this in a Try/Catch block incase something goes wrong
        Try
            FSUIPCConnection.Process()

            Me.chkAvionicsMaster.IsChecked = values.avionicsMaster.Value > 0
            Dim myType As Type = values.GetType
            Dim myFields As FieldInfo() = myType.GetFields((BindingFlags.Public Or BindingFlags.Instance))
            Dim i As Integer

            For i = 0 To myFields.Length - 1
                'Dim currentValue As String = updateDeltaObject(myFields(i).Name, GetPropertyValue(myFields(i).GetValue(values), "Value"))
                updateDeltaObject(myFields(i).Name, GetPropertyValue(myFields(i).GetValue(values), "Value"))
            Next i

            'txtPrevious.Text = JsonConvert.SerializeObject(previousValues, Formatting.Indented)
            'txtJson.Text = JsonConvert.SerializeObject(dictionary, Formatting.Indented)
            If (JsonConvert.SerializeObject(dictionary, Formatting.None) <> "{}") Then
                wssv.WebSocketServices.Broadcast(JsonConvert.SerializeObject(dictionary, Formatting.None))
            End If
        Catch ex As Exception
            ' An error occured. Tell the user and stop this timer.
            Me.timerMain.[Stop]()
            MessageBox.Show("Communication with FSUIPC Failed" & vbLf & vbLf & ex.Message, "FSUIPC", MessageBoxButton.OK, MessageBoxImage.Exclamation)
            ' Update the connection status
            ConfigureForm()
        End Try
    End Sub

    ' This runs when the master avionics tick has been changed
    Private Sub ChkAvionicsMaster_Click(sender As Object, e As RoutedEventArgs)
        ' Update the FSUIPC offset with the new value (1 = Checked/On, 0 = Unchecked/Off)
        Me.values.avionicsMaster.Value = CUInt(If(Me.chkAvionicsMaster.IsChecked.Value, 1, 0))
    End Sub

    ' Configures the button and status label depending on if we're connected or not 
    Private Sub ConfigureForm()
        If FSUIPCConnection.IsOpen Then
            Me.lblConnectionStatus.Text = "Connected to " & FSUIPCConnection.FlightSimVersionConnected.ToString()
            Me.lblConnectionStatus.Foreground = Brushes.Green
        Else
            Me.lblConnectionStatus.Text = "Disconnected. Looking for Flight Simulator..."
            Me.lblConnectionStatus.Foreground = Brushes.Red
        End If
    End Sub

    ' Window is closing so stop all the timers and close the connection
    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Me.timerConnection.Stop()
        Me.timerMain.Stop()
        FSUIPCConnection.Close()
        End
    End Sub

    Private Sub btnOpenUrl_Click(sender As Object, e As RoutedEventArgs)
        Console.Write(":-)")
        Process.Start("http://" + System.Environment.MachineName.ToString() & ":" & config.selectToken("webserver").selectToken("port").ToString())
    End Sub
End Class


Public Class LocalWebServer
    Public Property Port As String
    Public Property ServingFromDirectory As String

    Public Sub New(
        ByVal Port As Int16,
        ByVal ServingFromDirectory As String)
        Me.Port = Port
        Me.ServingFromDirectory = ServingFromDirectory
        Console.Write(Me.ServingFromDirectory)
    End Sub

    Public Sub StartWebServer()
        Dim t As Thread = New Thread(New ThreadStart(AddressOf ThreadProc))
        t.Start()
    End Sub

    Public Sub ThreadProc()
        Using server = New WebServer("http://*:" + Port + "/")
            server.RegisterModule(New LocalSessionModule())
            server.RegisterModule(New StaticFilesModule(ServingFromDirectory))
            Console.Write("--- WebDirectory: -- " + ServingFromDirectory)
            server.[Module](Of StaticFilesModule)().ClearRamCache()
            server.[Module](Of StaticFilesModule)().UseRamCache = False
            server.[Module](Of StaticFilesModule)().DefaultExtension = ".html"
            server.[Module](Of StaticFilesModule)().DefaultDocument = "index.html"
            server.RunAsync()
            Thread.Sleep(Timeout.Infinite)
        End Using
    End Sub
End Class
