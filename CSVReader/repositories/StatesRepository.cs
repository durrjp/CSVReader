using CSVReader.models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVReader.repositories
{
    public class StatesRepository: DatabaseConnector
    {
        public StatesRepository(string connectionString) : base(connectionString) { }
        public void Insert(State state)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO States (StateAbbr, StateName, costIndex, costRank,
                                        groceryCost, housingCost, utilitiesCost, transportationCost, miscCost )
                     VALUES (@stateabbr, @statename, @costindex, @costrank, @grocerycost, @housingcost,
                                        @utilitiescost, @transportationcost, @misccost)";
                    cmd.Parameters.AddWithValue("@stateabbr", state.StateAbbr);
                    cmd.Parameters.AddWithValue("@statename", state.StateName);
                    cmd.Parameters.AddWithValue("@costindex", state.costIndex);
                    cmd.Parameters.AddWithValue("@costrank", state.costRank);
                    cmd.Parameters.AddWithValue("@grocerycost", state.groceryCost);
                    cmd.Parameters.AddWithValue("@housingcost", state.housingCost);
                    cmd.Parameters.AddWithValue("@utilitiescost", state.utilitiesCost);
                    cmd.Parameters.AddWithValue("@transportationcost", state.transportationCost);
                    cmd.Parameters.AddWithValue("@misccost", state.miscCost);


                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
