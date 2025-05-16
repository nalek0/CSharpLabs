using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using Task2.data;

namespace Task2.api.impl
{
    class StadiumsAPI : IStadiumsAPI
    {
        public string ConnectionString { get; set; }
        
        public StadiumData Create(string stadiumName)
        {
            var query = "INSERT INTO Stadiums " +
                "(StadiumName) " +
                "VALUES (@StadiumName);" +
                "SET @id=SCOPE_IDENTITY()";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@StadiumName", SqlDbType.NVarChar, 10).Value = stadiumName;

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

                return new StadiumData
                {
                    StadiumId = (short) idParam.Value,
                    StadiumName = stadiumName,
                };
            }
        }

        public StadiumData Read(short stadiumId)
        {
            var query = "SELECT * FROM Stadiums WHERE StadiumId = @StadiumId";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@StadiumId", SqlDbType.SmallInt).Value = stadiumId;
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new StadiumData
                        {
                            StadiumId = (short)reader["StadiumId"],
                            StadiumName = (string)reader["StadiumName"],
                        };
                    }
                }
            }

            return null;
        }

        public void Update(short stadiumId, StadiumData stadiumData)
        {
            var query = "UPDATE Stadiums " +
                "SET StadiumName = @StadiumName, " +
                "WHERE StadiumId = @StadiumId";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@StadiumName", SqlDbType.NVarChar, 10).Value = stadiumData.StadiumName;
                command.Parameters.Add("@StadiumId", SqlDbType.SmallInt).Value = stadiumId;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(short stadiumId)
        {
            var query = "DELETE FROM Stadiums WHERE StadiumId = @StadiumId";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@StadiumId", SqlDbType.SmallInt).Value = stadiumId;
         
                command.ExecuteNonQuery();
            }
        }
    }
}
