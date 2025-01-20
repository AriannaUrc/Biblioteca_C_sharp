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
    public partial class user_pannel : Form
    {
        private MySqlConnection conn;
        private DatabaseConnection dbConnection;
        int userId;
        public user_pannel(int userId)
        {
            InitializeComponent();
            this.userId = userId;  // Set the userId for use in the form
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dbConnection = new DatabaseConnection();
            LoadGenres();
            LoadBooks();
            LoadBorrowedBooks();
            CheckUserSuspension();
        }


        private void CheckUserSuspension()
        {
            try
            {
                conn = dbConnection.Connect();
                string query = "SELECT suspended_until FROM suspensions WHERE user_id = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DateTime? suspensionEnd = reader["suspended_until"] as DateTime?;

                    if (suspensionEnd.HasValue && suspensionEnd.Value > DateTime.Now)
                    {
                        // User is suspended
                        lblSuspensionStatus.Text = "You are suspended until: " + suspensionEnd.Value.ToString("MM/dd/yyyy");
                        btnBorrow.Enabled = false; // Disable Borrow button
                    }
                    else
                    {
                        // User is not suspended
                        lblSuspensionStatus.Text = "You are not suspended.";
                        btnBorrow.Enabled = true; // Enable Borrow button
                    }
                }
                else
                {
                    // User is not suspended
                    lblSuspensionStatus.Text = "You are not suspended.";
                    btnBorrow.Enabled = true; // Enable Borrow button
                }
                dbConnection.CloseConnection(conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking suspension: " + ex.Message);
            }
        }


        private void LoadGenres()
        {
            try
            {
                conn = dbConnection.Connect();
                string genreQuery = "SELECT DISTINCT c.name FROM categories c";
                MySqlDataAdapter genreAdapter = new MySqlDataAdapter(genreQuery, conn);
                DataTable genreTable = new DataTable();
                genreAdapter.Fill(genreTable);

                if (genreTable.Rows.Count > 0)
                {
                    cmbGenre.DisplayMember = "name";
                    cmbGenre.ValueMember = "name";
                    cmbGenre.DataSource = genreTable;
                }
                else
                {
                    MessageBox.Show("No genres found.");
                }

                dbConnection.CloseConnection(conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading genres: " + ex.Message);
            }
        }


        private void LoadBooks(string searchTitle = "", string genre = "")
        {
            try
            {
                conn = dbConnection.Connect();
                string query = "SELECT b.book_id, b.title, c.name AS genre, b.available, b.image_cnt " +
                               "FROM books b " +
                               "JOIN categories c ON b.category_id = c.category_id " +
                               "WHERE b.title LIKE @searchTitle " +
                               (string.IsNullOrEmpty(genre) ? "" : "AND c.name = @genre");

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@searchTitle", "%" + searchTitle + "%");
                if (!string.IsNullOrEmpty(genre))
                {
                    cmd.Parameters.AddWithValue("@genre", genre);
                }

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                DataTable bookTable = new DataTable();
                dataAdapter.Fill(bookTable);

                if (bookTable.Rows.Count > 0)
                {
                    dgvBooks.DataSource = bookTable;
                    dgvBooks.Columns["available"].Visible = false; // Hide the 'available' column
                    dgvBooks.Columns["image_cnt"].Visible = false; // Hide the 'image_cnt' column
                }
                else
                {
                    MessageBox.Show("No books found.");
                }

                dbConnection.CloseConnection(conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message);
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1) // Ensure search applies to the All Books tab
            {
                string searchTitle = txtSearch.Text;
                string genre = cmbGenre.SelectedValue?.ToString();
                LoadBooks(searchTitle, genre);
            }
            else
            {
                MessageBox.Show("Search is only available in the All Books tab.");
            }
        }


        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                var selectedRow = dgvBooks.SelectedRows[0];
                string title = selectedRow.Cells["title"].Value.ToString();
                string genre = selectedRow.Cells["genre"].Value.ToString();
                string imageBase64 = selectedRow.Cells["image_cnt"].Value.ToString();
                bool available = Convert.ToBoolean(selectedRow.Cells["available"].Value);
                int bookId = Convert.ToInt32(selectedRow.Cells["book_id"].Value);

                // Display basic info
                lblTitle.Text = "Title: " + title;
                lblGenre.Text = "Genre: " + genre;

                // Display image
                DisplayBookImage(imageBase64);

                if (!available)
                {
                    // Another user borrowed the book
                    btnBorrow.Hide();
                    btnReturn.Hide();
                }
                else
                {
                    // Book is available, show the Borrow button
                    btnBorrow.Show();
                    btnReturn.Hide();
                }

                // Additional author details
                DisplayAuthorInfo(title);
            }
        }

        private bool IsBookBorrowedByCurrentUser(int bookId)
        {
            try
            {
                conn = dbConnection.Connect();
                string query = "SELECT COUNT(*) FROM lending " +
                               "WHERE book_id = @bookId AND user_id = @userId AND return_date IS NULL";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@bookId", bookId);
                cmd.Parameters.AddWithValue("@userId", userId);

                int borrowedCount = Convert.ToInt32(cmd.ExecuteScalar());
                dbConnection.CloseConnection(conn);

                return borrowedCount > 0; // Return true if the user has borrowed this book
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking borrowing status: " + ex.Message);
                return false;
            }
        }



        private void btnBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBooks.SelectedRows.Count > 0)
                {
                    string title = dgvBooks.SelectedRows[0].Cells["title"].Value.ToString();
                    int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["book_id"].Value);

                    // Set the lend date to today's date
                    DateTime lendDate = DateTime.Now;
                    DateTime? returnDate = null; // Initially, the book is not returned

                    conn = dbConnection.Connect();

                    // Begin a transaction
                    MySqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Insert a new record into the lending table
                        string insertQuery = "INSERT INTO lending (user_id, book_id, lend_date, return_date) " +
                                             "VALUES (@userId, @bookId, @lendDate, @returnDate)";

                        MySqlCommand cmd = new MySqlCommand(insertQuery, conn, transaction);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.Parameters.AddWithValue("@lendDate", lendDate);
                        cmd.Parameters.AddWithValue("@returnDate", returnDate);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Update the availability of the book
                        string updateBookQuery = "UPDATE books SET available = 0 WHERE book_id = @bookId";
                        cmd = new MySqlCommand(updateBookQuery, conn, transaction);
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.ExecuteNonQuery();

                        // Commit the transaction
                        transaction.Commit();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("You have successfully borrowed the book!");
                            btnBorrow.Hide();
                            btnReturn.Show();
                            LoadBooks();
                            LoadBorrowedBooks(); // Refresh borrowed books list
                            ResetBookSelection();
                        }
                        else
                        {
                            MessageBox.Show("Failed to borrow the book.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Rollback if an error occurs
                        transaction.Rollback();
                        MessageBox.Show("Error borrowing book: " + ex.Message);
                    }
                    finally
                    {
                        dbConnection.CloseConnection(conn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error borrowing book: " + ex.Message);
            }
        }





        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBorrowedBooks.SelectedRows.Count > 0)
                {
                    int bookId = Convert.ToInt32(dgvBorrowedBooks.SelectedRows[0].Cells["book_id"].Value);
                    DateTime returnDate = DateTime.Now;

                    conn = dbConnection.Connect();

                    // Begin a transaction
                    MySqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Update the lending table
                        string updateLendingQuery = "UPDATE lending SET return_date = @returnDate " +
                                                    "WHERE book_id = @bookId AND user_id = @userId AND return_date IS NULL";

                        MySqlCommand cmd = new MySqlCommand(updateLendingQuery, conn, transaction);
                        cmd.Parameters.AddWithValue("@returnDate", returnDate);
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.Parameters.AddWithValue("@userId", userId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Update the availability of the book
                        string updateBookQuery = "UPDATE books SET available = 1 WHERE book_id = @bookId";
                        cmd = new MySqlCommand(updateBookQuery, conn, transaction);
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.ExecuteNonQuery();

                        // Commit the transaction
                        transaction.Commit();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("You have successfully returned the book!");

                            // Refresh the borrowed books grid
                            LoadBorrowedBooks();
                            

                            // Remove the returned book from the DataGridView
                            foreach (DataGridViewRow row in dgvBorrowedBooks.Rows)
                            {
                                if (Convert.ToInt32(row.Cells["book_id"].Value) == bookId)
                                {
                                    dgvBorrowedBooks.Rows.Remove(row);
                                    break;
                                }
                            }

                            ResetBorrowedBookSelection(); // Ensure the first row is selected if there are remaining books
                        }
                        else
                        {
                            MessageBox.Show("Error returning the book.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Rollback if an error occurs
                        transaction.Rollback();
                        MessageBox.Show("Error returning book: " + ex.Message);
                    }
                    finally
                    {
                        dbConnection.CloseConnection(conn);
                    }
                }
                else if(dgvBooks.Rows.Count > 0)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error returning book: " + ex.Message);
            }
        }



        private void ResetBookSelection()
        {
            if (dgvBooks.Rows.Count > 0)
            {
                dgvBooks.ClearSelection(); // Clear existing selection
                dgvBooks.Rows[0].Selected = true; // Select the first row by default
                dgvBooks_SelectionChanged(null, null); // Trigger selection changed logic
            }

        }

        private void ResetBorrowedBookSelection()
        {
            if (dgvBorrowedBooks.Rows.Count > 0)
            {
                dgvBorrowedBooks.ClearSelection();
                dgvBorrowedBooks.CurrentCell = dgvBorrowedBooks.Rows[0].Cells[0]; // Set focus to the first cell
                dgvBorrowedBooks.Rows[0].Selected = true; // Select the first row
                dgvBorrowedBooks_SelectionChanged(null, null); // Manually trigger selection logic
            }
            else
            {
                // Clear displayed details if there are no rows
                lblTitle.Text = "Title: N/A";
                lblGenre.Text = "Genre: N/A";
                lblAuthor.Text = "Author: N/A";
                picBookImage.Image = null;
                btnReturn.Hide();
                btnBorrow.Hide();
            }
        }





        private void DisplayAuthorInfo(string title)
        {
            try
            {
                conn = dbConnection.Connect();
                string authorQuery = "SELECT a.name FROM authors a " +
                                     "JOIN books b ON b.author_id = a.author_id " +
                                     "WHERE b.title = @title";

                MySqlCommand cmd = new MySqlCommand(authorQuery, conn);
                cmd.Parameters.AddWithValue("@title", title);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblAuthor.Text = "Author: " + reader["name"].ToString();
                }
                else
                {
                    lblAuthor.Text = "Author: N/A";
                }

                dbConnection.CloseConnection(conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading author info: " + ex.Message);
            }
        }


        private void DisplayBookImage(string base64String)
        {
            try
            {
                if (!string.IsNullOrEmpty(base64String))
                {
                    byte[] imageBytes = Convert.FromBase64String(base64String);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        Image image = Image.FromStream(ms);
                        picBookImage.Image = image;
                        picBookImage.SizeMode = PictureBoxSizeMode.Zoom; // This will resize the image to fit within the PictureBox while maintaining the aspect ratio
                    }
                }
                else
                {
                    picBookImage.Image = null; // Or show a default image if no image is available
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying image: " + ex.Message);
            }
        }


        private void LoadBorrowedBooks()
        {
            try
            {
                conn = dbConnection.Connect();
                string query = @"SELECT b.book_id, b.title, c.name AS genre, b.image_cnt 
                         FROM books b 
                         JOIN categories c ON b.category_id = c.category_id
                         JOIN lending l ON b.book_id = l.book_id
                         WHERE l.user_id = @userId AND l.return_date IS NULL";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                DataTable borrowedBooksTable = new DataTable();

                dataAdapter.Fill(borrowedBooksTable);

                if (borrowedBooksTable.Rows.Count > 0)
                {
                    dgvBorrowedBooks.DataSource = null; // Clear the existing data source
                    dgvBorrowedBooks.DataSource = borrowedBooksTable; // Assign the new data source
                    dgvBorrowedBooks.Columns["image_cnt"].Visible = false; // Hide the 'image_cnt' column
                }
                else
                {
                    //MessageBox.Show("No borrowed books found.");
                }

                dbConnection.CloseConnection(conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading borrowed books: " + ex.Message);
            }
        }

        private void dgvBorrowedBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBorrowedBooks.SelectedRows.Count > 0)
            {
                var selectedRow = dgvBorrowedBooks.SelectedRows[0];
                string title = selectedRow.Cells["title"].Value.ToString();
                string genre = selectedRow.Cells["genre"].Value.ToString();
                string imageBase64 = selectedRow.Cells["image_cnt"].Value.ToString();
                int bookId = Convert.ToInt32(selectedRow.Cells["book_id"].Value);

                lblTitle.Text = "Title: " + title;
                lblGenre.Text = "Genre: " + genre;

                // Display the image
                DisplayBookImage(imageBase64);

                btnBorrow.Hide();
                btnReturn.Show();

                // Additional author details
                DisplayAuthorInfo(title);
            }
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                LoadBorrowedBooks();
                ResetBorrowedBookSelection(); // Ensure the first row is selected
            }
            else if (tabControl1.SelectedTab == tabPage1)
            {
                LoadBooks();
                ResetBookSelection(); // Optional, if you want to reset book selection in the available books tab
            }
        }
    }


}
