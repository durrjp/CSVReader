using CSVReader.models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVReader.repositories
{
    public class MortgageRateRepository: DatabaseConnector
    {
        public MortgageRateRepository(string connectionString) : base(connectionString) { }

        public void Insert(MortgageRate mrate)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO MortgageRate (Date, Value)
                                                     VALUES (@date, @value)";
                    cmd.Parameters.AddWithValue("@date", mrate.Date);
                    cmd.Parameters.AddWithValue("@value", mrate.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
