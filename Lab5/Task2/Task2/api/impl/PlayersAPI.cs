using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using Task2.data;

namespace Task2.api.impl
{
    class PlayersAPI : IPlayersAPI
    {
        public string ConnectionString { get; set; }

        public PlayerData Create(string firstName, string secondName, short? addressId, short? teamId, int numberOfGoals)
        {
            var playerInsertQuery = "INSERT INTO Players " +
                "(FirstName, SecondName, AddressId, TeamId, NumberOfGoals) " +
                "VALUES (@FirstName, @SecondName, @AddressId, @TeamId, @NumberOfGoals);" +
                "SET @id=SCOPE_IDENTITY()";
            var statsReadQuery = "SELECT * FROM Stats WHERE TeamID = @TeamId";
            var statsUpdateQuery = "UPDATE Stats SET " +
                "NumberOfPlayers = @NumberOfPlayers, " +
                "NumberOfStadiums = @NumberOfStadiums, " +
                "AverageGoalsPerPlayer = @AverageGoalsPerPlayer " +
                "WHERE TeamID = @TeamId";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var sqlTransaction = connection.BeginTransaction();

                SqlCommand command1 = connection.CreateCommand();
                command1.Transaction = sqlTransaction;
                SqlCommand command2 = connection.CreateCommand();
                command2.Transaction = sqlTransaction;
                SqlCommand command3 = connection.CreateCommand();
                command3.Transaction = sqlTransaction;

                try
                {
                    command1.CommandText = playerInsertQuery;
                    command1.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = firstName;
                    command1.Parameters.Add("@SecondName", SqlDbType.NVarChar, 50).Value = secondName;
                    command1.Parameters.Add("@AddressId", SqlDbType.SmallInt).Value = (object)addressId ?? DBNull.Value;
                    command1.Parameters.Add("@TeamId", SqlDbType.SmallInt).Value = (object)teamId ?? DBNull.Value;
                    command1.Parameters.Add("@NumberOfGoals", SqlDbType.Int).Value = numberOfGoals;
                    SqlParameter idParam = new SqlParameter
                    {
                        ParameterName = "@id",
                        SqlDbType = SqlDbType.SmallInt,
                        Direction = ParameterDirection.Output // параметр выходной
                    };
                    command1.Parameters.Add(idParam);
                    command1.ExecuteNonQuery();

                    if (teamId != null)
                    {
                        StatsData statsData;
                        command2.CommandText = statsReadQuery;
                        command2.Parameters.Add("@TeamId", SqlDbType.SmallInt).Value = teamId;
                        
                        using (SqlDataReader reader = command2.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                statsData = new StatsData
                                {
                                    TeamId = teamId ?? 0,
                                    NumberOfPlayers = (int)reader["NumberOfPlayers"],
                                    NumberOfStadiums = (int)reader["NumberOfStadiums"],
                                    AverageGoalsPerPlayer = (float)reader["AverageGoalsPerPlayer"]
                                };
                            } else
                            {
                                statsData = null;
                            }
                        }

                        if (statsData != null)
                        {
                            command3.CommandText = statsUpdateQuery;
                            command3.Parameters.Add("@TeamId", SqlDbType.SmallInt).Value = teamId;
                            command3.Parameters.Add("@NumberOfPlayers", SqlDbType.Int).Value = statsData.NumberOfPlayers + 1;
                            command3.Parameters.Add("@NumberOfStadiums", SqlDbType.Int).Value = statsData.NumberOfStadiums;
                            command3.Parameters.Add("@AverageGoalsPerPlayer", SqlDbType.Real).Value = (statsData.AverageGoalsPerPlayer * statsData.NumberOfPlayers + numberOfGoals) / (statsData.NumberOfPlayers + 1);
                            command3.ExecuteNonQuery();
                        }
                    }

                    sqlTransaction.Commit();

                    return new PlayerData
                    {
                        PlayerId = (short)idParam.Value,
                        FirstName = firstName,
                        SecondName = secondName,
                        AddressId = addressId,
                        TeamId = teamId,
                        NumberOfGoals = numberOfGoals
                    };
                }
                catch (Exception ex)
                {
                    // Handle the exception if the transaction fails to commit.
                    Console.WriteLine(ex.Message);

                    try
                    {
                        // Attempt to roll back the transaction.
                        sqlTransaction.Rollback();
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

        public PlayerData Read(short playerId)
        {
            var query = "SELECT * FROM Players WHERE PlayerId = @PlayerId LIMIT 1";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@PlayerId", SqlDbType.SmallInt).Value = playerId;
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var playerData = new PlayerData
                        {
                            PlayerId = (short)reader["PlayerId"],
                            FirstName = (string)reader["FirstName"],
                            SecondName = (string)reader["SecondName"],
                            AddressId = reader["AddressId"] == DBNull.Value ? null : (short?)reader["AddressId"],
                            TeamId = reader["TeamId"] == DBNull.Value ? null : (short?)reader["TeamId"],
                            NumberOfGoals = (int)reader["NumberOfGoals"]
                        };

                        return playerData;
                    }
                }
            }

            return null;
        }

        public List<PlayerData> ReadAll()
        {
            var result = new List<PlayerData>();
            var query = "SELECT * FROM Players";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var playerData = new PlayerData
                        {
                            PlayerId = (short)reader["PlayerId"],
                            FirstName = (string)reader["FirstName"],
                            SecondName = (string)reader["SecondName"],
                            AddressId = reader["AddressId"] == DBNull.Value ? null : (short?)reader["AddressId"],
                            TeamId = reader["TeamId"] == DBNull.Value ? null : (short?)reader["TeamId"],
                            NumberOfGoals = (int)reader["NumberOfGoals"]
                        };

                        result.Add(playerData);
                    }
                }
            }

            return result;
        }

        public void Update(short playerId, PlayerData playerData)
        {
            var result = new List<PlayerData>();
            var query = "UPDATE Players " +
                "SET FirstName = @FirstName, " +
                "SecondName = @SecondName, " +
                "AddressId = @AddressId, " +
                "TeamId = @TeamId, " +
                "NumberOfGoals = @NumberOfGoals " +
                "WHERE PlayerId = @PlayerId";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = playerData.FirstName;
                command.Parameters.Add("@SecondName", SqlDbType.NVarChar, 50).Value = playerData.SecondName;
                command.Parameters.Add("@AddressId", SqlDbType.SmallInt).Value = (object)playerData.AddressId ?? DBNull.Value;
                command.Parameters.Add("@TeamId", SqlDbType.SmallInt).Value = (object)playerData.TeamId ?? DBNull.Value;
                command.Parameters.Add("@NumberOfGoals", SqlDbType.SmallInt).Value = playerData.NumberOfGoals;
                command.Parameters.Add("@PlayerId", SqlDbType.SmallInt).Value = playerId;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(short playerId)
        {
            var result = new List<PlayerData>();
            var query = "DELETE FROM Players WHERE PlayerId = @PlayerId";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@PlayerId", SqlDbType.SmallInt).Value = playerId;
         
                command.ExecuteNonQuery();
            }
        }

        public List<PlayerData> ReadTeamPlayers(short teamId)
        {
            List<PlayerData> result = new List<PlayerData>();
            var query = "SELECT * FROM Players WHERE TeamId = @TeamId";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@TeamId", SqlDbType.SmallInt).Value = teamId;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var playerData = new PlayerData
                        {
                            PlayerId = (short)reader["PlayerId"],
                            FirstName = (string)reader["FirstName"],
                            SecondName = (string)reader["SecondName"],
                            AddressId = reader["AddressId"] == DBNull.Value ? null : (short?)reader["AddressId"],
                            TeamId = reader["TeamId"] == DBNull.Value ? null : (short?)reader["TeamId"],
                            NumberOfGoals = (int)reader["NumberOfGoals"]
                        };

                        result.Add(playerData);
                    }
                }
            }

            return result;
        }
    }
}
