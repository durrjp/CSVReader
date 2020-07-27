using CSVReader.models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVReader.repositories
{
    public class AllZipsRepository: DatabaseConnector
    {
        public AllZipsRepository(string connectionString) : base(connectionString) { }
        public void Insert(Zip zip)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO AllZips (ZipCode, State, City, County, ForecastYoYPctChange )
                                                     VALUES (@zipcode, @state, @city, @county, @fcYOY)";
                    cmd.Parameters.AddWithValue("@zipcode", zip.ZipCode);
                    cmd.Parameters.AddWithValue("@state", zip.State);
                    cmd.Parameters.AddWithValue("@city", zip.City);
                    cmd.Parameters.AddWithValue("@county", zip.County); 
                    cmd.Parameters.AddWithValue("@fcYOY", zip.ForecastYoYPctChange);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Zip> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT 
	                                        Id, 
	                                        ZipCode, 
	                                        State,
                                            City,
	                                        County,
                                            ForecastYoYPctChange
                                        FROM AllZips
                                        ";

                    List<Zip> zips = new List<Zip>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Zip zip = new Zip()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            ZipCode = reader.GetInt32(reader.GetOrdinal("ZipCode")),
                            State = reader.GetString(reader.GetOrdinal("State")),
                            City = reader.GetString(reader.GetOrdinal("City")),
                            County = reader.GetString(reader.GetOrdinal("County")),
                            ForecastYoYPctChange = reader.GetDecimal(reader.GetOrdinal("ForecastYoYPctChange"))
                        };
                        zips.Add(zip);
                    }

                    reader.Close();

                    return zips;
                }
            }
        }
        public void Update(Zip zip)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE AllZips
                            SET ZipCode = @zipcode, 
                                State = @state, 
                                StateId = @stateId, 
                                City = @City, 
                                County = @County,
                                ForecastYoYPctChange = @ForecastYoYPctChange 
                            WHERE Id = @id"
                            ;
                    cmd.Parameters.AddWithValue("@zipcode", zip.ZipCode);
                    cmd.Parameters.AddWithValue("@state", zip.State);
                    cmd.Parameters.AddWithValue("@stateId", zip.StateId);
                    cmd.Parameters.AddWithValue("@City", zip.City);
                    cmd.Parameters.AddWithValue("@County", zip.County);
                    cmd.Parameters.AddWithValue("@ForecastYoYPctChange", zip.ForecastYoYPctChange);
                    cmd.Parameters.AddWithValue("@id", zip.Id);


                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
