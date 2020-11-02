using FSUIPC;
using System;

namespace portableSimPanelsFsuipcServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public Offset<string> TITLE = new Offset<string>(0x3D00, 256);
        public Offset<string> ATC_IDENTIFIER = new Offset<string>(0x313C, 12);
        public Offset<uint> INDICATED_ALTITUDE = new Offset<uint>(0x3324);
        public Offset<uint> AIRSPEED_INDICATED = new Offset<uint>(0x02BC);
        public static Offset<uint> avionicsMaster = new Offset<uint>(0x2E80);
        public Offset<uint> PLANE_HEADING_DEGREES_MAGNETIC = new Offset<uint>(0x580);
        public Offset<uint> PLANE_BANK_DEGREES = new Offset<uint>(0x57C);
        public Offset<uint> PLANE_PITCH_DEGREES = new Offset<uint>(0x578);
        public Offset<int> VERTICAL_SPEED = new Offset<int>(0x2C8);
        public Offset<sbyte> TURN_COORDINATOR_BALL = new Offset<sbyte>(0x36E);
        public Offset<float> ENG_1_TORQUE = new Offset<float>(0x920);
        public Offset<float> ENG_2_TORQUE = new Offset<float>(0x9B8);
        public Offset<float> ENG_3_TORQUE = new Offset<float>(0xA50);
        public Offset<float> ENG_4_TORQUE = new Offset<float>(0xAE8);
        public Offset<double> TURB_ENG_1_ITT = new Offset<double>(0x2038);
        public Offset<double> TURB_ENG_2_ITT = new Offset<double>(0x2138);
        public Offset<double> TURB_ENG_3_ITT = new Offset<double>(0x2238);
        public Offset<double> TURB_ENG_4_ITT = new Offset<double>(0x2338);
        public Offset<uint> GEAR_LEFT_POSITION = new Offset<uint>(0xBF4);
        public Offset<uint> GEAR_CENTER_POSITION = new Offset<uint>(0x0BEC);
        public Offset<uint> GEAR_RIGHT_POSITION = new Offset<uint>(0xBF0);
        public Offset<uint> AUTOPILOT_AVAILABLE = new Offset<uint>(0x764);
        public Offset<uint> AUTOPILOT_MASTER = new Offset<uint>(0x7BC);
        public Offset<uint> AUTOPILOT_HEADING_LOCK = new Offset<uint>(0x7C8);
        public Offset<uint> AUTOPILOT_HEADING_LOCK_DIR = new Offset<uint>(0x7CC);
        public Offset<uint> AUTOPILOT_NAV1_LOCK = new Offset<uint>(0x7C4);
        public Offset<uint> AUTOPILOT_APR_LOCK = new Offset<uint>(0x800);
        public Offset<uint> AUTOPILOT_GS_LOCK = new Offset<uint>(0x7FC);
        public Offset<uint> AUTOPILOT_FD_LOCK = new Offset<uint>(0x2EE0);
        public Offset<uint> AUTOPILOT_BACKCOURSE_LOCK = new Offset<uint>(0x804);
        public Offset<uint> AUTOPILOT_YAW_DAMPER = new Offset<uint>(0x808);
        public Offset<uint> AUTOPILOT_ATTITUDE_LOCK = new Offset<uint>(0x7D8);
        public Offset<uint> AUTOPILOT_ALTITUDE_LOCK = new Offset<uint>(0x7D0);
        public Offset<uint> AUTOPILOT_ALTITUDE_LOCK_VAR = new Offset<uint>(0x7D4);
        public Offset<uint> AUTOPILOT_AIRSPEED_LOCK = new Offset<uint>(0x7D0);
        public Offset<uint> AUTOPILOT_AIRSPEED_LOCK_KNOTS = new Offset<uint>(0x7E2);
        public Offset<uint> AUTOPILOT_VERTICALSPEED_LOCK = new Offset<uint>(0x7EC);
        public Offset<uint> AUTOPILOT_VERTICALSPEED_LOCK_KNOTS = new Offset<uint>(0x7F2);
        public Offset<uint> AUTOPILOT_APPROACH_HOLD = new Offset<uint>(0x800);
        public Offset<uint> AUTOTHROTTLE_ARM = new Offset<uint>(0x810);
        public Offset<ushort> DME_SWITCH = new Offset<ushort>(0x66C0);
        public Offset<short> Nav_1_OBS = new Offset<short>(0xC4E);
        public Offset<float> NAV_1_CDI = new Offset<float>(0x2AA);
        public Offset<float> NAV_1_GSI = new Offset<float>(0x2AB0);
        public Offset<short> NAV_1_DME_DISTANCE = new Offset<short>(0x300);
        public Offset<short> NAV_1_DME_SPEED = new Offset<short>(0x302);
        public Offset<short> NAV_1_DME_TIMETO = new Offset<short>(0x304);
        public Offset<byte> NAV_1_TOFROM = new Offset<byte>(0xC4B);
        public Offset<byte> HSI_TOFROM = new Offset<byte>(0x2FAD);
        public Offset<byte> NAV_1_GS_ALIVE = new Offset<byte>(0xC4C);
        public Offset<Int32> NAV_1_SIGNAL_STRENGTH = new Offset<Int32>(0xC52);
        public Offset<short> NAV_1_RADIAL = new Offset<short>(0xC50);
        public Offset<short> Nav_2_OBS = new Offset<short>(0xC5E);
        public Offset<float> NAV_2_CDI = new Offset<float>(0x2AB4);
        public Offset<float> NAV_2_GSI = new Offset<float>(0x2AB8);
        public Offset<short> NAV_2_DME_DISTANCE = new Offset<short>(0x306);
        public Offset<short> NAV_2_DME_SPEED = new Offset<short>(0x308);
        public Offset<short> NAV_2_DME_TIMETO = new Offset<short>(0x30A);
        public Offset<short> ELEVATOR_TRIM_POSITION = new Offset<short>(0xBC2);
        public Offset<int> TRAILING_EDGE_FLAPS_LEFT_PERCENT = new Offset<int>(0xBE0);
        public Offset<int> TRAILING_EDGE_FLAPS_RIGHT_PERCENT = new Offset<int>(0xBE4);
        public Offset<ushort> GENERAL_ENG_1_OIL_PRESSURE = new Offset<ushort>(0x8BA);
        public Offset<ushort> GENERAL_ENG_2_OIL_PRESSURE = new Offset<ushort>(0x952);
        public Offset<ushort> GENERAL_ENG_3_OIL_PRESSURE = new Offset<ushort>(0x9EA);
        public Offset<ushort> GENERAL_ENG_4_OIL_PRESSURE = new Offset<ushort>(0xA82);
        public Offset<short> GENERAL_ENG_1_OIL_TEMPERATURE = new Offset<short>(0x8B8);
        public Offset<short> GENERAL_ENG_2_OIL_TEMPERATURE = new Offset<short>(0x950);
        public Offset<short> GENERAL_ENG_3_OIL_TEMPERATURE = new Offset<short>(0x9E8);
        public Offset<short> GENERAL_ENG_4_OIL_TEMPERATURE = new Offset<short>(0xA80);
        public Offset<ushort> ENG_1_MANIFOLD_PRESSURE = new Offset<ushort>(0x8C0);
        public Offset<ushort> ENG_2_MANIFOLD_PRESSURE = new Offset<ushort>(0x958);
        public Offset<ushort> ENG_3_MANIFOLD_PRESSURE = new Offset<ushort>(0x9F0);
        public Offset<ushort> ENG_4_MANIFOLD_PRESSURE = new Offset<ushort>(0xA88);
        public Offset<double> PROP_1_RPM = new Offset<double>(0x2400);
        public Offset<double> PROP_2_RPM = new Offset<double>(0x2500);
        public Offset<double> PROP_3_RPM = new Offset<double>(0x2600);
        public Offset<double> PROP_4_RPM = new Offset<double>(0x2700);
        public Offset<short> LIGHTS = new Offset<short>(0xD0C);

    }

}
