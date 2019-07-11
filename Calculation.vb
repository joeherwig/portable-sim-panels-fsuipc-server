Imports NCalc
Imports Newtonsoft.Json

Partial Public Class MainWindow
    Dim valueRecalculation As New Dictionary(Of String, String) From {
               {"AIRSPEED_INDICATED", "/128"},
               {"PLANE_HEADING_DEGREES_MAGNETIC", "*360/65536/65536"},
               {"PLANE_BANK_DEGREES", "*(360/65536/65536)-360"},
               {"PLANE_PITCH_DEGREES", "*(360/65536/65536)"},
               {"VERTICAL_SPEED", "*60*3.28084/256 "}
           }
    Public Function calculateValue(ByVal key, ByVal rawValue)
        Dim temp As Decimal
        Dim returnValue As Decimal = rawValue

        If valueRecalculation.ContainsKey(key) = True Then
            Dim calculation As String = rawValue.ToString() & valueRecalculation(key)
            Dim result As Expression = New Expression(calculation)
            temp = result.Evaluate()
            returnValue = Math.Round(temp, 2)
        End If

        Return returnValue
    End Function

End Class


