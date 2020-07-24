using CSVReader.models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVReader.repositories
{
    public class UploadRepository: DatabaseConnector
    {
        public UploadRepository(string connectionString) : base(connectionString) { }
        public void Insert(HPIClass hpiClass)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO AllHPIs (ZipCodeId, Year, HPI )
                                                     VALUES (@zipcode, @year, @hpi)";
                    cmd.Parameters.AddWithValue("@zipcode", hpiClass.ZipCodeId);
                    cmd.Parameters.AddWithValue("@year", hpiClass.Year);
                    cmd.Parameters.AddWithValue("@hpi", hpiClass.HPI);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
