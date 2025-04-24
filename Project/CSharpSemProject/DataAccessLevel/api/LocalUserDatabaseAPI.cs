using DataDomenLevel.data;
using DataDomenLevel.api;
using System;
using System.Collections.Generic;

namespace DataAccessLevel.api
{
    public class LocalUserDatabaseAPI : IUserDatabaseAPIStrategy
    {
        private List<UserData> _users = new List<UserData>()
        {
            new UserData() { UserId = 1, FirstName = "Name#1", LastName = "Surname#1", Nickname = "Amogus" },
            new UserData() { UserId = 2, FirstName = "Name#2", LastName = "Surname#2", Nickname = "Sugoma" },
        };

        public UserData GetUser(long id)
        {
            throw new NotImplementedException();
        }
        
        public UserData BanUser(long id)
        {
            throw new NotImplementedException();
        }

        public List<UserData> GetUsers()
        {
            return _users;
        }
    }
}
