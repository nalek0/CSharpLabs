using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.data;

namespace Task2.api.impl
{
    class TeamStadiumRelation : ITeamStadiumRelation
    {
        public string ConnectionString { get; set; }

        public void Create(short teamId, short stadiumId)
        {
            var query = "INSERT INTO Team_Stadium " +
                "(StadiumId, TeamId) " +
                "VALUES (@StadiumId, @TeamId);";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@StadiumId", SqlDbType.SmallInt).Value = stadiumId;
                command.Parameters.Add("@TeamId", SqlDbType.SmallInt).Value = teamId;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<short> ReadTeams(short stadiumId)
        {
            List<short> result = new List<short>();
            var query = "SELECT * FROM Team_Stadium WHERE StadiumId = @StadiumId";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@StadiumId", SqlDbType.SmallInt).Value = stadiumId;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add((short)reader["TeamId"]);
                    }
                }
            }

            return result;
        }
        
        public List<short> ReadStadiums(short teamId)
        {
            List<short> result = new List<short>();
            var query = "SELECT * FROM Team_Stadium WHERE TeamId = @TeamId";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@TeamId", SqlDbType.SmallInt).Value = teamId;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add((short)reader["StadiumId"]);
                    }
                }
            }

            return result;
        }
    }
}
