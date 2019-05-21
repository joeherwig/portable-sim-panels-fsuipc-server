Imports NCalc
Imports System.Reflection
Imports System.Windows.Threading
Imports FSUIPC
Imports Newtonsoft.Json
Imports WebSocketSharp
Imports WebSocketSharp.Server

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
    Dim config As New Object
    Dim wssv = New WebSocketServer(8080)
    Dim ws = New WebSocket("ws://localhost:8080/fsuipc")

    Public Class wss
        Inherits WebSocketBehavior

        Protected Overrides Sub OnMessage(ByVal e As MessageEventArgs)
            Dim msg = If(e.Data Is "BALUS", "I've been balused already...", "I'm not available now.")
            Send(msg)
            'Send(e.Data)
            Sessions.Broadcast(e.Data)
        End Sub
    End Class

    Private Function wssStart(ByVal args As String)
        wssv.AddWebSocketService(Of wss)("/fsuipc")
        wssv.Start()
        Return wssv
    End Function

    Private Function getConfig()
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
        wssStart("")
        ConfigureForm()
        config = getConfig()
        lblWebsocketConfig.Text = "running on: " & config.selectToken("websocket").selectToken("url").ToString() & ":" & config.selectToken("websocket").selectToken("port").ToString()
        If config.selectToken("websocket").selectToken("url") = "localhost" Then
        End If
        timerMain.Interval = TimeSpan.FromMilliseconds(35)
        AddHandler timerMain.Tick, AddressOf TimerMain_Tick
        timerConnection.Interval = TimeSpan.FromMilliseconds(1000)
        AddHandler timerConnection.Tick, AddressOf TimerConnection_Tick
        timerConnection.Start()
    End Sub

    Dim valueRecalculation As New Dictionary(Of String, String) From {
               {"airspeedKnots", " / 128"}
           }
    Public Function calculateValue(ByVal key, ByVal rawValue)
        Dim temp As Decimal = rawValue
        Dim returnValue As String = rawValue

        If valueRecalculation.ContainsKey(key) = True Then
            Dim calculation As String = rawValue.ToString() & valueRecalculation(key)
            Dim result As Expression = New Expression(calculation)
            temp = result.Evaluate()
            returnValue = temp.ToString("F1")
        End If

        Return returnValue
    End Function

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
                Dim currentValue As String = updateDeltaObject(myFields(i).Name, GetPropertyValue(myFields(i).GetValue(values), "Value"))
            Next i

            txtPrevious.Text = JsonConvert.SerializeObject(previousValues, Formatting.Indented)
            txtJson.Text = JsonConvert.SerializeObject(dictionary, Formatting.Indented)
            'wssv.Broadcast(JsonConvert.SerializeObject(dictionary, Formatting.None))
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
    End Sub
End Class
