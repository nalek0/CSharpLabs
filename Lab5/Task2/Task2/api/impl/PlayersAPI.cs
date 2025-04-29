using System;
using System.Data;
using System.Data.SqlClient;
using Task2.data;

namespace Task2.api.impl
{
    class PlayersAPI : IPlayersAPI
    {
        public string ConnectionString { get; set; }

        public PlayerData Create(string firstName, string secondName)
        {
            var query = "INSERT INTO Players " +
                "(FirstName, SecondName, NumberOfGoals) " +
                "VALUES (@FirstName, @SecondName, @NumberOfGoals);" +
                "SET @id=SCOPE_IDENTITY()";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = firstName;
                command.Parameters.Add("@SecondName", SqlDbType.NVarChar, 50).Value = secondName;
                command.Parameters.Add("@NumberOfGoals", SqlDbType.SmallInt).Value = 0;

                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output // параметр выходной
                };
                command.Parameters.Add(idParam);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                return new PlayerData
                {
                    PlayerId = (int)idParam.Value,
                    FirstName = firstName,
                    SecondName = secondName,
                    Address = null,
                    Team = null,
                    NumberOfGoals = 0
                };
            }
        }

        public void Delete(int playerId)
        {
            throw new NotImplementedException();
        }

        public PlayerData Read(int playerId)
        {
            throw new NotImplementedException();
        }

        public void Update(int playerId, PlayerData playerData)
        {
            throw new NotImplementedException();
        }
    }
}
