Imports System.Reflection
Imports System.Windows.Threading
Imports FSUIPC
Imports Newtonsoft.Json

''' <summary>
''' Interaction logic for MainWindow.xaml
''' </summary>
Partial Public Class MainWindow
    Inherits Window
    ' Set up a main timer
    Private timerMain As New DispatcherTimer()
    ' And another to look for a connection
    Private timerConnection As New DispatcherTimer()

    'Public  As New Dictionary(Of String, Offset)
    ' =====================================
    ' DECLARE OFFSETS YOU WANT TO USE HERE
    ' =====================================



    Public Class FSUIPC

        Public altitude As New Offset(Of UInteger)(&H3324)
        Public avionicsMaster As New Offset(Of UInteger)(&H2E80)
        Public lights As New Offset(Of UInteger)(&HD0C)

    End Class

    Public Class kept

        Public avionicsMaster As New Integer
        Public panelLights As New Integer

        Public Function getDeltaObjects(ByVal newObject)
            Return Me.getDeltaObjects(newObject)
        End Function
    End Class

    Dim values As New FSUIPC()
    Dim previousValues As New kept()

    Private Function GetPropertyValue(ByVal obj As Object, ByVal PropName As String) As Object
        Dim objType As Type = obj.GetType()
        Dim pInfo As System.Reflection.PropertyInfo = objType.GetProperty(PropName)
        Dim PropValue As Object = pInfo.GetValue(obj, Reflection.BindingFlags.GetProperty, Nothing, Nothing, Nothing)
        Return PropValue
    End Function

    Public Sub New()
        InitializeComponent()
        ConfigureForm()
        timerMain.Interval = TimeSpan.FromMilliseconds(50)
        AddHandler timerMain.Tick, AddressOf TimerMain_Tick
        timerConnection.Interval = TimeSpan.FromMilliseconds(1000)
        AddHandler timerConnection.Tick, AddressOf TimerConnection_Tick
        timerConnection.Start()
    End Sub

    Private Sub TimerConnection_Tick(sender As Object, e As EventArgs)
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

    ' This method runs 20 times per second (every 50ms). This is set in the form constructor above.
    Private Sub TimerMain_Tick(sender As Object, e As EventArgs)
        ' Call process() to read/write data to/from FSUIPC
        ' We do this in a Try/Catch block incase something goes wrong
        Try
            Dim latestValues As New kept()
            FSUIPCConnection.Process()
            ' 1. Airspeed
            'Dim airspeedKnots As Double = CDbl(Me.values.airspeed.Value) / 128.0
            'Me.txtAirspeed.Text = airspeedKnots.ToString("F0")

            ' 2. Master Avionics
            Me.chkAvionicsMaster.IsChecked = values.avionicsMaster.Value > 0

            Dim dictionary As New Dictionary(Of String, String)

            Dim myType As Type = values.GetType
            Dim myFields As FieldInfo() = myType.GetFields((BindingFlags.Public Or BindingFlags.Instance))
            Dim i As Integer
            For i = 0 To myFields.Length - 1
                dictionary.Add(myFields(i).Name, GetPropertyValue(myFields(i).GetValue(values), "Value")) ' working but only with explicitly declared parameter name
            Next i

            txtPrevious.Text = JsonConvert.SerializeObject(dictionary, Formatting.Indented)
            txtJson.Text = JsonConvert.SerializeObject(values, Formatting.Indented)

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
