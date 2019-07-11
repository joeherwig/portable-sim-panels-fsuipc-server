Imports FSUIPC

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
    End Class

End Class
