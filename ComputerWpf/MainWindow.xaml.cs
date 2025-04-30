using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace ComputerWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private const string ConnectionString = "Server=localhost;Database=computer;Uid=root; Password=;SslMode=None";
        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ReadComputer();
        }

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
                return "";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
