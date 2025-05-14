using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
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

        private const string ConnectionString = "Server=localhost;Database=computer;Uid=root; Password=;SslMode=None";
        private void funct1()
        {

        }

        private void loginButton1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (LoginUser(usernameTextBox.Text, passwordBox.Password) == true)
            {
                _mainWindow.MainFrame.Navigate(new Page3(_mainWindow));
            }
            else
            {
                MessageBox.Show("Nem megfelelő felhasználónév vagy jelszó!");
            }
        }

        private void Hyperlink_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _mainWindow.MainFrame.Navigate(new Page2(_mainWindow));
        }

        private string ComputeHmacSha256(string password, string salt)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(salt)))
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }

        private bool LoginUser(string userName, string userPassword)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "SELECT `PasswordHash`,`Salt` FROM `users` WHERE `UserName` = @userName;";

                using (var cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader.GetString(0);
                            string storedSalt = reader.GetString(1);
                            string computeHash = ComputeHmacSha256(userPassword, storedSalt);
                            return storedHash == computeHash;

                        }
                    }
                }

                connection.Close();

                return false;
            }
        }
    }
}
