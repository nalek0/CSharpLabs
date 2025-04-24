using DataDomenLevel.data;
using DataDomenLevel.api;
using System;

namespace DataAccessLevel.api
{
    public class NullAdministratorDatabaseAPI : IAdministratorDatabaseAPIStrategy
    {
        public AdministratorData GetAdministrator(long id)
        {
            throw new NotImplementedException();
        }

        public AdministratorData GetAdministrator(string nickname, string password)
        {
            throw new NotImplementedException();
        }

        public AdministratorData CreateAdministrator(string firstName, string lastName, string nickname, string password)
        {
            throw new NotImplementedException();
        }

        public AdministratorData RemoveAdministrator(long id)
        {
            throw new NotImplementedException();
        }

        public AdministratorData EditAdministrator(long id, string firstName, string lastName, string nickname)
        {
            throw new NotImplementedException();
        }
    }
}
