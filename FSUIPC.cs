using FSUIPC;
using System;

namespace portableSimPanelsFsuipcServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static Offset<string> TITLE = new Offset<string>(0x3D00, 256);
        public static Offset<string> ATC_IDENTIFIER = new Offset<string>(0x313C, 12);
        public static Offset<uint> INDICATED_ALTITUDE = new Offset<uint>(0x3324);
        public static Offset<uint> AIRSPEED_INDICATED = new Offset<uint>(0x02BC);
        public static Offset<uint> AVIONICS_MASTER = new Offset<uint>(0x2E80);
        public static Offset<uint> PLANE_HEADING_DEGREES_MAGNETIC = new Offset<uint>(0x580);
        public static Offset<uint> PLANE_BANK_DEGREES = new Offset<uint>(0x57C);
        public static Offset<uint> PLANE_PITCH_DEGREES = new Offset<uint>(0x578);
        public static Offset<int> VERTICAL_SPEED = new Offset<int>(0x2C8);
        public static Offset<sbyte> TURN_COORDINATOR_BALL = new Offset<sbyte>(0x36E);
        public static Offset<float> ENG_1_TORQUE = new Offset<float>(0x920);
        public static Offset<float> ENG_2_TORQUE = new Offset<float>(0x9B8);
        public static Offset<float> ENG_3_TORQUE = new Offset<float>(0xA50);
        public static Offset<float> ENG_4_TORQUE = new Offset<float>(0xAE8);
        public static Offset<double> TURB_ENG_1_ITT = new Offset<double>(0x2038);
        public static Offset<double> TURB_ENG_2_ITT = new Offset<double>(0x2138);
        public static Offset<double> TURB_ENG_3_ITT = new Offset<double>(0x2238);
        public static Offset<double> TURB_ENG_4_ITT = new Offset<double>(0x2338);
        public static Offset<uint> GEAR_HANDLE_POSITION = new Offset<uint>(0x0BE8);
        public static Offset<uint> GEAR_LEFT_POSITION = new Offset<uint>(0x0BF4);
        public static Offset<uint> GEAR_CENTER_POSITION = new Offset<uint>(0x0BEC);
        public static Offset<uint> GEAR_RIGHT_POSITION = new Offset<uint>(0xBF0);
        public static Offset<uint> AUTOPILOT_AVAILABLE = new Offset<uint>(0x764);
        public static Offset<uint> AUTOPILOT_MASTER = new Offset<uint>(0x7BC);
        public static Offset<uint> AUTOPILOT_HEADING_LOCK = new Offset<uint>(0x7C8);
        public static Offset<uint> AUTOPILOT_HEADING_LOCK_DIR = new Offset<uint>(0x7CC);
        public static Offset<uint> AUTOPILOT_NAV1_LOCK = new Offset<uint>(0x7C4);
        public static Offset<uint> AUTOPILOT_APR_LOCK = new Offset<uint>(0x800);
        public static Offset<uint> AUTOPILOT_GS_LOCK = new Offset<uint>(0x7FC);
        public static Offset<uint> AUTOPILOT_FD_LOCK = new Offset<uint>(0x2EE0);
        public static Offset<uint> AUTOPILOT_BACKCOURSE_LOCK = new Offset<uint>(0x804);
        public static Offset<uint> AUTOPILOT_YAW_DAMPER = new Offset<uint>(0x808);
        public static Offset<uint> AUTOPILOT_ATTITUDE_LOCK = new Offset<uint>(0x7D8);
        public static Offset<uint> AUTOPILOT_ALTITUDE_LOCK = new Offset<uint>(0x7D0);
        public static Offset<uint> AUTOPILOT_ALTITUDE_LOCK_VAR = new Offset<uint>(0x7D4);
        public static Offset<uint> AUTOPILOT_AIRSPEED_LOCK = new Offset<uint>(0x7D0);
        public static Offset<uint> AUTOPILOT_AIRSPEED_LOCK_KNOTS = new Offset<uint>(0x7E2);
        public static Offset<uint> AUTOPILOT_VERTICALSPEED_LOCK = new Offset<uint>(0x7EC);
        public static Offset<uint> AUTOPILOT_VERTICALSPEED_LOCK_KNOTS = new Offset<uint>(0x7F2);
        public static Offset<uint> AUTOPILOT_APPROACH_HOLD = new Offset<uint>(0x800);
        public static Offset<uint> AUTOTHROTTLE_ARM = new Offset<uint>(0x810);
        public static Offset<uint> COM_1_FREQUENCY = new Offset<uint>(0x5C4);
        public static Offset<uint> COM_1_STDBYFREQUENCY = new Offset<uint>(0x5CC);
        public static Offset<uint> COM_2_FREQUENCY = new Offset<uint>(0x5C8);
        public static Offset<uint> COM_2_STDBYFREQUENCY = new Offset<uint>(0x5D0);
        public static Offset<short> DME_SWITCH = new Offset<short>(0x378);
        public static Offset<ushort> NAV_1_FREQUENCY = new Offset<ushort>(0x350);
        public static Offset<short> NAV_1_OBS = new Offset<short>(0xC4E);
        public static Offset<float> NAV_1_CDI = new Offset<float>(0x2AA);
        public static Offset<float> NAV_1_GSI = new Offset<float>(0x2AB0);
        public static Offset<short> NAV_1_DME_DISTANCE = new Offset<short>(0x300);
        public static Offset<short> NAV_1_DME_SPEED = new Offset<short>(0x302);
        public static Offset<short> NAV_1_DME_TIMETO = new Offset<short>(0x304);
        public static Offset<byte> NAV_1_TOFROM = new Offset<byte>(0xC4B);
        public static Offset<byte> HSI_TOFROM = new Offset<byte>(0x2FAD);
        public static Offset<byte> NAV_1_GS_ALIVE = new Offset<byte>(0xC4C);
        public static Offset<Int32> NAV_1_SIGNAL_STRENGTH = new Offset<Int32>(0xC52);
        public static Offset<short> NAV_1_RADIAL = new Offset<short>(0xC50);
        public static Offset<short> NAV_2_OBS = new Offset<short>(0xC5E);
        public static Offset<float> NAV_2_CDI = new Offset<float>(0x2AB4);
        public static Offset<float> NAV_2_GSI = new Offset<float>(0x2AB8);
        public static Offset<short> NAV_2_DME_DISTANCE = new Offset<short>(0x306);
        public static Offset<short> NAV_2_DME_SPEED = new Offset<short>(0x308);
        public static Offset<short> NAV_2_DME_TIMETO = new Offset<short>(0x30A);
        public static Offset<short> ELEVATOR_TRIM_POSITION = new Offset<short>(0xBC2);
        public static Offset<int> TRAILING_EDGE_FLAPS_LEFT_PERCENT = new Offset<int>(0xBE0);
        public static Offset<int> TRAILING_EDGE_FLAPS_RIGHT_PERCENT = new Offset<int>(0xBE4);
        public static Offset<ushort> GENERAL_ENG_1_OIL_PRESSURE = new Offset<ushort>(0x8BA);
        public static Offset<ushort> GENERAL_ENG_2_OIL_PRESSURE = new Offset<ushort>(0x952);
        public static Offset<ushort> GENERAL_ENG_3_OIL_PRESSURE = new Offset<ushort>(0x9EA);
        public static Offset<ushort> GENERAL_ENG_4_OIL_PRESSURE = new Offset<ushort>(0xA82);
        public static Offset<short> GENERAL_ENG_1_OIL_TEMPERATURE = new Offset<short>(0x8B8);
        public static Offset<short> GENERAL_ENG_2_OIL_TEMPERATURE = new Offset<short>(0x950);
        public static Offset<short> GENERAL_ENG_3_OIL_TEMPERATURE = new Offset<short>(0x9E8);
        public static Offset<short> GENERAL_ENG_4_OIL_TEMPERATURE = new Offset<short>(0xA80);
        public static Offset<ushort> ENG_1_MANIFOLD_PRESSURE = new Offset<ushort>(0x8C0);
        public static Offset<ushort> ENG_2_MANIFOLD_PRESSURE = new Offset<ushort>(0x958);
        public static Offset<ushort> ENG_3_MANIFOLD_PRESSURE = new Offset<ushort>(0x9F0);
        public static Offset<ushort> ENG_4_MANIFOLD_PRESSURE = new Offset<ushort>(0xA88);
        public static Offset<double> PROP_1_RPM = new Offset<double>(0x2400);
        public static Offset<double> PROP_2_RPM = new Offset<double>(0x2500);
        public static Offset<double> PROP_3_RPM = new Offset<double>(0x2600);
        public static Offset<double> PROP_4_RPM = new Offset<double>(0x2700);
        public static Offset<short> LIGHTS = new Offset<short>(0xD0C);
    }
}
