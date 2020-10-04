using FSUIPC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace portableSimPanelsFsuipcServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Set up a main timer
        private DispatcherTimer timerMain = new DispatcherTimer();
        // And another to look for a connection
        private DispatcherTimer timerConnection = new DispatcherTimer();

        // =====================================
        // DECLARE OFFSETS YOU WANT TO USE HERE
        // =====================================
        private Offset<uint> airspeed = new Offset<uint>(0x02BC);

        public MainWindow()
        {
            InitializeComponent();
            configureForm();
            timerMain.Interval = TimeSpan.FromMilliseconds(25);
            timerMain.Tick += timerMain_Tick;
            timerConnection.Interval = TimeSpan.FromMilliseconds(1000);
            timerConnection.Tick += timerConnection_Tick;
            timerConnection.Start();
        }
        
        private void timerConnection_Tick(object sender, EventArgs e)
        {
            // Try to open the connection
            try
            {
                FSUIPCConnection.Open();
                // If there was no problem, stop this timer and start the main timer
                this.timerConnection.Stop();
                this.timerMain.Start();
                // Update the connection status
                configureForm();
            }
            catch
            {
                // No connection found. Don't need to do anything, just keep trying
            }
        }

        // This method runs 20 times per second (every 50ms). This is set in the form constructor above.
        private void timerMain_Tick(object sender, EventArgs e)
        {
            // Call process() to read/write data to/from FSUIPC
            // We do this in a Try/Catch block incase something goes wrong
            try
            {
                FSUIPCConnection.Process();

                // Update the information on the form
                // (See the Examples Application for more information on using Offsets).

                // 1. Airspeed
                double airspeedKnots = (double)this.airspeed.Value / 128d;
                App.FsuipcObject.Data["AirspeedKnots"] = airspeedKnots.ToString();
                App.FsuipcObject.Data["VS"] = this.VERTICAL_SPEED.Value.ToString();
                UpdateJsonTextField(JsonConvert.SerializeObject(App.FsuipcObject.Data, Formatting.Indented));
                //txtAirspeed.Text = airspeedKnots.ToString("F0");

                // 2. Master Avionics
                //this.chkAvionicsMaster.IsChecked = avionicsMaster.Value > 0;
            }
            catch (Exception ex)
            {
                // An error occured. Tell the user and stop this timer.
                this.timerMain.Stop();
                MessageBox.Show("Communication with FSUIPC Failed\n\n" + ex.Message, "FSUIPC", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                // Update the connection status
                configureForm();
            }
        }

        // This runs when the master avionics tick has been changed
        private void chkAvionicsMaster_Click(object sender, RoutedEventArgs e)
        {
            // Update the FSUIPC offset with the new value (1 = Checked/On, 0 = Unchecked/Off)
            //this.avionicsMaster.Value = (uint)(this.chkAvionicsMaster.IsChecked.Value ? 1 : 0);
        }

        // Configures the button and status label depending on if we're connected or not 
        private void configureForm()
        {
            if (FSUIPCConnection.IsOpen)
            {
                UpdateJsonTextField("Connected to " + FSUIPCConnection.FlightSimVersionConnected.ToString());
                //this.lblConnectionStatus.Foreground = Brushes.Green;
            }
            else
            {
                UpdateJsonTextField("Disconnected. Looking for Flight Simulator...");
                //this.lblConnectionStatus.Foreground = Brushes.Red;
            }
        }

        // Window closing so stop all the timers and close the connection
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.timerConnection.Stop();
            this.timerMain.Stop();
            FSUIPCConnection.Close();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            FSUIPCConnection.Close();
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
                App.Previous.Data = App.FsuipcObject.Data;
                App.FsuipcObject.Data["Ground_Speed_" + App.FsuipcObject.Data.Count] = "123";
                App.FsuipcObject.Data["Ground_Speed"] = "123." + App.FsuipcObject.Data.Count;

                if (JsonFilterField.Text == "")
                {
                    UpdateJsonTextField(JsonConvert.SerializeObject(App.FsuipcObject.Data, Formatting.Indented));
                }
                else
                {
                    UpdateJsonTextField(JsonFilterField.Text);
                }

            }
        }

        private void MaximizeWindow(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


    }
}
