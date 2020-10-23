using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;


namespace trydvdrental
{
    class userthings
    {
        public static readonly string cmd = "Server=localhost;Port=5432;Database=rental;User Id=postgres;Password=postgres;";

        public static void DisplayUserRentalDetail(int clientID)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(cmd))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand($"SELECT first_name ||' '|| last_name as full_name, movies.title FROM clients " +
                                                  $"JOIN rentals ON clients.client_id = rentals.client_id " +
                                                  $"JOIN copies ON rentals.copy_id = copies.copy_id " +
                                                  $"JOIN movies ON copies.movie_id = movies.movie_id " +
                                                  $"WHERE clients.client_id = @clientId;", conn);
                cmd.Parameters.AddWithValue("@clientId", clientID);
                NpgsqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                Console.WriteLine($"{dataReader["full_name"]}'s rental history: ");
                while (dataReader.Read())
                {
                    Console.WriteLine($"{dataReader["title"]}");
                }
                dataReader.Close();
            }
        }
        public static void CreateNewUser(int clientId)
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter date of birth: it has to be (YYYY-MM-DD) ");
            string birthday = Console.ReadLine();
            NpgsqlCommand cmd = Connection.GetConnection().CreateCommand();

            try
            {
                cmd.CommandText = $"INSERT INTO clients(client_id, first_name, last_name, birthday) VALUES({clientId}, '{firstName}', '{lastName}','{birthday}')";
                cmd.ExecuteNonQuery();
                Console.WriteLine("record is updated");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Error occured");
            };
        }
    }
}
