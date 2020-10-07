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
        private void timerMain_Tick(object sender, EventArgs e)
        {
            try
            {
                FSUIPCConnection.Process();

                double airspeedKnots = (double)this.airspeed.Value / 128d;
                App.FsuipcObject.Data["AirspeedKnots"] = airspeedKnots.ToString();
                App.FsuipcObject.Data["VERTICAL_SPEED"] = this.VERTICAL_SPEED.Value.ToString();
                App.FsuipcObject.Data["INDICATED_ALTITUDE"] = this.INDICATED_ALTITUDE.Value.ToString();
                App.FsuipcObject.Data["PLANE_PITCH_DEGREES"] = this.PLANE_PITCH_DEGREES.Value.ToString();
                App.FsuipcObject.Data["GEAR_LEFT_POSITION"] = this.GEAR_LEFT_POSITION.Value.ToString();
                App.FsuipcObject.Data["GEAR_CENTER_POSITION"] = this.GEAR_CENTER_POSITION.Value.ToString();
                App.FsuipcObject.Data["GEAR_RIGHT_POSITION"] = this.GEAR_RIGHT_POSITION.Value.ToString();
                UpdateJsonTextField(JsonConvert.SerializeObject(App.FsuipcObject.Data, Formatting.Indented));
            }
            catch (Exception ex)
            {
                this.timerMain.Stop();
                MessageBox.Show("Communication with FSUIPC Failed\n\n" + ex.Message, "FSUIPC", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                configureForm();
            }
        }
    }
}
