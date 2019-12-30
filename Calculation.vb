Imports NCalc
Imports Newtonsoft.Json

Partial Public Class MainWindow
    ' place for each key (variable) the formula as value where the lowercase 'x' represents the source value.
    Dim valueRecalculation As New Dictionary(Of String, String) From {
        {"AIRSPEED_INDICATED", "x / 128"},
        {"PLANE_HEADING_DEGREES_MAGNETIC", "x * (360 / 65536 / 65536)"},
        {"PLANE_BANK_DEGREES", "x * (360 / 65536 / 65536) - 360"},
        {"PLANE_PITCH_DEGREES", "x * (360 / 65536 / 65536)"},
        {"VERTICAL_SPEED", "x * 60 * 3.28084 / 256 "},
        {"TURB_ENG_1_ITT", "(x - 491.67) * 5/9"},
        {"TURB_ENG_2_ITT", "(x - 491.67) * 5/9"},
        {"TURB_ENG_3_ITT", "(x - 491.67) * 5/9"},
        {"TURB_ENG_4_ITT", "(x - 491.67) * 5/9"},
        {"GEAR_LEFT_POSITION", "x/163.83"},
        {"GEAR_CENTER_POSITION", "x/163.83"},
        {"GEAR_RIGHT_POSITION", "x/163.83"},
        {"AUTOPILOT_HEADING_LOCK_DIR", "x / 65536 * 360"},
        {"AUTOPILOT_ALTITUDE_LOCK_VAR", "x * 3.28084 / 65536"},
        {"NAV_1_DME_DISTANCE", "x / 10"},
        {"NAV_1_DME_SPEED", "x / 10"},
        {"NAV_1_DME_TIMETO", "x / 10"},
        {"NAV_2_DME_DISTANCE", "x / 10"},
        {"NAV_2_DME_SPEED", "x / 10"},
        {"NAV_2_DME_TIMETO", "x / 10"},
        {"TRAILING_EDGE_FLAPS_LEFT_PERCENT", "x / 163.83"},
        {"TRAILING_EDGE_FLAPS_RIGHT_PERCENT", "x / 163.83"},
        {"GENERAL_ENG_1_OIL_TEMPERATURE", "x "},
        {"GENERAL_ENG_2_OIL_TEMPERATURE", "x "},
        {"GENERAL_ENG_3_OIL_TEMPERATURE", "x "},
        {"GENERAL_ENG_4_OIL_TEMPERATURE", "x "},
        {"ENG_1_MANIFOLD_PRESSURE", "x / 1024"},
        {"ENG_2_MANIFOLD_PRESSURE", "x / 1024"},
        {"ENG_3_MANIFOLD_PRESSURE", "x / 1024"},
        {"ENG_4_MANIFOLD_PRESSURE", "x / 1024"}
    }
    Public Function calculateValue(ByVal key, ByVal rawValue)
        Dim temp As Decimal
        Dim returnValue As Decimal = rawValue

        If valueRecalculation.ContainsKey(key) = True Then
            Dim calculation As String = valueRecalculation(key).ToString().Replace("x", rawValue.ToString())
            Dim result As Expression = New Expression(calculation)
            temp = result.Evaluate()
            returnValue = Math.Round(temp, 2)
        End If

        Return returnValue
    End Function

End Class


