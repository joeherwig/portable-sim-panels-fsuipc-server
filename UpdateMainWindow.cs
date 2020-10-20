using System.Windows;

namespace portableSimPanelsFsuipcServer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private void UpdateJsonTextField(string data)
        {
            JsonTextField.Text = data;
        }

    }
}
