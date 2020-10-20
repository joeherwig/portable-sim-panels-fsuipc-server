using System.Collections.Generic;

namespace portableSimPanelsFsuipcServer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static Dictionary<string, string> FsuipcObject = new Dictionary<string, string>();
        public static Dictionary<string, string> Previous = new Dictionary<string, string>();
        public static Dictionary<string, string> DeltaObject = new Dictionary<string, string>();
    }
}
