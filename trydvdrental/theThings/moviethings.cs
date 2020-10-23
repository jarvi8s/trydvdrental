using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace trydvdrental
{
    class moviethings
    {
        public static readonly string cmd = "Server=localhost;Port=5432;Database=rental;User Id=postgres;Password=postgres;";

        public static void Displaymovieandcopy()
        {

            using (NpgsqlConnection conn = new NpgsqlConnection(cmd))
            {
                Console.WriteLine("");
                conn.Open();
                NpgsqlCommand con = new NpgsqlCommand($"SELECT movies.title, count(copies.movie_id) AS copy_number FROM copies " +
                                                  $"JOIN movies ON copies.movie_id = movies.movie_id " +
                                                  $"GROUP BY movies.title",conn);
                NpgsqlDataReader dataReader = con.ExecuteReader();
                // string bosluk = "{0,37}\t";
                while (dataReader.Read())
                {
                    Console.WriteLine($"{dataReader["title"]} @{"{0,37}\t"} {dataReader["copy_number"]}");
                   
                }
                dataReader.Close(); 
                Console.WriteLine("okey");
                Console.ReadLine();
                
              
            }
        }

        internal static void CreateNewMovie(int movieID, int copyID,string title,double price,int year)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(cmd))
            {
                conn.Open();
                
                using (var command = new NpgsqlCommand("INSERT INTO movies(movie_id, Title, year, price) " +
                    "VALUES (@ID, @Title, @year, @price) " +
                    "ON CONFLICT (movie_id) DO UPDATE " +
                    "SET Title = @Title, year = @year, price = @price", conn))
                {
                    command.Parameters.AddWithValue("@ID",movieID);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@year", year);
                    command.Parameters.AddWithValue("@price", price);
                    command.ExecuteNonQuery();
                }
             
            }
            
        }
    }
}
