using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using Task2.data;

namespace Task2.api.impl
{
    class AddressesAPI : IAdressesAPI
    {
        public string ConnectionString { get; set; }
        
        public AddressData Create(string country, string city, string street, string building, string apartment)
        {
            var query = "INSERT INTO Addresses " +
                "(Country, City, Street, Building, Apartment) " +
                "VALUES (@Country, @City, @Street, @Building, @Apartment);" +
                "SET @id=SCOPE_IDENTITY()";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@Country", SqlDbType.NVarChar, 10).Value = country;
                command.Parameters.Add("@City", SqlDbType.NVarChar, 10).Value = city;
                command.Parameters.Add("@Street", SqlDbType.NVarChar, 10).Value = street;
                command.Parameters.Add("@Building", SqlDbType.NVarChar, 10).Value = building;
                command.Parameters.Add("@Apartment", SqlDbType.NVarChar, 10).Value = apartment;

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

                return new AddressData
                {
                    AddressId = (short) (int) idParam.Value,
                    Country = country,
                    City = city,
                    Street = street,
                    Building = building,
                    Apartment = apartment
                };
            }
        }

        public AddressData Read(short addressId)
        {
            var query = "SELECT * FROM Addresses WHERE AddressId = @AddressId";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@AddressId", SqlDbType.SmallInt).Value = addressId;
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var addressData = new AddressData
                        {
                            AddressId = (short)reader["AddressId"],
                            Country = (string)reader["Country"],
                            City = (string)reader["City"],
                            Street = (string)reader["Street"],
                            Building = (string)reader["Building"],
                            Apartment = (string)reader["Apartment"],
                        };

                        return addressData;
                    }
                }
            }

            return null;
        }

        public void Update(short addressId, AddressData addressData)
        {
            var query = "UPDATE Addresses " +
                "SET Country = @Country, " +
                "City = @City, " +
                "Street = @Street, " +
                "Building = @Building, " +
                "Apartment = @Apartment " +
                "WHERE AddressId = @AddressId";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@Country", SqlDbType.NVarChar, 10).Value = addressData.Country;
                command.Parameters.Add("@City", SqlDbType.NVarChar, 10).Value = addressData.City;
                command.Parameters.Add("@Street", SqlDbType.NVarChar, 10).Value = addressData.Street;
                command.Parameters.Add("@Building", SqlDbType.NVarChar, 10).Value = addressData.Building;
                command.Parameters.Add("@Apartment", SqlDbType.NVarChar, 10).Value = addressData.Apartment;
                command.Parameters.Add("@AddressId", SqlDbType.SmallInt).Value = addressId;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(short addressId)
        {
            var query = "DELETE FROM Addresses WHERE AddressId = @AddressId";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@AddressId", SqlDbType.SmallInt).Value = addressId;
         
                command.ExecuteNonQuery();
            }
        }
    }
}
