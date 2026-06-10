using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Practice_MAUI.Views
{
    internal static class DataBase
    {

        public static string ConnectionStringer()

        {
            string dbPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../helen.db")); // where to find database
            SqliteConnectionStringBuilder connectionsStringBuilder = new SqliteConnectionStringBuilder // builds connection string so database can be reached
            {
                DataSource = dbPath // where the connection is going to
            };

            string connectionString = connectionsStringBuilder.ToString();

            return connectionString;
        }


        public static bool CreateTable(string connectionString)
        {

            try
            {
                using (SqliteConnection connection = new SqliteConnection(connectionString)) //can do without this if remember to use connection.Close()
                { // means that the connection is closed when the function is not being used 
                    connection.Open(); // opens the connection to the database
                    SqliteCommand command = connection.CreateCommand(); // allows a new SQL command to be written
                    command.CommandText = "CREATE TABLE IF NOT EXISTS TblUsers (id INTEGER PRIMARY KEY, name TEXT, password TEXT);"; // the SQL command that details the elements of the table: a semicolon has to be added to agree with the SQL syntax
                    command.ExecuteNonQuery(); // the command is executed 
                }
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public static void InsertUser(string connectionString, string name, string password)
        {
            try
            {
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    SqliteCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO TblUsers (name, password) VALUES (@name, @password);";
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@password", password);
                    command.ExecuteNonQuery();
                }
            }

            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        public static string FindUser(string connectionString, string username)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM TblUsers WHERE name = @username;";
                command.ExecuteNonQuery();
                command.Parameters.AddWithValue("@username", username);
                SqliteDataReader tempString = command.ExecuteReader();

                while (tempString.Read())
                {
                    string id = tempString.GetString(0);
                    string name = tempString.GetString(1);
                    string password = tempString.GetString(2);
                    string allValues = $"ID: {id}, Name: {name}, Password: {password}";

                    return allValues;
                }
            }

            return "not found";
        }

        public static bool UserExists(string connectionString, string username)
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM TblUsers WHERE name = @username;";
                command.ExecuteNonQuery();

                int userCount = (int)command.ExecuteScalar();
                if (userCount > 0) { return true; } else { return false; }
            }
        }
    }
}
