using CSVReader.models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVReader.repositories
{
    public class AllZVHIsRepository: DatabaseConnector
    {
        public AllZVHIsRepository(string connectionString) : base(connectionString) { }
        public void Insert(ZVHI zvhi)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO AllZVHIs (Date, Value, ZipCodeId )
                                                     VALUES (@date, @value, @zvhi)";
                    cmd.Parameters.AddWithValue("@date", zvhi.Date);
                    cmd.Parameters.AddWithValue("@value", zvhi.Value);
                    cmd.Parameters.AddWithValue("@zvhi", zvhi.ZipCodeId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
