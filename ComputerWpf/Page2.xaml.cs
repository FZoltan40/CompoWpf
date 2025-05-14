using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
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

        private const string ConnectionString = "Server=localhost;Database=computer;Uid=root; Password=;SslMode=None";

        private void registerButton1_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show(RegisterUser(usernameTextBox.Text, passwordBox.Password, emailTextBox.Text));

        }

        private void backButton1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _mainWindow.MainFrame.Navigate(new Page1(_mainWindow));
        }

        private string GenerateSalt()
        {
            byte[] salt = new byte[16];

            using (var rnd = RandomNumberGenerator.Create())
            {
                rnd.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        private string ComputeHmacSha256(string password, string salt)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(salt)))
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }

        private string RegisterUser(string userName, string userPassword, string userEmail)
        {
            try
            {
                string salt = GenerateSalt();
                string hashedPassword = ComputeHmacSha256(userPassword, salt);

                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO `users`(`UserName`, `Email`, `PasswordHash`, `Salt`) VALUES (@userName,@userEmail,@paswordHash,@salt)";

                    using (var cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue("@userEmail", userEmail);
                        cmd.Parameters.AddWithValue("@paswordHash", hashedPassword);
                        cmd.Parameters.AddWithValue("@salt", salt);

                        cmd.ExecuteNonQuery();

                    }

                    connection.Close();
                }
                return "Sikeres regisztráció!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}

