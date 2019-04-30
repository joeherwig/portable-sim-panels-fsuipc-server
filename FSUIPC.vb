Imports NCalc
Imports System.Reflection
Imports System.Windows.Threading
Imports FSUIPC
Imports Newtonsoft.Json


Partial Public Class MainWindow

    Public Class FSUIPC

        Public altitude As New Offset(Of UInteger)(&H3324)
        Public airspeedKnots As New Offset(Of UInteger)(&H2BC)
        Public avionicsMaster As New Offset(Of UInteger)(&H2E80)
        Public lights As New Offset(Of UInteger)(&HD0C)

    End Class

End Class
