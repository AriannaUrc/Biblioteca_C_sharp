using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class admin_pannel : Form
    {
        private DatabaseConnection dbConnection;

        public admin_pannel()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            LoadBooks(); // Load books when form loads
            LoadAuthors(); // Load authors into ComboBox
            LoadCategories(); // Load categories into ComboBox
        }

        // Load Books from Database
        private void LoadBooks()
        {
            MySqlConnection conn = dbConnection.Connect();
            if (conn != null)
            {
                try
                {
                    string query = "SELECT b.title, a.name, c.name, b.available, b.image FROM books b JOIN authors a, categories c WHERE b.author_id = a.author_id AND b.category_id = c.category_id";
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataAdapter.Fill(dataTable);
                    dgvBooks.DataSource = dataTable;  // Bind the data to DataGridView
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    dbConnection.CloseConnection(conn);
                }
            }
        }

        // Add a Book to the Database
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string title = txtBookTitle.Text;
            string authorId = cmbAuthor.SelectedValue.ToString();  // Selected author ID from ComboBox
            string categoryId = cmbCategory.SelectedValue.ToString();  // Selected category ID from ComboBox

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(authorId) || string.IsNullOrEmpty(categoryId))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            MySqlConnection conn = dbConnection.Connect();
            if (conn != null)
            {
                try
                {
                    string query = "INSERT INTO books (title, author_id, category_id) VALUES (@title, @author_id, @category_id)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@author_id", authorId);
                    cmd.Parameters.AddWithValue("@category_id", categoryId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book added successfully.");
                    LoadBooks();  // Refresh the books list
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    dbConnection.CloseConnection(conn);
                }
            }
        }

        // Load Authors from Database into ComboBox
        private void LoadAuthors()
        {
            MySqlConnection conn = dbConnection.Connect();
            if (conn != null)
            {
                try
                {
                    string query = "SELECT author_id, name FROM authors";
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataAdapter.Fill(dataTable);

                    cmbAuthor.DataSource = dataTable;
                    cmbAuthor.DisplayMember = "name";
                    cmbAuthor.ValueMember = "author_id";
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    dbConnection.CloseConnection(conn);
                }
            }
        }

        // Load Categories from Database into ComboBox
        private void LoadCategories()
        {
            MySqlConnection conn = dbConnection.Connect();
            if (conn != null)
            {
                try
                {
                    string query = "SELECT category_id, name FROM categories";
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataAdapter.Fill(dataTable);

                    cmbCategory.DataSource = dataTable;
                    cmbCategory.DisplayMember = "name";
                    cmbCategory.ValueMember = "category_id";
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    dbConnection.CloseConnection(conn);
                }
            }
        }

        // Add New Author to the Database
        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            string authorName = txtAuthorName.Text;

            if (string.IsNullOrEmpty(authorName))
            {
                MessageBox.Show("Please enter an author name.");
                return;
            }

            MySqlConnection conn = dbConnection.Connect();
            if (conn != null)
            {
                try
                {
                    string query = "INSERT INTO authors (name) VALUES (@name)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", authorName);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Author added successfully.");
                    LoadAuthors();  // Refresh the authors list
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    dbConnection.CloseConnection(conn);
                }
            }
        }

        // Add New Category to the Database
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text;

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            MySqlConnection conn = dbConnection.Connect();
            if (conn != null)
            {
                try
                {
                    string query = "INSERT INTO categories (name) VALUES (@name)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", categoryName);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category added successfully.");
                    LoadCategories();  // Refresh the categories list
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    dbConnection.CloseConnection(conn);
                }
            }
        }
    }
}
