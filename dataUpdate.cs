﻿using EmbedIO;
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
        private void timerMain_Tick(object sender, EventArgs e)
        {
            string result;
            try
            {
                FSUIPCConnection.Process();
                App.FsuipcObject["AIRSPEED_INDICATED"] = Calc.CalculateValue("AIRSPEED_INDICATED", this.AIRSPEED_INDICATED.Value.ToString(), out result);
                App.FsuipcObject["ATC_IDENTIFIER"] = Calc.CalculateValue("ATC_IDENTIFIER", this.ATC_IDENTIFIER.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_AIRSPEED_LOCK_KNOTS"] = Calc.CalculateValue("AUTOPILOT_AIRSPEED_LOCK_KNOTS", this.AUTOPILOT_AIRSPEED_LOCK_KNOTS.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_AIRSPEED_LOCK"] = Calc.CalculateValue("AUTOPILOT_AIRSPEED_LOCK", this.AUTOPILOT_AIRSPEED_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_ALTITUDE_LOCK_VAR"] = Calc.CalculateValue("AUTOPILOT_ALTITUDE_LOCK_VAR", this.AUTOPILOT_ALTITUDE_LOCK_VAR.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_ALTITUDE_LOCK"] = Calc.CalculateValue("AUTOPILOT_ALTITUDE_LOCK", this.AUTOPILOT_ALTITUDE_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_APPROACH_HOLD"] = Calc.CalculateValue("AUTOPILOT_APPROACH_HOLD", this.AUTOPILOT_APPROACH_HOLD.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_APR_LOCK"] = Calc.CalculateValue("AUTOPILOT_APR_LOCK", this.AUTOPILOT_APR_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_ATTITUDE_LOCK"] = Calc.CalculateValue("AUTOPILOT_ATTITUDE_LOCK", this.AUTOPILOT_ATTITUDE_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_AVAILABLE"] = Calc.CalculateValue("AUTOPILOT_AVAILABLE", this.AUTOPILOT_AVAILABLE.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_BACKCOURSE_LOCK"] = Calc.CalculateValue("AUTOPILOT_BACKCOURSE_LOCK", this.AUTOPILOT_BACKCOURSE_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_FD_LOCK"] = Calc.CalculateValue("AUTOPILOT_FD_LOCK", this.AUTOPILOT_FD_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_GS_LOCK"] = Calc.CalculateValue("AUTOPILOT_GS_LOCK", this.AUTOPILOT_GS_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_HEADING_LOCK_DIR"] = Calc.CalculateValue("AUTOPILOT_HEADING_LOCK_DIR", this.AUTOPILOT_HEADING_LOCK_DIR.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_HEADING_LOCK"] = Calc.CalculateValue("AUTOPILOT_HEADING_LOCK", this.AUTOPILOT_HEADING_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_MASTER"] = Calc.CalculateValue("AUTOPILOT_MASTER", this.AUTOPILOT_MASTER.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_NAV1_LOCK"] = Calc.CalculateValue("AUTOPILOT_NAV1_LOCK", this.AUTOPILOT_NAV1_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_VERTICALSPEED_LOCK_KNOTS"] = Calc.CalculateValue("AUTOPILOT_VERTICALSPEED_LOCK_KNOTS", this.AUTOPILOT_VERTICALSPEED_LOCK_KNOTS.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_VERTICALSPEED_LOCK"] = Calc.CalculateValue("AUTOPILOT_VERTICALSPEED_LOCK", this.AUTOPILOT_VERTICALSPEED_LOCK.Value.ToString(), out result);
                App.FsuipcObject["AUTOPILOT_YAW_DAMPER"] = Calc.CalculateValue("AUTOPILOT_YAW_DAMPER", this.AUTOPILOT_YAW_DAMPER.Value.ToString(), out result);
                App.FsuipcObject["AUTOTHROTTLE_ARM"] = Calc.CalculateValue("AUTOTHROTTLE_ARM", this.AUTOTHROTTLE_ARM.Value.ToString(), out result);
                App.FsuipcObject["AVIONICS_MASTER"] = Calc.CalculateValue("AVIONICS_MASTER", this.avionicsMaster.Value.ToString(), out result);
                App.FsuipcObject["DME_SWITCH"] = Calc.CalculateValue("DME_SWITCH", this.DME_SWITCH.Value.ToString(), out result);
                App.FsuipcObject["ELEVATOR_TRIM_POSITION"] = Calc.CalculateValue("ELEVATOR_TRIM_POSITION", this.ELEVATOR_TRIM_POSITION.Value.ToString(), out result);
                App.FsuipcObject["ENG_1_MANIFOLD_PRESSURE"] = Calc.CalculateValue("ENG_1_MANIFOLD_PRESSURE", this.ENG_1_MANIFOLD_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["ENG_1_TORQUE"] = Calc.CalculateValue("ENG_1_TORQUE", this.ENG_1_TORQUE.Value.ToString(), out result);
                App.FsuipcObject["ENG_2_MANIFOLD_PRESSURE"] = Calc.CalculateValue("ENG_2_MANIFOLD_PRESSURE", this.ENG_2_MANIFOLD_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["ENG_2_TORQUE"] = Calc.CalculateValue("ENG_2_TORQUE", this.ENG_2_TORQUE.Value.ToString(), out result);
                App.FsuipcObject["ENG_3_MANIFOLD_PRESSURE"] = Calc.CalculateValue("ENG_3_MANIFOLD_PRESSURE", this.ENG_3_MANIFOLD_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["ENG_3_TORQUE"] = Calc.CalculateValue("ENG_3_TORQUE", this.ENG_3_TORQUE.Value.ToString(), out result);
                App.FsuipcObject["ENG_4_MANIFOLD_PRESSURE"] = Calc.CalculateValue("ENG_4_MANIFOLD_PRESSURE", this.ENG_4_MANIFOLD_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["ENG_4_TORQUE"] = Calc.CalculateValue("ENG_4_TORQUE", this.ENG_4_TORQUE.Value.ToString(), out result);
                App.FsuipcObject["GEAR_CENTER_POSITION"] = Calc.CalculateValue("GEAR_CENTER_POSITION", this.GEAR_CENTER_POSITION.Value.ToString(), out result);
                App.FsuipcObject["GEAR_LEFT_POSITION"] = Calc.CalculateValue("GEAR_LEFT_POSITION", this.GEAR_LEFT_POSITION.Value.ToString(), out result);
                App.FsuipcObject["GEAR_RIGHT_POSITION"] = Calc.CalculateValue("GEAR_RIGHT_POSITION", this.GEAR_RIGHT_POSITION.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_1_OIL_PRESSURE"] = Calc.CalculateValue("GENERAL_ENG_1_OIL_PRESSURE", this.GENERAL_ENG_1_OIL_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_1_OIL_TEMPERATURE"] = Calc.CalculateValue("GENERAL_ENG_1_OIL_TEMPERATURE", this.GENERAL_ENG_1_OIL_TEMPERATURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_2_OIL_PRESSURE"] = Calc.CalculateValue("GENERAL_ENG_2_OIL_PRESSURE", this.GENERAL_ENG_2_OIL_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_2_OIL_TEMPERATURE"] = Calc.CalculateValue("GENERAL_ENG_2_OIL_TEMPERATURE", this.GENERAL_ENG_2_OIL_TEMPERATURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_3_OIL_PRESSURE"] = Calc.CalculateValue("GENERAL_ENG_3_OIL_PRESSURE", this.GENERAL_ENG_3_OIL_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_3_OIL_TEMPERATURE"] = Calc.CalculateValue("GENERAL_ENG_3_OIL_TEMPERATURE", this.GENERAL_ENG_3_OIL_TEMPERATURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_4_OIL_PRESSURE"] = Calc.CalculateValue("GENERAL_ENG_4_OIL_PRESSURE", this.GENERAL_ENG_4_OIL_PRESSURE.Value.ToString(), out result);
                App.FsuipcObject["GENERAL_ENG_4_OIL_TEMPERATURE"] = Calc.CalculateValue("GENERAL_ENG_4_OIL_TEMPERATURE", this.GENERAL_ENG_4_OIL_TEMPERATURE.Value.ToString(), out result);
                App.FsuipcObject["HSI_TOFROM"] = Calc.CalculateValue("HSI_TOFROM", this.HSI_TOFROM.Value.ToString(), out result);
                App.FsuipcObject["INDICATED_ALTITUDE"] = Calc.CalculateValue("INDICATED_ALTITUDE", this.INDICATED_ALTITUDE.Value.ToString(), out result);
                App.FsuipcObject["LIGHTS"] = Calc.CalculateValue("LIGHTS", this.LIGHTS.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_CDI"] = Calc.CalculateValue("NAV_1_CDI", this.NAV_1_CDI.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_DME_DISTANCE"] = Calc.CalculateValue("NAV_1_DME_DISTANCE", this.NAV_1_DME_DISTANCE.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_DME_SPEED"] = Calc.CalculateValue("NAV_1_DME_SPEED", this.NAV_1_DME_SPEED.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_DME_TIMETO"] = Calc.CalculateValue("NAV_1_DME_TIMETO", this.NAV_1_DME_TIMETO.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_GS_ALIVE"] = Calc.CalculateValue("NAV_1_GS_ALIVE", this.NAV_1_GS_ALIVE.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_GSI"] = Calc.CalculateValue("NAV_1_GSI", this.NAV_1_GSI.Value.ToString(), out result);
                App.FsuipcObject["Nav_1_OBS"] = Calc.CalculateValue("Nav_1_OBS", this.Nav_1_OBS.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_RADIAL"] = Calc.CalculateValue("NAV_1_RADIAL", this.NAV_1_RADIAL.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_SIGNAL_STRENGTH"] = Calc.CalculateValue("NAV_1_SIGNAL_STRENGTH", this.NAV_1_SIGNAL_STRENGTH.Value.ToString(), out result);
                App.FsuipcObject["NAV_1_TOFROM"] = Calc.CalculateValue("NAV_1_TOFROM", this.NAV_1_TOFROM.Value.ToString(), out result);
                App.FsuipcObject["NAV_2_CDI"] = Calc.CalculateValue("NAV_2_CDI", this.NAV_2_CDI.Value.ToString(), out result);
                App.FsuipcObject["NAV_2_DME_DISTANCE"] = Calc.CalculateValue("NAV_2_DME_DISTANCE", this.NAV_2_DME_DISTANCE.Value.ToString(), out result);
                App.FsuipcObject["NAV_2_DME_SPEED"] = Calc.CalculateValue("NAV_2_DME_SPEED", this.NAV_2_DME_SPEED.Value.ToString(), out result);
                App.FsuipcObject["NAV_2_DME_TIMETO"] = Calc.CalculateValue("NAV_2_DME_TIMETO", this.NAV_2_DME_TIMETO.Value.ToString(), out result);
                App.FsuipcObject["NAV_2_GSI"] = Calc.CalculateValue("NAV_2_GSI", this.NAV_2_GSI.Value.ToString(), out result);
                App.FsuipcObject["Nav_2_OBS"] = Calc.CalculateValue("Nav_2_OBS", this.Nav_2_OBS.Value.ToString(), out result);
                App.FsuipcObject["PLANE_BANK_DEGREES"] = Calc.CalculateValue("PLANE_BANK_DEGREES", this.PLANE_BANK_DEGREES.Value.ToString(), out result);
                App.FsuipcObject["PLANE_HEADING_DEGREES_MAGNETIC"] = Calc.CalculateValue("PLANE_HEADING_DEGREES_MAGNETIC", this.PLANE_HEADING_DEGREES_MAGNETIC.Value.ToString(), out result);
                App.FsuipcObject["PLANE_PITCH_DEGREES"] = Calc.CalculateValue("PLANE_PITCH_DEGREES", this.PLANE_PITCH_DEGREES.Value.ToString(), out result);
                App.FsuipcObject["PROP_1_RPM"] = Calc.CalculateValue("PROP_1_RPM", this.PROP_1_RPM.Value.ToString(), out result);
                App.FsuipcObject["PROP_2_RPM"] = Calc.CalculateValue("PROP_2_RPM", this.PROP_2_RPM.Value.ToString(), out result);
                App.FsuipcObject["PROP_3_RPM"] = Calc.CalculateValue("PROP_3_RPM", this.PROP_3_RPM.Value.ToString(), out result);
                App.FsuipcObject["PROP_4_RPM"] = Calc.CalculateValue("PROP_4_RPM", this.PROP_4_RPM.Value.ToString(), out result);
                App.FsuipcObject["TITLE"] = Calc.CalculateValue("TITLE", this.TITLE.Value.ToString(), out result);
                App.FsuipcObject["TRAILING_EDGE_FLAPS_LEFT_PERCENT"] = Calc.CalculateValue("TRAILING_EDGE_FLAPS_LEFT_PERCENT", this.TRAILING_EDGE_FLAPS_LEFT_PERCENT.Value.ToString(), out result);
                App.FsuipcObject["TRAILING_EDGE_FLAPS_RIGHT_PERCENT"] = Calc.CalculateValue("TRAILING_EDGE_FLAPS_RIGHT_PERCENT", this.TRAILING_EDGE_FLAPS_RIGHT_PERCENT.Value.ToString(), out result);
                App.FsuipcObject["TURB_ENG_1_ITT"] = Calc.CalculateValue("TURB_ENG_1_ITT", this.TURB_ENG_1_ITT.Value.ToString(), out result);
                App.FsuipcObject["TURB_ENG_2_ITT"] = Calc.CalculateValue("TURB_ENG_2_ITT", this.TURB_ENG_2_ITT.Value.ToString(), out result);
                App.FsuipcObject["TURB_ENG_3_ITT"] = Calc.CalculateValue("TURB_ENG_3_ITT", this.TURB_ENG_3_ITT.Value.ToString(), out result);
                App.FsuipcObject["TURB_ENG_4_ITT"] = Calc.CalculateValue("TURB_ENG_4_ITT", this.TURB_ENG_4_ITT.Value.ToString(), out result);
                App.FsuipcObject["TURN_COORDINATOR_BALL"] = Calc.CalculateValue("TURN_COORDINATOR_BALL", this.TURN_COORDINATOR_BALL.Value.ToString(), out result);
                App.FsuipcObject["VERTICAL_SPEED"] = Calc.CalculateValue("VERTICAL_SPEED", this.VERTICAL_SPEED.Value.ToString(), out result);

                if (App.Previous.Count() == 0)
                {
                    App.Previous = App.FsuipcObject.ToDictionary(entry => entry.Key, entry => entry.Value);
                }
                App.getDeltaObject(App.Previous, App.FsuipcObject);
                
                if (WindowState != WindowState.Minimized)
                {
                    if (JsonFilterField.Text == "")
                    {
                        UpdateJsonTextField(JsonConvert.SerializeObject(App.DeltaObject, Formatting.Indented));
                    }
                    else
                    {
                        if (App.Previous.ContainsKey(JsonFilterField.Text.ToUpper()))
                        {
                            UpdateJsonTextField(JsonConvert.SerializeObject(App.Previous[JsonFilterField.Text.ToUpper()], Formatting.Indented));
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
                this.timerMain.Stop();
                MessageBox.Show("Communication with FSUIPC Failed\n\n" + ex.Message, "FSUIPC", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                ConfigureForm();
            }
        }
    }
}
