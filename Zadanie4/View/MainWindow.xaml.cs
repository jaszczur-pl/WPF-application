using System.Windows;
using GUI.View;

namespace Zadanie4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
        }

        private void ShowPopup(object sender, RoutedEventArgs e) {
            Popup popup = new Popup();
            popup.Show();
        }
    }
}
