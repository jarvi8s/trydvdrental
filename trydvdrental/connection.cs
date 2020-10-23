using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace trydvdrental
{
    public class Connection
    {
        private static NpgsqlConnection conn;

        public static NpgsqlConnection GetConnection()
        {
            try
            {
                if (conn == null)
                {
                    conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=rental;User Id=postgres;Password=postgres;");
                    conn.Open();
                }
                Console.WriteLine("Access success");
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Access failed");
            return conn;
        }
    }
}
