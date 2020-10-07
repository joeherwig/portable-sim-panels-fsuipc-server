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
        public static Dict FsuipcObject = new Dict();
        public static Dict Previous = new Dict();
        public static Dict Minified = new Dict();
        //public static MainWindow MainWindow = new MainWindow();
    }
}
