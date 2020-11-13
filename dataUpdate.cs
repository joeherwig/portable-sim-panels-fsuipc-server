using EmbedIO;
using FSUIPC;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Windows;

namespace portableSimPanelsFsuipcServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void TimerMain_Tick(object sender, EventArgs e)
        {
            string result;
            try
            {
                FSUIPCConnection.Process();
                App.FsuipcObject["AIRSPEED_INDICATED"] = Calc.CalculateValue("AIRSPEED_INDICATED", AIRSPEED_INDICATED.Value.ToString(), out result);
                App.FsuipcObject["ATC_IDENTIFIER"] = Calc.CalculateValue("ATC_IDENTIFIER", ATC_IDENTIFIER.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_AIRSPEED_LOCK_KNOTS"] = Calc.CalculateValue("AUTOPILOT_AIRSPEED_LOCK_KNOTS", AUTOPILOT_AIRSPEED_LOCK_KNOTS.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_AIRSPEED_LOCK"] = Calc.CalculateValue("AUTOPILOT_AIRSPEED_LOCK", AUTOPILOT_AIRSPEED_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_ALTITUDE_LOCK_VAR"] = Calc.CalculateValue("AUTOPILOT_ALTITUDE_LOCK_VAR", AUTOPILOT_ALTITUDE_LOCK_VAR.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_ALTITUDE_LOCK"] = Calc.CalculateValue("AUTOPILOT_ALTITUDE_LOCK", AUTOPILOT_ALTITUDE_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_APPROACH_HOLD"] = Calc.CalculateValue("AUTOPILOT_APPROACH_HOLD", AUTOPILOT_APPROACH_HOLD.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_APR_LOCK"] = Calc.CalculateValue("AUTOPILOT_APR_LOCK", AUTOPILOT_APR_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_ATTITUDE_LOCK"] = Calc.CalculateValue("AUTOPILOT_ATTITUDE_LOCK", AUTOPILOT_ATTITUDE_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_AVAILABLE"] = Calc.CalculateValue("AUTOPILOT_AVAILABLE", AUTOPILOT_AVAILABLE.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_BACKCOURSE_LOCK"] = Calc.CalculateValue("AUTOPILOT_BACKCOURSE_LOCK", AUTOPILOT_BACKCOURSE_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_FD_LOCK"] = Calc.CalculateValue("AUTOPILOT_FD_LOCK", AUTOPILOT_FD_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_GS_LOCK"] = Calc.CalculateValue("AUTOPILOT_GS_LOCK", AUTOPILOT_GS_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_HEADING_LOCK_DIR"] = Calc.CalculateValue("AUTOPILOT_HEADING_LOCK_DIR", AUTOPILOT_HEADING_LOCK_DIR.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_HEADING_LOCK"] = Calc.CalculateValue("AUTOPILOT_HEADING_LOCK", AUTOPILOT_HEADING_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_MASTER"] = Calc.CalculateValue("AUTOPILOT_MASTER", AUTOPILOT_MASTER.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_NAV1_LOCK"] = Calc.CalculateValue("AUTOPILOT_NAV1_LOCK", AUTOPILOT_NAV1_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_VERTICALSPEED_LOCK_KNOTS"] = Calc.CalculateValue("AUTOPILOT_VERTICALSPEED_LOCK_KNOTS", AUTOPILOT_VERTICALSPEED_LOCK_KNOTS.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_VERTICALSPEED_LOCK"] = Calc.CalculateValue("AUTOPILOT_VERTICALSPEED_LOCK", AUTOPILOT_VERTICALSPEED_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_YAW_DAMPER"] = Calc.CalculateValue("AUTOPILOT_YAW_DAMPER", AUTOPILOT_YAW_DAMPER.Value.ToString(), out result);
                App.FsuipcObject["AUTOTHROTTLE_ARM"] = Calc.CalculateValue("AUTOTHROTTLE_ARM", AUTOTHROTTLE_ARM.Value.ToString(), out result);
                App.FsuipcObject["AVIONICS_MASTER"] = Calc.CalculateValue("AVIONICS_MASTER", MainWindow.AVIONICS_MASTER.Value.ToString(), out result);
                App.FsuipcObject["DME_SWITCH"] = Calc.CalculateValue("DME_SWITCH", DME_SWITCH.Value.ToString(), out result);
                App.FsuipcObject["ELEVATOR_TRIM_POSITION"] = Calc.CalculateValue("ELEVATOR_TRIM_POSITION", ELEVATOR_TRIM_POSITION.Value.ToString(), out result);
                App.FsuipcObject["ENG_1_MANIFOLD_PRESSURE"] = Calc.CalculateValue("ENG_1_MANIFOLD_PRESSURE", ENG_1_MANIFOLD_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["ENG_1_TORQUE"] = Calc.CalculateValue("ENG_1_TORQUE", ENG_1_TORQUE.Value.ToString(), out result);
                App.FsuipcObject["ENG_2_MANIFOLD_PRESSURE"] = Calc.CalculateValue("ENG_2_MANIFOLD_PRESSURE", ENG_2_MANIFOLD_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["ENG_2_TORQUE"] = Calc.CalculateValue("ENG_2_TORQUE", ENG_2_TORQUE.Value.ToString(), out result);
                App.FsuipcObject["ENG_3_MANIFOLD_PRESSURE"] = Calc.CalculateValue("ENG_3_MANIFOLD_PRESSURE", ENG_3_MANIFOLD_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["ENG_3_TORQUE"] = Calc.CalculateValue("ENG_3_TORQUE", ENG_3_TORQUE.Value.ToString(), out result);
                App.FsuipcObject["ENG_4_MANIFOLD_PRESSURE"] = Calc.CalculateValue("ENG_4_MANIFOLD_PRESSURE", ENG_4_MANIFOLD_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["ENG_4_TORQUE"] = Calc.CalculateValue("ENG_4_TORQUE", ENG_4_TORQUE.Value.ToString(), out result);
                App.FsuipcObject["GEAR_CENTER_POSITION"] = Calc.CalculateValue("GEAR_CENTER_POSITION", GEAR_CENTER_POSITION.Value.ToString(), out result);
                App.FsuipcObject["GEAR_LEFT_POSITION"] = Calc.CalculateValue("GEAR_LEFT_POSITION", GEAR_LEFT_POSITION.Value.ToString(), out result);
                App.FsuipcObject["GEAR_RIGHT_POSITION"] = Calc.CalculateValue("GEAR_RIGHT_POSITION", GEAR_RIGHT_POSITION.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_1_OIL_PRESSURE"] = Calc.CalculateValue("GENERAL_ENG_1_OIL_PRESSURE", GENERAL_ENG_1_OIL_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_1_OIL_TEMPERATURE"] = Calc.CalculateValue("GENERAL_ENG_1_OIL_TEMPERATURE", GENERAL_ENG_1_OIL_TEMPERATURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_2_OIL_PRESSURE"] = Calc.CalculateValue("GENERAL_ENG_2_OIL_PRESSURE", GENERAL_ENG_2_OIL_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_2_OIL_TEMPERATURE"] = Calc.CalculateValue("GENERAL_ENG_2_OIL_TEMPERATURE", GENERAL_ENG_2_OIL_TEMPERATURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_3_OIL_PRESSURE"] = Calc.CalculateValue("GENERAL_ENG_3_OIL_PRESSURE", GENERAL_ENG_3_OIL_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_3_OIL_TEMPERATURE"] = Calc.CalculateValue("GENERAL_ENG_3_OIL_TEMPERATURE", GENERAL_ENG_3_OIL_TEMPERATURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_4_OIL_PRESSURE"] = Calc.CalculateValue("GENERAL_ENG_4_OIL_PRESSURE", GENERAL_ENG_4_OIL_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_4_OIL_TEMPERATURE"] = Calc.CalculateValue("GENERAL_ENG_4_OIL_TEMPERATURE", GENERAL_ENG_4_OIL_TEMPERATURE.Value.ToString(), out result);
                App.FsuipcObject["HSI_TOFROM"] = Calc.CalculateValue("HSI_TOFROM", HSI_TOFROM.Value.ToString(), out result);
                App.FsuipcObject["INDICATED_ALTITUDE"] = Calc.CalculateValue("INDICATED_ALTITUDE", INDICATED_ALTITUDE.Value.ToString(), out result);
                App.FsuipcObject["LIGHTS"] = Calc.CalculateValue("LIGHTS", LIGHTS.Value.ToString(), out result);
                App.FsuipcObject["COM_1_FREQUENCY"] = Calc.To8kHzFrequency("COM_1_FREQUENCY", COM_1_FREQUENCY.Value, out result);
                App.FsuipcObject["COM_1_STDBYFREQUENCY"] = Calc.To8kHzFrequency("COM_1_STDBYFREQUENCY", COM_1_STDBYFREQUENCY.Value, out result);
                App.FsuipcObject["COM_2_FREQUENCY"] = Calc.To8kHzFrequency("COM_2_FREQUENCY", COM_2_FREQUENCY.Value, out result);
                App.FsuipcObject["COM_2_STDBYFREQUENCY"] = Calc.To8kHzFrequency("COM_2_STDBYFREQUENCY", COM_2_STDBYFREQUENCY.Value, out result);
                App.FsuipcObject["NAV_1_FREQUENCY"] = Calc.To25kHzFrequency("NAV_1_FREQUENCY", NAV_1_FREQUENCY.Value, out result);
                App.FsuipcObject["NAV_1_CDI"] = Calc.CalculateValue("NAV_1_CDI", NAV_1_CDI.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_DME_DISTANCE"] = Calc.CalculateValue("NAV_1_DME_DISTANCE", NAV_1_DME_DISTANCE.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_DME_SPEED"] = Calc.CalculateValue("NAV_1_DME_SPEED", NAV_1_DME_SPEED.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_DME_TIMETO"] = Calc.CalculateValue("NAV_1_DME_TIMETO", NAV_1_DME_TIMETO.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_GS_ALIVE"] = Calc.CalculateValue("NAV_1_GS_ALIVE", NAV_1_GS_ALIVE.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_GSI"] = Calc.CalculateValue("NAV_1_GSI", NAV_1_GSI.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_OBS"] = Calc.CalculateValue("NAV_1_OBS", NAV_1_OBS.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_RADIAL"] = Calc.CalculateValue("NAV_1_RADIAL", NAV_1_RADIAL.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_SIGNAL_STRENGTH"] = Calc.CalculateValue("NAV_1_SIGNAL_STRENGTH", NAV_1_SIGNAL_STRENGTH.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_TOFROM"] = Calc.CalculateValue("NAV_1_TOFROM", NAV_1_TOFROM.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_FREQUENCY"] = Calc.To25kHzFrequency("NAV_1_FREQUENCY", NAV_1_FREQUENCY.Value, out result);
                App.FsuipcObject["NAV_2_CDI"] = Calc.CalculateValue("NAV_2_CDI", NAV_2_CDI.Value.ToString(), out result);
                App.FsuipcObject["NAV_2_DME_DISTANCE"] = Calc.CalculateValue("NAV_2_DME_DISTANCE", NAV_2_DME_DISTANCE.Value.ToString(), out result);
                App.FsuipcObject["NAV_2_DME_SPEED"] = Calc.CalculateValue("NAV_2_DME_SPEED", NAV_2_DME_SPEED.Value.ToString(), out result);
                App.FsuipcObject["NAV_2_DME_TIMETO"] = Calc.CalculateValue("NAV_2_DME_TIMETO", NAV_2_DME_TIMETO.Value.ToString(), out result);
                App.FsuipcObject["NAV_2_GSI"] = Calc.CalculateValue("NAV_2_GSI", NAV_2_GSI.Value.ToString(), out result);
                App.FsuipcObject["NAV_2_OBS"] = Calc.CalculateValue("NAV_2_OBS", NAV_2_OBS.Value.ToString(), out result);
                App.FsuipcObject["PLANE_BANK_DEGREES"] = Calc.CalculateValue("PLANE_BANK_DEGREES", PLANE_BANK_DEGREES.Value.ToString(), out result);
                App.FsuipcObject["PLANE_HEADING_DEGREES_MAGNETIC"] = Calc.CalculateValue("PLANE_HEADING_DEGREES_MAGNETIC", PLANE_HEADING_DEGREES_MAGNETIC.Value.ToString(), out result);
                App.FsuipcObject["PLANE_PITCH_DEGREES"] = Calc.CalculateValue("PLANE_PITCH_DEGREES", PLANE_PITCH_DEGREES.Value.ToString(), out result);
                App.FsuipcObject["PROP_1_RPM"] = Calc.CalculateValue("PROP_1_RPM", PROP_1_RPM.Value.ToString(), out result);
                App.FsuipcObject["PROP_2_RPM"] = Calc.CalculateValue("PROP_2_RPM", PROP_2_RPM.Value.ToString(), out result);
                App.FsuipcObject["PROP_3_RPM"] = Calc.CalculateValue("PROP_3_RPM", PROP_3_RPM.Value.ToString(), out result);
                App.FsuipcObject["PROP_4_RPM"] = Calc.CalculateValue("PROP_4_RPM", PROP_4_RPM.Value.ToString(), out result);
                App.FsuipcObject["TITLE"] = Calc.CalculateValue("TITLE", TITLE.Value.ToString(), out result);
                App.FsuipcObject["TRAILING_EDGE_FLAPS_LEFT_PERCENT"] = Calc.CalculateValue("TRAILING_EDGE_FLAPS_LEFT_PERCENT", TRAILING_EDGE_FLAPS_LEFT_PERCENT.Value.ToString(), out result);
                App.FsuipcObject["TRAILING_EDGE_FLAPS_RIGHT_PERCENT"] = Calc.CalculateValue("TRAILING_EDGE_FLAPS_RIGHT_PERCENT", TRAILING_EDGE_FLAPS_RIGHT_PERCENT.Value.ToString(), out result);
                App.FsuipcObject["TURB_ENG_1_ITT"] = Calc.CalculateValue("TURB_ENG_1_ITT", TURB_ENG_1_ITT.Value.ToString(), out result);
                App.FsuipcObject["TURB_ENG_2_ITT"] = Calc.CalculateValue("TURB_ENG_2_ITT", TURB_ENG_2_ITT.Value.ToString(), out result);
                App.FsuipcObject["TURB_ENG_3_ITT"] = Calc.CalculateValue("TURB_ENG_3_ITT", TURB_ENG_3_ITT.Value.ToString(), out result);
                App.FsuipcObject["TURB_ENG_4_ITT"] = Calc.CalculateValue("TURB_ENG_4_ITT", TURB_ENG_4_ITT.Value.ToString(), out result);
                App.FsuipcObject["TURN_COORDINATOR_BALL"] = Calc.CalculateValue("TURN_COORDINATOR_BALL", TURN_COORDINATOR_BALL.Value.ToString(), out result);
                App.FsuipcObject["VERTICAL_SPEED"] = Calc.CalculateValue("VERTICAL_SPEED", VERTICAL_SPEED.Value.ToString(), out result);

                if (App.Previous.Count() == 0)
                {
                    App.Previous = App.FsuipcObject.ToDictionary(entry => entry.Key, entry => entry.Value);
                }

                // TODO make appropriate call to inform WebSocket clients
                webSocketServer.SendToOthersAsync(JsonConvert.SerializeObject(App.DeltaObject, Formatting.Indented));

                App.GetDeltaObject(App.Previous, App.FsuipcObject);

                if (WindowState != WindowState.Minimized && Tabs.SelectedIndex == 1)
                {
                    if (JsonFilterField.Text == "")
                    {
                        UpdateJsonTextField(JsonConvert.SerializeObject(App.DeltaObject, Formatting.Indented));
                    }
                    else
                    {
                        if (App.Previous.ContainsKey(JsonFilterField.Text.Replace(" ", "_").ToUpper()))
                        {
                            UpdateJsonTextField(JsonConvert.SerializeObject(App.Previous[JsonFilterField.Text.Replace(" ", "_").ToUpper()], Formatting.Indented));
                        }
                        else
                        {
                            UpdateJsonTextField(JsonConvert.SerializeObject(App.Previous, Formatting.Indented));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                timerMain.Stop();
                MessageBox.Show("Communication with FSUIPC Failed\n\n" + ex.Message, "FSUIPC", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                ConfigureForm();
            }
        }
    }
}
