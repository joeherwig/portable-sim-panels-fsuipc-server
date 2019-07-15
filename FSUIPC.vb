﻿Imports FSUIPC

Partial Public Class MainWindow

    Public Class FSUIPC

        Public INDICATED_ALTITUDE As New Offset(Of UInteger)(&H3324)
        Public AIRSPEED_INDICATED As New Offset(Of UInteger)(&H2BC)
        Public avionicsMaster As New Offset(Of UInteger)(&H2E80)
        Public lights As New Offset(Of UInteger)(&HD0C)
        Public PLANE_HEADING_DEGREES_MAGNETIC As New Offset(Of UInteger)(&H580)
        Public PLANE_BANK_DEGREES As New Offset(Of UInteger)(&H57C)
        Public PLANE_PITCH_DEGREES As New Offset(Of UInteger)(&H578)
        Public VERTICAL_SPEED As New Offset(Of Integer)(&H2C8)
        Public NAV_1_CDI As New Offset(Of Single)(&H2AAC)
        Public NAV_1_GSI As New Offset(Of Single)(&H2AB0)
        Public NAV_2_CDI As New Offset(Of Single)(&H2AB4)
        Public NAV_2_GSI As New Offset(Of Single)(&H2AB8)
        Public ENG_1_TORQUE As New Offset(Of Single)(&H920)
        Public ENG_2_TORQUE As New Offset(Of Single)(&H9B8)
        Public ENG_3_TORQUE As New Offset(Of Single)(&HA50)
        Public ENG_4_TORQUE As New Offset(Of Single)(&HAE8)
        Public TURB_ENG_1_ITT As New Offset(Of Double)(&H2038)
        Public TURB_ENG_2_ITT As New Offset(Of Double)(&H2138)
        Public TURB_ENG_3_ITT As New Offset(Of Double)(&H2238)
        Public TURB_ENG_4_ITT As New Offset(Of Double)(&H2338)
    End Class

End Class
