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
            string result;
            try
            {
                FSUIPCConnection.Process();
                App.FsuipcObject["AIRSPEED_INDICATED"] = calc.calculateValue("AIRSPEED_INDICATED", this.AIRSPEED_INDICATED.Value.ToString(), out result);
                App.FsuipcObject["ATC_IDENTIFIER"] = calc.calculateValue("ATC_IDENTIFIER", this.ATC_IDENTIFIER.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_AIRSPEED_LOCK_KNOTS"] = calc.calculateValue("AUTOPILOT_AIRSPEED_LOCK_KNOTS", this.AUTOPILOT_AIRSPEED_LOCK_KNOTS.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_AIRSPEED_LOCK"] = calc.calculateValue("AUTOPILOT_AIRSPEED_LOCK", this.AUTOPILOT_AIRSPEED_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_ALTITUDE_LOCK_VAR"] = calc.calculateValue("AUTOPILOT_ALTITUDE_LOCK_VAR", this.AUTOPILOT_ALTITUDE_LOCK_VAR.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_ALTITUDE_LOCK"] = calc.calculateValue("AUTOPILOT_ALTITUDE_LOCK", this.AUTOPILOT_ALTITUDE_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_APPROACH_HOLD"] = calc.calculateValue("AUTOPILOT_APPROACH_HOLD", this.AUTOPILOT_APPROACH_HOLD.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_APR_LOCK"] = calc.calculateValue("AUTOPILOT_APR_LOCK", this.AUTOPILOT_APR_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_ATTITUDE_LOCK"] = calc.calculateValue("AUTOPILOT_ATTITUDE_LOCK", this.AUTOPILOT_ATTITUDE_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_AVAILABLE"] = calc.calculateValue("AUTOPILOT_AVAILABLE", this.AUTOPILOT_AVAILABLE.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_BACKCOURSE_LOCK"] = calc.calculateValue("AUTOPILOT_BACKCOURSE_LOCK", this.AUTOPILOT_BACKCOURSE_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_FD_LOCK"] = calc.calculateValue("AUTOPILOT_FD_LOCK", this.AUTOPILOT_FD_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_GS_LOCK"] = calc.calculateValue("AUTOPILOT_GS_LOCK", this.AUTOPILOT_GS_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_HEADING_LOCK_DIR"] = calc.calculateValue("AUTOPILOT_HEADING_LOCK_DIR", this.AUTOPILOT_HEADING_LOCK_DIR.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_HEADING_LOCK"] = calc.calculateValue("AUTOPILOT_HEADING_LOCK", this.AUTOPILOT_HEADING_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_MASTER"] = calc.calculateValue("AUTOPILOT_MASTER", this.AUTOPILOT_MASTER.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_NAV1_LOCK"] = calc.calculateValue("AUTOPILOT_NAV1_LOCK", this.AUTOPILOT_NAV1_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_VERTICALSPEED_LOCK_KNOTS"] = calc.calculateValue("AUTOPILOT_VERTICALSPEED_LOCK_KNOTS", this.AUTOPILOT_VERTICALSPEED_LOCK_KNOTS.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_VERTICALSPEED_LOCK"] = calc.calculateValue("AUTOPILOT_VERTICALSPEED_LOCK", this.AUTOPILOT_VERTICALSPEED_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_YAW_DAMPER"] = calc.calculateValue("AUTOPILOT_YAW_DAMPER", this.AUTOPILOT_YAW_DAMPER.Value.ToString(), out result);
                App.FsuipcObject["AUTOTHROTTLE_ARM"] = calc.calculateValue("AUTOTHROTTLE_ARM", this.AUTOTHROTTLE_ARM.Value.ToString(), out result);
                App.FsuipcObject["AVIONICS_MASTER"] = calc.calculateValue("AVIONICS_MASTER", this.avionicsMaster.Value.ToString(), out result);
                App.FsuipcObject["DME_SWITCH"] = calc.calculateValue("DME_SWITCH", this.DME_SWITCH.Value.ToString(), out result);
                App.FsuipcObject["ELEVATOR_TRIM_POSITION"] = calc.calculateValue("ELEVATOR_TRIM_POSITION", this.ELEVATOR_TRIM_POSITION.Value.ToString(), out result);
                App.FsuipcObject["ENG_1_MANIFOLD_PRESSURE"] = calc.calculateValue("ENG_1_MANIFOLD_PRESSURE", this.ENG_1_MANIFOLD_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["ENG_1_TORQUE"] = calc.calculateValue("ENG_1_TORQUE", this.ENG_1_TORQUE.Value.ToString(), out result);
                App.FsuipcObject["ENG_2_MANIFOLD_PRESSURE"] = calc.calculateValue("ENG_2_MANIFOLD_PRESSURE", this.ENG_2_MANIFOLD_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["ENG_2_TORQUE"] = calc.calculateValue("ENG_2_TORQUE", this.ENG_2_TORQUE.Value.ToString(), out result);
                App.FsuipcObject["ENG_3_MANIFOLD_PRESSURE"] = calc.calculateValue("ENG_3_MANIFOLD_PRESSURE", this.ENG_3_MANIFOLD_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["ENG_3_TORQUE"] = calc.calculateValue("ENG_3_TORQUE", this.ENG_3_TORQUE.Value.ToString(), out result);
                App.FsuipcObject["ENG_4_MANIFOLD_PRESSURE"] = calc.calculateValue("ENG_4_MANIFOLD_PRESSURE", this.ENG_4_MANIFOLD_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["ENG_4_TORQUE"] = calc.calculateValue("ENG_4_TORQUE", this.ENG_4_TORQUE.Value.ToString(), out result);
                App.FsuipcObject["GEAR_CENTER_POSITION"] = calc.calculateValue("GEAR_CENTER_POSITION", this.GEAR_CENTER_POSITION.Value.ToString(), out result);
                App.FsuipcObject["GEAR_LEFT_POSITION"] = calc.calculateValue("GEAR_LEFT_POSITION", this.GEAR_LEFT_POSITION.Value.ToString(), out result);
                App.FsuipcObject["GEAR_RIGHT_POSITION"] = calc.calculateValue("GEAR_RIGHT_POSITION", this.GEAR_RIGHT_POSITION.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_1_OIL_PRESSURE"] = calc.calculateValue("GENERAL_ENG_1_OIL_PRESSURE", this.GENERAL_ENG_1_OIL_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_1_OIL_TEMPERATURE"] = calc.calculateValue("GENERAL_ENG_1_OIL_TEMPERATURE", this.GENERAL_ENG_1_OIL_TEMPERATURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_2_OIL_PRESSURE"] = calc.calculateValue("GENERAL_ENG_2_OIL_PRESSURE", this.GENERAL_ENG_2_OIL_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_2_OIL_TEMPERATURE"] = calc.calculateValue("GENERAL_ENG_2_OIL_TEMPERATURE", this.GENERAL_ENG_2_OIL_TEMPERATURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_3_OIL_PRESSURE"] = calc.calculateValue("GENERAL_ENG_3_OIL_PRESSURE", this.GENERAL_ENG_3_OIL_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_3_OIL_TEMPERATURE"] = calc.calculateValue("GENERAL_ENG_3_OIL_TEMPERATURE", this.GENERAL_ENG_3_OIL_TEMPERATURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_4_OIL_PRESSURE"] = calc.calculateValue("GENERAL_ENG_4_OIL_PRESSURE", this.GENERAL_ENG_4_OIL_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_4_OIL_TEMPERATURE"] = calc.calculateValue("GENERAL_ENG_4_OIL_TEMPERATURE", this.GENERAL_ENG_4_OIL_TEMPERATURE.Value.ToString(), out result);
                App.FsuipcObject["HSI_TOFROM"] = calc.calculateValue("HSI_TOFROM", this.HSI_TOFROM.Value.ToString(), out result);
                App.FsuipcObject["INDICATED_ALTITUDE"] = calc.calculateValue("INDICATED_ALTITUDE", this.INDICATED_ALTITUDE.Value.ToString(), out result);
                App.FsuipcObject["LIGHTS"] = calc.calculateValue("LIGHTS", this.LIGHTS.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_CDI"] = calc.calculateValue("NAV_1_CDI", this.NAV_1_CDI.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_DME_DISTANCE"] = calc.calculateValue("NAV_1_DME_DISTANCE", this.NAV_1_DME_DISTANCE.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_DME_SPEED"] = calc.calculateValue("NAV_1_DME_SPEED", this.NAV_1_DME_SPEED.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_DME_TIMETO"] = calc.calculateValue("NAV_1_DME_TIMETO", this.NAV_1_DME_TIMETO.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_GS_ALIVE"] = calc.calculateValue("NAV_1_GS_ALIVE", this.NAV_1_GS_ALIVE.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_GSI"] = calc.calculateValue("NAV_1_GSI", this.NAV_1_GSI.Value.ToString(), out result);
                App.FsuipcObject["Nav_1_OBS"] = calc.calculateValue("Nav_1_OBS", this.Nav_1_OBS.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_RADIAL"] = calc.calculateValue("NAV_1_RADIAL", this.NAV_1_RADIAL.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_SIGNAL_STRENGTH"] = calc.calculateValue("NAV_1_SIGNAL_STRENGTH", this.NAV_1_SIGNAL_STRENGTH.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_TOFROM"] = calc.calculateValue("NAV_1_TOFROM", this.NAV_1_TOFROM.Value.ToString(), out result);
                App.FsuipcObject["NAV_2_CDI"] = calc.calculateValue("NAV_2_CDI", this.NAV_2_CDI.Value.ToString(), out result);
                App.FsuipcObject["NAV_2_DME_DISTANCE"] = calc.calculateValue("NAV_2_DME_DISTANCE", this.NAV_2_DME_DISTANCE.Value.ToString(), out result);
                App.FsuipcObject["NAV_2_DME_SPEED"] = calc.calculateValue("NAV_2_DME_SPEED", this.NAV_2_DME_SPEED.Value.ToString(), out result);
                App.FsuipcObject["NAV_2_DME_TIMETO"] = calc.calculateValue("NAV_2_DME_TIMETO", this.NAV_2_DME_TIMETO.Value.ToString(), out result);
                App.FsuipcObject["NAV_2_GSI"] = calc.calculateValue("NAV_2_GSI", this.NAV_2_GSI.Value.ToString(), out result);
                App.FsuipcObject["Nav_2_OBS"] = calc.calculateValue("Nav_2_OBS", this.Nav_2_OBS.Value.ToString(), out result);
                App.FsuipcObject["PLANE_BANK_DEGREES"] = calc.calculateValue("PLANE_BANK_DEGREES", this.PLANE_BANK_DEGREES.Value.ToString(), out result);
                App.FsuipcObject["PLANE_HEADING_DEGREES_MAGNETIC"] = calc.calculateValue("PLANE_HEADING_DEGREES_MAGNETIC", this.PLANE_HEADING_DEGREES_MAGNETIC.Value.ToString(), out result);
                App.FsuipcObject["PLANE_PITCH_DEGREES"] = calc.calculateValue("PLANE_PITCH_DEGREES", this.PLANE_PITCH_DEGREES.Value.ToString(), out result);
                App.FsuipcObject["PROP_1_RPM"] = calc.calculateValue("PROP_1_RPM", this.PROP_1_RPM.Value.ToString(), out result);
                App.FsuipcObject["PROP_2_RPM"] = calc.calculateValue("PROP_2_RPM", this.PROP_2_RPM.Value.ToString(), out result);
                App.FsuipcObject["PROP_3_RPM"] = calc.calculateValue("PROP_3_RPM", this.PROP_3_RPM.Value.ToString(), out result);
                App.FsuipcObject["PROP_4_RPM"] = calc.calculateValue("PROP_4_RPM", this.PROP_4_RPM.Value.ToString(), out result);
                App.FsuipcObject["TITLE"] = calc.calculateValue("TITLE", this.TITLE.Value.ToString(), out result);
                App.FsuipcObject["TRAILING_EDGE_FLAPS_LEFT_PERCENT"] = calc.calculateValue("TRAILING_EDGE_FLAPS_LEFT_PERCENT", this.TRAILING_EDGE_FLAPS_LEFT_PERCENT.Value.ToString(), out result);
                App.FsuipcObject["TRAILING_EDGE_FLAPS_RIGHT_PERCENT"] = calc.calculateValue("TRAILING_EDGE_FLAPS_RIGHT_PERCENT", this.TRAILING_EDGE_FLAPS_RIGHT_PERCENT.Value.ToString(), out result);
                App.FsuipcObject["TURB_ENG_1_ITT"] = calc.calculateValue("TURB_ENG_1_ITT", this.TURB_ENG_1_ITT.Value.ToString(), out result);
                App.FsuipcObject["TURB_ENG_2_ITT"] = calc.calculateValue("TURB_ENG_2_ITT", this.TURB_ENG_2_ITT.Value.ToString(), out result);
                App.FsuipcObject["TURB_ENG_3_ITT"] = calc.calculateValue("TURB_ENG_3_ITT", this.TURB_ENG_3_ITT.Value.ToString(), out result);
                App.FsuipcObject["TURB_ENG_4_ITT"] = calc.calculateValue("TURB_ENG_4_ITT", this.TURB_ENG_4_ITT.Value.ToString(), out result);
                App.FsuipcObject["TURN_COORDINATOR_BALL"] = calc.calculateValue("TURN_COORDINATOR_BALL", this.TURN_COORDINATOR_BALL.Value.ToString(), out result);
                App.FsuipcObject["VERTICAL_SPEED"] = calc.calculateValue("VERTICAL_SPEED", this.VERTICAL_SPEED.Value.ToString(), out result);

                if (App.Previous.Count() == 0) {
                    App.Previous = App.FsuipcObject.ToDictionary(entry => entry.Key, entry => entry.Value);
                }
                App.getDeltaObject(App.Previous, App.FsuipcObject);
                UpdateJsonTextField(JsonConvert.SerializeObject(App.DeltaObject, Formatting.Indented));
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
