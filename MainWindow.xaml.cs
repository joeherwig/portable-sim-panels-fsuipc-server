using FSUIPC;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Input;
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

        public MainWindow()
        {
            InitializeComponent();
            configureForm();
            timerMain.Interval = TimeSpan.FromMilliseconds(25);
            timerMain.Tick += timerMain_Tick;
            timerConnection.Interval = TimeSpan.FromMilliseconds(1000);
            timerConnection.Tick += timerConnection_Tick;
            timerConnection.Start();

            var HtmlRootPath = @"..\portable-sim-panels";
            if (Directory.Exists(HtmlRootPath))
                Console.WriteLine("+++++++++++++++++ Folder exists on " + Dns.GetHostName());
            var url = "http://*:83/";

            httpSrv.CreateWebServer(url, HtmlRootPath)
                .RunAsync();

            if (true)
            {
                var browser = new System.Diagnostics.Process()
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo("http://" + Dns.GetHostName() + ":83/") { UseShellExecute = true }
                };
                browser.Start();
            }
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

                if (JsonFilterField.Text == "")
                {
                    UpdateJsonTextField(JsonConvert.SerializeObject(App.FsuipcObject, Formatting.Indented));
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
