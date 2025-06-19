using Microsoft.Data.SqlClient;
using PhoneBook.Commons.Classes;
using System.Linq;
using System.Text;

namespace PhoneBook.Core
{
    internal class PhoneBookDAL
    {
        private static readonly string _connectionString = "Data Source=BASEWIN11PRO;Initial Catalog=PhoneBookDatabase;Integrated Security=True;";
        //string connectionString = "Data Source=BASEWIN11PRO;Initial Catalog=PhoneBookDatabase;Integrated Security=True;TrustServerCertificate=True;";

        internal static List<Contact> GetAllContacts()
        {
            List<Contact> contacts = new List<Contact>();
            string query = "SELECT Id, Nom FROM MaTable;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Database connection established successfully !");

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(reader.GetOrdinal("Id"));
                                    string name = reader.GetString(reader.GetOrdinal("Name"));
                                    string email = reader.GetString(reader.GetOrdinal("Email"));
                                    string phonenumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                                    string address = reader.GetString(reader.GetOrdinal("Address"));

                                    contacts.Add(new Contact(id, name, phonenumber, email, address));

                                    Console.WriteLine($"Id: {id}, Name: {name}, Email: {email}, Phone Number: {phonenumber}, Address: {address}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No data found in table");
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error : {ex.Message}");
                    Console.WriteLine($"Error number : {ex.Number}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error has occured : {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Connexion closed");
                }
            }

            return contacts;
        }
    }
}
