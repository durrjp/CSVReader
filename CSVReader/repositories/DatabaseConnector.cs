using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Text;

namespace CSVReader.repositories
{
    public class DatabaseConnector
    {
        private readonly string _connectionString;
        protected SqlConnection Connection => new SqlConnection(_connectionString);

        public DatabaseConnector(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
