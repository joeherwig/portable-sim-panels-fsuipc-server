using NCalc2;
using System;
using System.Collections.Generic;

public class Calc
{
    // place for each key (variable) the formula as value where the lowercase 'x' represents the source value.
    public static Dictionary<string, string> valueRecalculation = new Dictionary<string, string>()
    {
        {
            "AIRSPEED_INDICATED",
            "x / 128"
        },
        {
            "PLANE_HEADING_DEGREES_MAGNETIC",
            "x * (360 / 65536 / 65536)"
        },
        {
            "PLANE_BANK_DEGREES",
            "x * (360 / 65536 / 65536) - 360"
        },
        {
            "PLANE_PITCH_DEGREES",
            "x * (360 / 65536 / 65536)"
        },
        {
            "VERTICAL_SPEED",
            "x * 60 * 3.28084 / 256 "
        },
        {
            "TURB_ENG_1_ITT",
            "(x - 491.67) * 5/9"
        },
        {
            "TURB_ENG_2_ITT",
            "(x - 491.67) * 5/9"
        },
        {
            "TURB_ENG_3_ITT",
            "(x - 491.67) * 5/9"
        },
        {
            "TURB_ENG_4_ITT",
            "(x - 491.67) * 5/9"
        },
        {
            "GEAR_LEFT_POSITION",
            "x/163.83"
        },
        {
            "GEAR_CENTER_POSITION",
            "x/163.83"
        },
        {
            "GEAR_RIGHT_POSITION",
            "x/163.83"
        },
        {
            "AUTOPILOT_HEADING_LOCK_DIR",
            "x / 65536 * 360"
        },
        {
            "AUTOPILOT_ALTITUDE_LOCK_VAR",
            "x * 3.28084 / 65536"
        },
        {
            "NAV_1_DME_DISTANCE",
            "x / 10"
        },
        {
            "NAV_1_DME_SPEED",
            "x / 10"
        },
        {
            "NAV_1_DME_TIMETO",
            "x / 10"
        },
        {
            "NAV_2_DME_DISTANCE",
            "x / 10"
        },
        {
            "NAV_2_DME_SPEED",
            "x / 10"
        },
        {
            "NAV_2_DME_TIMETO",
            "x / 10"
        },
        {
            "NAV_1_RADIAL",
            "x / 65536 * 360"
        },
        {
            "TRAILING_EDGE_FLAPS_LEFT_PERCENT",
            "x / 163.83"
        },
        {
            "TRAILING_EDGE_FLAPS_RIGHT_PERCENT",
            "x / 163.83"
        },
        {
            "GENERAL_ENG_1_OIL_TEMPERATURE",
            "x "
        },
        {
            "GENERAL_ENG_2_OIL_TEMPERATURE",
            "x "
        },
        {
            "GENERAL_ENG_3_OIL_TEMPERATURE",
            "x "
        },
        {
            "GENERAL_ENG_4_OIL_TEMPERATURE",
            "x "
        },
        {
            "GENERAL_ENG_1_OIL_PRESSURE",
            "x / 16384 * 55"
        },
        {
            "GENERAL_ENG_2_OIL_PRESSURE",
            "x / 16384 * 55"
        },
        {
            "GENERAL_ENG_3_OIL_PRESSURE",
            "x / 16384 * 55"
        },
        {
            "GENERAL_ENG_4_OIL_PRESSURE",
            "x / 16384 * 55"
        },
        {
            "ENG_1_MANIFOLD_PRESSURE",
            "x / 1024"
        },
        {
            "ENG_2_MANIFOLD_PRESSURE",
            "x / 1024"
        },
        {
            "ENG_3_MANIFOLD_PRESSURE",
            "x / 1024"
        },
        {
            "ENG_4_MANIFOLD_PRESSURE",
            "x / 1024"
        },
        {
            "PROP_1_RPM",
            "x"
        }
    };
    public static string CalculateValue(string key, string rawValue, out string returnValue)
    {
        returnValue = rawValue;
        if (valueRecalculation.ContainsKey(key) == true)
        {
            string calculation = Calc.valueRecalculation[key].Replace("x", rawValue).Replace(",", ".");
            try
            {
                Expression e = new Expression(calculation);
                returnValue = e.Evaluate().ToString();
                returnValue = Math.Round(Convert.ToDouble(returnValue), 2).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            returnValue = rawValue;
        }
        return returnValue.ToString().Replace(",", ".");
    }

    public static string To25kHzFrequency(string key, ushort rawValue, out string returnValue)
    {
        returnValue = ushortToBCD(rawValue);
        return returnValue;
    }
    public static string To8kHzFrequency(string key, uint rawValue, out string newFreq)
    {
        newFreq = (Convert.ToDecimal(rawValue) / 1000000).ToString("0.000", System.Globalization.CultureInfo.InvariantCulture);
        return newFreq;
    }

    static string ushortToBCD(ushort input)
    {
        byte[] bcds = BitConverter.GetBytes(input);
        Array.Reverse(bcds);
        decimal result = 0;
        foreach (byte bcd in bcds)
        {
            result *= 100;
            result += (10 * (bcd >> 4));
            result += bcd & 0xf;
        }
        result = (result + 10000) / 100;
        return result.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
    }
}