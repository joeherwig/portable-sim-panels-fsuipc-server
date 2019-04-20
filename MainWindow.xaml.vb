Imports FSUIPC
Imports DeltaObjectGenerator
Imports Newtonsoft.Json
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Threading

''' <summary>
''' Interaction logic for MainWindow.xaml
''' </summary>
Partial Public Class MainWindow
    Inherits Window
    ' Set up a main timer
    Private timerMain As New DispatcherTimer()
    ' And another to look for a connection
    Private timerConnection As New DispatcherTimer()

    ' =====================================
    ' DECLARE OFFSETS YOU WANT TO USE HERE
    ' =====================================
    Public Class FSUIPC

        'Public airspeed As New Offset(Of UInteger)(&H2BC)
        'Public altitude As New Offset(Of UInteger)(&H3324)
        'Public heading As New Offset(Of UInteger)(&H580)
        Public avionicsMaster As New Offset(Of UInteger)(&H2E80)

        Public Function Clone()
            Return (Me.MemberwiseClone())
        End Function

        Public Function getDeltaObjects(ByVal newObject)
            Return Me.getDeltaObjects(newObject)
        End Function

    End Class

    Public values As New fsuipc()

    Public Sub New()
        InitializeComponent()
        ConfigureForm()
        timerMain.Interval = TimeSpan.FromMilliseconds(50)
        AddHandler timerMain.Tick, AddressOf timerMain_Tick
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

            Dim previousValues As New FSUIPC()
            previousValues = values.Clone

            FSUIPCConnection.Process()

            ' Update the information on the form
            ' (See the Examples Application for more information on using Offsets).

            ' 1. Airspeed
            'Dim airspeedKnots As Double = CDbl(Me.values.airspeed.Value) / 128.0
            'Me.txtAirspeed.Text = airspeedKnots.ToString("F0")

            ' 2. Master Avionics
            Me.chkAvionicsMaster.IsChecked = values.avionicsMaster.Value > 0

            Me.txtPrevious.Text = JsonConvert.SerializeObject(previousValues, Formatting.Indented)
            Me.txtJson.Text = JsonConvert.SerializeObject(Me.values, Formatting.Indented)

            'Dim deltaObjects = previousValues.getDeltaObjects(Me.values)


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
