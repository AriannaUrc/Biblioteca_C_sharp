// DatabaseConnection.cs
using MySql.Data.MySqlClient;
using System;

public class DatabaseConnection
{
    private string connectionString;

    // Constructor to initialize the connection string
    public DatabaseConnection()
    {
        // Set up connection string (adjust if necessary for your MySQL configuration)
        string server = "localhost";   // or your server address
        string database = "library_db"; // Adjust this if your database name is different
        string username = "root";       // Default for XAMPP or your MySQL username
        string password = "";           // Default is blank for XAMPP, replace if necessary

        // Define connection string
        connectionString = $"Server={server};Database={database};User ID={username};Password={password};";
    }

    // Method to connect to the MySQL database
    public MySqlConnection Connect()
    {
        try
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open(); // Attempt to open the connection
            Console.WriteLine("Connected to the database successfully.");
            return connection;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null; // Return null if connection fails
        }
    }

    // Method to close the MySQL database connection
    public void CloseConnection(MySqlConnection connection)
    {
        if (connection != null && connection.State == System.Data.ConnectionState.Open)
        {
            connection.Close();
            Console.WriteLine("Database connection closed.");
        }
    }
}
