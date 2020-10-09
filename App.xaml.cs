using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
