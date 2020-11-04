using System.Collections.Generic;
using System.Linq;

namespace portableSimPanelsFsuipcServer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static void GetDeltaObject(Dictionary<string, string> previousValues, Dictionary<string, string> currentValues)
        {
            App.DeltaObject.Clear();
            foreach (KeyValuePair<string, string> pair in currentValues)
            {
                if (pair.Value != previousValues[pair.Key])
                {
                    App.DeltaObject[pair.Key] = currentValues[pair.Key];
                }
            }
            App.Previous = App.FsuipcObject.ToDictionary(entry => entry.Key, entry => entry.Value);
            return;
        }
    }
}
