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
            var teamInsertQuery = "INSERT INTO Teams " +
                "(TeamName, EstYear) " +
                "VALUES (@TeamName, @EstYear);" +
                "SET @id=SCOPE_IDENTITY()";
            var statsInsertQuery = "SET IDENTITY_INSERT Stats ON;" +
                "INSERT INTO Stats " +
                "(TeamId, NumberOfPlayers, NumberOfStadiums, AverageGoalsPerPlayer) " +
                "VALUES (@TeamId, @NumberOfPlayers, @NumberOfStadiums, @AverageGoalsPerPlayer);" +
                "SET @id=SCOPE_IDENTITY()";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                
                SqlTransaction sqlTran = connection.BeginTransaction();

                SqlCommand command = connection.CreateCommand();
                command.Transaction = sqlTran;

                try
                {
                    command.CommandText = teamInsertQuery;
                    command.Parameters.Add("@TeamName", SqlDbType.NVarChar, 10).Value = teamName;
                    command.Parameters.Add("@EstYear", SqlDbType.Int).Value = estYear;
                    SqlParameter idParam = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.SmallInt,
                        Direction = ParameterDirection.Output // параметр выходной
                    };
                    command.Parameters.Add(idParam);
                    command.ExecuteNonQuery();

                    command.CommandText = statsInsertQuery;
                    command.Parameters.Add("@TeamId", SqlDbType.SmallInt).Value = idParam.Value;
                    command.Parameters.Add("@NumberOfPlayers", SqlDbType.Int).Value = 0;
                    command.Parameters.Add("@NumberOfStadiums", SqlDbType.Int).Value = 0;
                    command.Parameters.Add("@AverageGoalsPerPlayer", SqlDbType.Real).Value = 0;
                    command.ExecuteNonQuery();
                    
                    sqlTran.Commit();

                    return new TeamData
                    {
                        TeamId = (short)idParam.Value,
                        TeamName = teamName,
                        EstYear = estYear
                    };
                } catch (Exception ex)
                {
                    // Handle the exception if the transaction fails to commit.
                    Console.WriteLine(ex.Message);

                    try
                    {
                        // Attempt to roll back the transaction.
                        sqlTran.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        // Throws an InvalidOperationException if the connection
                        // is closed or the transaction has already been rolled
                        // back on the server.
                        Console.WriteLine(exRollback.Message);
                    }

                    return null;
                }
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

        public StatsData ReadStats(short teamId)
        {
            var query = "SELECT * FROM Stats WHERE TeamId = @TeamId";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@TeamId", SqlDbType.SmallInt).Value = teamId;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new StatsData
                        {
                            TeamId = (short)reader["TeamId"],
                            NumberOfPlayers = (int)reader["NumberOfPlayers"],
                            NumberOfStadiums = (int)reader["NumberOfStadiums"],
                            AverageGoalsPerPlayer = (float)reader["AverageGoalsPerPlayer"],
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
