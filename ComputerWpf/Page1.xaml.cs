using System.Windows.Controls;

namespace ComputerWpf
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private MainWindow _mainWindow;
        public Page1(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void funct1()
        {

        }

        private void loginButton1_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Hyperlink_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _mainWindow.MainFrame.Navigate(new Page2(_mainWindow));
        }
    }
}
