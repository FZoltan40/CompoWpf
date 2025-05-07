using System.Windows.Controls;

namespace ComputerWpf
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private MainWindow _mainWindow;
        public Page2(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void registerButton1_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void registerButton1_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void backButton1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _mainWindow.MainFrame.Navigate(new Page1(_mainWindow));
        }
    }
}
