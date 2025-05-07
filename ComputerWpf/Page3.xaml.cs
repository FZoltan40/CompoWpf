using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Controls;

namespace ComputerWpf
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        private MainWindow _mainWindow;
        public Page3(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }
        private const string ConnectionString = "Server=localhost;Database=computer;Uid=root; Password=;SslMode=None";
        private string ReadComputer()
        {
            try
            {
                string sql = "SELECT * FROM comp";

                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var data = new MySqlDataAdapter(sql, connection))
                    {
                        DataTable dt = new DataTable();
                        data.Fill(dt);
                        dataGrid.ItemsSource = dt.DefaultView;
                    }

                    connection.Close();
                }
                return "Sikeres lekérdezés";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        private string ReadOs()
        {
            try
            {
                string sql = "SELECT * FROM osystem";

                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var data = new MySqlDataAdapter(sql, connection))
                    {
                        DataTable dt = new DataTable();
                        data.Fill(dt);
                        dataGrid.ItemsSource = dt.DefaultView;
                    }

                    connection.Close();
                }
                return "Sikeres lekérdezés.";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        private void button2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            resultQuery.Text = ReadComputer();
        }

        private void button3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            resultQuery.Text = ReadOs();
        }

        private void button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
