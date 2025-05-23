using DataDomenLevel.data;
using DataDomenLevel.api;
using System;
using System.Collections.Generic;

namespace DataAccessLevel.api
{
    public class NullAdministratorDatabaseAPI : IAdministratorDatabaseAPIStrategy
    {
        public List<AdministratorData> GetAdministrators()
        {
            throw new NotImplementedException();
        }

        public AdministratorData GetAdministrator(int id)
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

        public AdministratorData RemoveAdministrator(int id)
        {
            throw new NotImplementedException();
        }

        public AdministratorData EditAdministrator(int id, string firstName, string lastName, string nickname)
        {
            throw new NotImplementedException();
        }
    }
}
