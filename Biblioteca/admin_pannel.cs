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
            LoadUsers();
        }

        // Load Books from Database
        private void LoadBooks()
        {
            MySqlConnection conn = dbConnection.Connect();
            if (conn != null)
            {
                try
                {
                    string query = "SELECT b.book_id, b.title, a.name AS author, c.name AS genre, b.available FROM books b JOIN authors a, categories c WHERE b.author_id = a.author_id AND b.category_id = c.category_id";
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

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string title = txtBookTitle.Text;
            string authorId = cmbAuthor.SelectedValue.ToString();  // Selected author ID from ComboBox
            string categoryId = cmbCategory.SelectedValue.ToString();  // Selected category ID from ComboBox
            string imagePath = textBoxUrl.Text; // Path to the selected image
            string base64Image = null;

            // Validate inputs
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(authorId) || string.IsNullOrEmpty(categoryId))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            // Check if an image is selected and convert it to Base64
            if (!string.IsNullOrEmpty(imagePath))
            {
                if (System.IO.File.Exists(imagePath))
                {
                    base64Image = ConvertImageToBase64(imagePath);
                }
                else
                {
                    MessageBox.Show("The selected image file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Connect to the database and save the book details
            MySqlConnection conn = dbConnection.Connect();
            if (conn != null)
            {
                try
                {
                    // Query to insert book details with image data
                    string query = @"
                INSERT INTO books (title, author_id, category_id, image_cnt) 
                VALUES (@title, @author_id, @category_id, @imageContent)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@author_id", authorId);
                    cmd.Parameters.AddWithValue("@category_id", categoryId);
                    cmd.Parameters.AddWithValue("@imageName", System.IO.Path.GetFileName(imagePath)); // Save image name
                    cmd.Parameters.AddWithValue("@imageContent", base64Image); // Save Base64 content

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book added successfully.");
                    LoadBooks(); // Refresh the books list
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dbConnection.CloseConnection(conn);
                }
            }
        }


        private string ConvertImageToBase64(string filePath)
        {
            try
            {
                byte[] imageBytes = System.IO.File.ReadAllBytes(filePath); // Read the file as bytes
                return Convert.ToBase64String(imageBytes); // Convert to Base64
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error converting image to Base64: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
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

        // Load Users from Database
        private void LoadUsers()
        {
            MySqlConnection conn = dbConnection.Connect();
            if (conn != null)
            {
                try
                {
                    string query = "SELECT user_id, username FROM users"; // Assuming 'users' table has user_id and username
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dgvUsers.DataSource = dataTable; // Bind the data to the DataGridView
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

        // Load Books Borrowed by a Specific User
        private void LoadBooksByUser(int userId)
        {
            MySqlConnection conn = dbConnection.Connect();
            if (conn != null)
            {
                try
                {
                    string query = @"
                SELECT b.title, a.name AS author, c.name AS category, bb.lend_date, bb.return_date
                FROM lending bb
                JOIN books b ON bb.book_id = b.book_id
                JOIN authors a ON b.author_id = a.author_id
                JOIN categories c ON b.category_id = c.category_id
                WHERE bb.user_id = @userId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dgvBorrowedBooks.DataSource = dataTable;  // Assuming you have a DataGridView for borrowed books
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

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("clicked");
            //MessageBox.Show(dgvUsers.SelectedRows.Count.ToString());
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["user_id"].Value); // Assuming "user_id" column exists
                LoadBooksByUser(userId); // Load books for the selected user
            }
        }


        private void admin_pannel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Terminates the application completely
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(open.FileName)) // Ensure the file exists
                {
                    textBoxUrl.Text = open.FileName; // Display file path in the TextBox
                }
                else
                {
                    MessageBox.Show("The selected file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnModifyBook_Click(object sender, EventArgs e)
        {
            string title = txtBookTitle.Text; // Book title to search for

            // Check if title is empty
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter the book title to modify.");
                return;
            }

            // Ensure that ComboBox values are valid before accessing them
            string authorId = cmbAuthor.SelectedValue?.ToString();  // Use null-conditional operator
            string categoryId = cmbCategory.SelectedValue?.ToString();  // Use null-conditional operator
            string imagePath = textBoxUrl.Text; // Path to the selected image
            string base64Image = null;

            // If ComboBox values are null, display an error message
            if (string.IsNullOrEmpty(authorId))
            {
                MessageBox.Show("Please select an author.");
                return;
            }

            if (string.IsNullOrEmpty(categoryId))
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            // Convert image to Base64 only if it's provided
            if (!string.IsNullOrEmpty(imagePath))
            {
                if (System.IO.File.Exists(imagePath))
                {
                    base64Image = ConvertImageToBase64(imagePath);
                }
                else
                {
                    MessageBox.Show("The selected image file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Connect to the database to check and update book details
            MySqlConnection conn = dbConnection.Connect();
            if (conn != null)
            {
                try
                {
                    // Check if the book exists
                    string checkQuery = "SELECT COUNT(*) FROM books WHERE title = @title";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@title", title);

                    int bookExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (bookExists > 0)
                    {
                        // Create the query dynamically based on which fields are updated
                        StringBuilder updateQuery = new StringBuilder("UPDATE books SET ");

                        // List to hold parameters for dynamic SQL query
                        List<MySqlParameter> parameters = new List<MySqlParameter>();

                        // If the author is changed, add to the query
                        if (!string.IsNullOrEmpty(authorId))
                        {
                            updateQuery.Append("author_id = @author_id, ");
                            parameters.Add(new MySqlParameter("@author_id", authorId));
                        }

                        // If the category is changed, add to the query
                        if (!string.IsNullOrEmpty(categoryId))
                        {
                            updateQuery.Append("category_id = @category_id, ");
                            parameters.Add(new MySqlParameter("@category_id", categoryId));
                        }

                        // If the image is changed, add to the query
                        if (!string.IsNullOrEmpty(base64Image))
                        {
                            updateQuery.Append("image_cnt = @imageContent, ");
                            parameters.Add(new MySqlParameter("@imageContent", base64Image));
                        }

                        // Remove the last comma and space from the query
                        if (updateQuery.ToString().EndsWith(", "))
                        {
                            updateQuery.Length -= 2; // Remove the last ", "
                        }

                        // Add the WHERE clause to ensure we update the correct book
                        updateQuery.Append(" WHERE title = @title");
                        parameters.Add(new MySqlParameter("@title", title));

                        // Execute the update command
                        MySqlCommand updateCmd = new MySqlCommand(updateQuery.ToString(), conn);
                        updateCmd.Parameters.AddRange(parameters.ToArray());

                        updateCmd.ExecuteNonQuery();
                        MessageBox.Show("Book details updated successfully.");
                        LoadBooks(); // Refresh the books list
                    }
                    else
                    {
                        MessageBox.Show("The book title does not exist in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dbConnection.CloseConnection(conn);
                }
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            // Check if a book is selected in the DataGridView
            if (dgvBooks.SelectedRows.Count > 0)
            {
                // Get the title of the selected book (assuming the title is in the first column)
                string title = dgvBooks.SelectedRows[0].Cells["title"].Value.ToString();

                // Confirm the deletion with the user
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the book '{title}'?",
                                                      "Confirm Deletion",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Get the book_id or any unique identifier from the selected row
                    int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["book_id"].Value);

                    // Connect to the database and delete the selected book
                    MySqlConnection conn = dbConnection.Connect();
                    if (conn != null)
                    {
                        try
                        {
                            string query = "DELETE FROM books WHERE book_id = @bookId"; // Use the unique book identifier (book_id)
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@bookId", bookId);

                            // Execute the delete command
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Book deleted successfully.");

                            // Refresh the book list
                            LoadBooks();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            dbConnection.CloseConnection(conn);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a book to delete.", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
