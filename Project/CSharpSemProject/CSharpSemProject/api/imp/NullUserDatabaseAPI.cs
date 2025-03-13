using CSharpSemProject;
using CSharpSemProject.api;
using System;
using System.Collections.Generic;

namespace SemProjectUnitTesting.mocks
{
    public class NullUserDatabaseAPI : IUserDatabaseAPIStrategy
    {
        public UserData BanUser(long id)
        {
            throw new NotImplementedException();
        }

        public UserData GetUser(long id)
        {
            throw new NotImplementedException();
        }

        public List<UserData> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
