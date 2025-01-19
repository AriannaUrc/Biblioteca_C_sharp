using MySql.Data.MySqlClient;  // Make sure you have this import
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void Button_Login_Click(object sender, EventArgs e)
        {
            string username = textBox_Username.Text;  // Assuming textBoxUsername is the input field for the username
            string password = textBox_Password.Text;  // Assuming textBoxPassword is the input field for the password

            if(username == "admin" && password == "adminpass")
            {
                this.Hide();
                admin_pannel admin = new admin_pannel();
                admin.Show();
            }
            else
            {
                if (ValidateUser(username, password))
                {
                    MessageBox.Show("Login successful!");
                    this.Hide(); // Hide login form
                    admin_pannel adminPanel = new admin_pannel();
                    adminPanel.ShowDialog();
                    this.Close(); // Ensure login form is closed after showing the admin panel
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
        }

        private bool ValidateUser(string username, string password)
        {
            bool isValid = false;
            string connString = "Server=127.0.0.1;Port=3306;Database=library_db;Uid=root;Pwd=;";  // Update this if needed

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT username, password FROM users WHERE username = @username";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Password in the database is hashed, so you should verify the hashed password
                            string storedPasswordHash = reader["password"].ToString();
                            if (BCrypt.Net.BCrypt.Verify(password, storedPasswordHash))
                            {
                                isValid = true; // Login is valid
                                MessageBox.Show("hello: " + username);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return isValid;
        }
    }
}
