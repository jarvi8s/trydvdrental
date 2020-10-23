using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace trydvdrental
{
    class rentthings
    {
        public static readonly string cmd = "Server=localhost;Port=5432;Database=rental;User Id=postgres;Password=postgres;";

        public static void renting(int clientID, int copyID,string dateTime)
        {

            using (NpgsqlConnection conn = new NpgsqlConnection(cmd))
            {

                conn.Open();
                using (var command = new NpgsqlCommand($"INSERT INTO rentals(copy_id, client_id, date_of_rental) VALUES(@copyID, @clientID,@dateTime ", conn))
                {
                    command.Parameters.AddWithValue("@clientID", clientID);
                    command.Parameters.AddWithValue("@copyID", copyID);
                    command.Parameters.AddWithValue("@date_of_rental", dateTime);
            
                   
                }
                Console.WriteLine("okey");
                Console.ReadLine();
            }
        }
        public static void returning(int clientID, int coppyID, string returnDate)
        {
          //diffrent connection style
            NpgsqlCommand cmd = Connection.GetConnection().CreateCommand();
            NpgsqlTransaction transaction = Connection.GetConnection().BeginTransaction();
            cmd.Connection = Connection.GetConnection();
            cmd.Transaction = transaction;

            try
            {
                cmd.CommandText = $"UPDATE rentals SET date_of_return = '{returnDate}' WHERE copy_id = {coppyID} AND client_id = {clientID}";
                cmd.ExecuteNonQuery();
                transaction.Commit();
                Console.WriteLine("record is updated");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Error occured");
                transaction.Rollback();
            };
        }
        public static int statisticfromdate(string date)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(cmd))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("select SUM(price) as sum from rentals r join copies c on c.copy_id = r.copy_id join movies m on m.movie_id = c.movie_id where date_of_rental > @date::timestamp", conn))
                {
                    command.Parameters.AddWithValue("@date", date);

                    NpgsqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    if (reader["sum"].ToString() != "")
                    {
                        return int.Parse(reader["sum"].ToString());
                    }
                    else return 0;

                }
            }
        }
    }
}
