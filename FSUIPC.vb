﻿Imports FSUIPC

Partial Public Class MainWindow

    Public Class FSUIPC
        Public TITLE As New Offset(Of String)(&H3D00, 256)
        Public ATC_IDENTIFYER As New Offset(Of String)(&H313C, 12)
        Public INDICATED_ALTITUDE As New Offset(Of UInteger)(&H3324)
        Public AIRSPEED_INDICATED As New Offset(Of UInteger)(&H2BC)
        Public avionicsMaster As New Offset(Of UInteger)(&H2E80)
        Public PLANE_HEADING_DEGREES_MAGNETIC As New Offset(Of UInteger)(&H580)
        Public PLANE_BANK_DEGREES As New Offset(Of UInteger)(&H57C)
        Public PLANE_PITCH_DEGREES As New Offset(Of UInteger)(&H578)
        Public VERTICAL_SPEED As New Offset(Of Integer)(&H2C8)
        Public TURN_COORDINATOR_BALL As New Offset(Of Double)(&H380)
        Public ENG_1_TORQUE As New Offset(Of Single)(&H920)
        Public ENG_2_TORQUE As New Offset(Of Single)(&H9B8)
        Public ENG_3_TORQUE As New Offset(Of Single)(&HA50)
        Public ENG_4_TORQUE As New Offset(Of Single)(&HAE8)
        Public TURB_ENG_1_ITT As New Offset(Of Double)(&H2038)
        Public TURB_ENG_2_ITT As New Offset(Of Double)(&H2138)
        Public TURB_ENG_3_ITT As New Offset(Of Double)(&H2238)
        Public TURB_ENG_4_ITT As New Offset(Of Double)(&H2338)
        Public GEAR_LEFT_POSITION As New Offset(Of UInteger)(&HBF4)
        Public GEAR_CENTER_POSITION As New Offset(Of UInteger)(&HBEC)
        Public GEAR_RIGHT_POSITION As New Offset(Of UInteger)(&HBF0)
        Public AUTOPILOT_AVAILABLE As New Offset(Of UInteger)(&H764)
        Public AUTOPILOT_MASTER As New Offset(Of UInteger)(&H7BC)
        Public AUTOPILOT_HEADING_LOCK As New Offset(Of UInteger)(&H7C8)
        Public AUTOPILOT_HEADING_LOCK_DIR As New Offset(Of UInteger)(&H7CC)
        Public AUTOPILOT_NAV1_LOCK As New Offset(Of UInteger)(&H7C4)
        Public AUTOPILOT_APR_LOCK As New Offset(Of UInteger)(&H800)
        Public AUTOPILOT_GS_LOCK As New Offset(Of UInteger)(&H7FC)
        Public AUTOPILOT_FD_LOCK As New Offset(Of UInteger)(&H2EE0)
        Public AUTOPILOT_BACKCOURSE_LOCK As New Offset(Of UInteger)(&H804)
        Public AUTOPILOT_YAW_DAMPER As New Offset(Of UInteger)(&H808)
        Public AUTOPILOT_ATTITUDE_LOCK As New Offset(Of UInteger)(&H7D8)
        Public AUTOPILOT_ALTITUDE_LOCK As New Offset(Of UInteger)(&H7D0)
        Public AUTOPILOT_ALTITUDE_LOCK_VAR As New Offset(Of UInteger)(&H7D4)
        Public AUTOPILOT_AIRSPEED_LOCK As New Offset(Of UInteger)(&H7D0)
        Public AUTOPILOT_AIRSPEED_LOCK_KNOTS As New Offset(Of UInteger)(&H7E2)
        Public AUTOPILOT_VERTICALSPEED_LOCK As New Offset(Of UInteger)(&H7EC)
        Public AUTOPILOT_VERTICALSPEED_LOCK_KNOTS As New Offset(Of UInteger)(&H7F2)
        Public AUTOPILOT_APPROACH_HOLD As New Offset(Of UInteger)(&H800)
        Public AUTOTHROTTLE_ARM As New Offset(Of UInteger)(&H810)
        ' Public DME_SWITCH As New Offset(Of UShort)(&H378)
        Public DME_SWITCH As New Offset(Of UShort)(&H66C0)
        Public Nav_1_OBS As New Offset(Of Short)(&HC4E)
        Public NAV_1_CDI As New Offset(Of Single)(&H2AAC)
        Public NAV_1_GSI As New Offset(Of Single)(&H2AB0)
        Public NAV_1_DME_DISTANCE As New Offset(Of Short)(&H300)
        Public NAV_1_DME_SPEED As New Offset(Of Short)(&H302)
        Public NAV_1_DME_TIMETO As New Offset(Of Short)(&H304)
        Public NAV_1_TOFROM As New Offset(Of Byte)(&HC4B)
        Public NAV_1_GS_ALIVE As New Offset(Of Byte)(&HC4C)
        Public NAV_1_SIGNAL_STRENGTH As New Offset(Of Int32)(&HC52)
        Public NAV_1_RADIAL As New Offset(Of Short)(&HC50)
        Public Nav_2_OBS As New Offset(Of Short)(&HC5E)
        Public NAV_2_CDI As New Offset(Of Single)(&H2AB4)
        Public NAV_2_GSI As New Offset(Of Single)(&H2AB8)
        Public NAV_2_DME_DISTANCE As New Offset(Of Short)(&H306)
        Public NAV_2_DME_SPEED As New Offset(Of Short)(&H308)
        Public NAV_2_DME_TIMETO As New Offset(Of Short)(&H30A)
        Public ELEVATOR_TRIM_POSITION As New Offset(Of Short)(&HBC2)
        Public TRAILING_EDGE_FLAPS_LEFT_PERCENT As New Offset(Of Integer)(&HBE0)
        Public TRAILING_EDGE_FLAPS_RIGHT_PERCENT As New Offset(Of Integer)(&HBE4)
        Public GENERAL_ENG_1_OIL_PRESSURE As New Offset(Of UShort)(&H8BA)
        Public GENERAL_ENG_2_OIL_PRESSURE As New Offset(Of UShort)(&H952)
        Public GENERAL_ENG_3_OIL_PRESSURE As New Offset(Of UShort)(&H9EA)
        Public GENERAL_ENG_4_OIL_PRESSURE As New Offset(Of UShort)(&HA82)
        Public GENERAL_ENG_1_OIL_TEMPERATURE As New Offset(Of Short)(&H8B8)
        Public GENERAL_ENG_2_OIL_TEMPERATURE As New Offset(Of Short)(&H950)
        Public GENERAL_ENG_3_OIL_TEMPERATURE As New Offset(Of Short)(&H9E8)
        Public GENERAL_ENG_4_OIL_TEMPERATURE As New Offset(Of Short)(&HA80)
        Public ENG_1_MANIFOLD_PRESSURE As New Offset(Of UShort)(&H8C0)
        Public ENG_2_MANIFOLD_PRESSURE As New Offset(Of UShort)(&H958)
        Public ENG_3_MANIFOLD_PRESSURE As New Offset(Of UShort)(&H9F0)
        Public ENG_4_MANIFOLD_PRESSURE As New Offset(Of UShort)(&HA88)
        Public PROP_1_RPM As New Offset(Of Double)(&H2400)
        Public PROP_2_RPM As New Offset(Of Double)(&H2500)
        Public PROP_3_RPM As New Offset(Of Double)(&H2600)
        Public PROP_4_RPM As New Offset(Of Double)(&H2700)
        Public LIGHTS As New Offset(Of Short)(&HD0C)

    End Class

End Class
