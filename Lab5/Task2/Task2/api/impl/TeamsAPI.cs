using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using Task2.data;

namespace Task2.api.impl
{
    class TeamsAPI : ITeamsAPI
    {
        public string ConnectionString { get; set; }
        
        public TeamData Create(string teamName, int estYear)
        {
            var query = "INSERT INTO Teams " +
                "(TeamName, EstYear) " +
                "VALUES (@TeamName, @EstYear);" +
                "SET @id=SCOPE_IDENTITY()";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TeamName", SqlDbType.NVarChar, 10).Value = teamName;
                command.Parameters.Add("@EstYear", SqlDbType.Int).Value = estYear;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.SmallInt,
                    Direction = ParameterDirection.Output // параметр выходной
                };
                command.Parameters.Add(idParam);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                return new TeamData
                {
                    TeamId = (short) idParam.Value,
                    TeamName = teamName,
                    EstYear = estYear
                };
            }
        }

        public TeamData Read(short teamId)
        {
            var query = "SELECT * FROM Teams WHERE TeamId = @TeamId";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@TeamId", SqlDbType.SmallInt).Value = teamId;
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        short tid = (short)reader["TeamId"];
                        string tname = (string)reader["TeamName"];
                        int ey = (int)reader["EstYear"];

                        return new TeamData
                        {
                            TeamId = tid,
                            TeamName = tname,
                            EstYear = ey
                        };
                    }
                }
            }

            return null;
        }

        public void Update(short teamId, TeamData teamData)
        {
            var query = "UPDATE Teams " +
                "SET TeamName = @TeamName, " +
                "EstYear = @EstYear " +
                "WHERE TeamId = @TeamId";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@TeamName", SqlDbType.NVarChar, 10).Value = teamData.TeamName;
                command.Parameters.Add("@EstYear", SqlDbType.Int).Value = teamData.EstYear;
                command.Parameters.Add("@TeamId", SqlDbType.SmallInt).Value = teamId;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(short teamId)
        {
            var query = "DELETE FROM Teams WHERE TeamId = @TeamId";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@TeamId", SqlDbType.SmallInt).Value = teamId;
         
                command.ExecuteNonQuery();
            }
        }
    }
}
