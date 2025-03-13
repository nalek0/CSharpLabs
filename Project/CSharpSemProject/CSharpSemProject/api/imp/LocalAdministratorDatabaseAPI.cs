using CSharpSemProject.data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpSemProject.api.impl
{
    class LocalAdministratorDatabaseAPI : IAdministratorDatabaseAPIStrategy
    {
        private List<AdministratorData> _administrators;

        public LocalAdministratorDatabaseAPI()
        {
            _administrators = new List<AdministratorData>();
        }

        public AdministratorData GetAdministrator(long id)
        {
            AdministratorData administratorData = _administrators.Where((admin) => admin.UserId == id).FirstOrDefault(null);


            if (administratorData != null)
            {
                return administratorData;
            } 
            else
            {
                throw new DatabaseApiException("No administrator found.");
            }
        }

        public AdministratorData GetAdministrator(string nickname, string password)
        {
            AdministratorData administratorData = _administrators
                .Where((admin) => admin.Nickname == nickname && admin.Password == password)
                .First();

            if (administratorData != null)
            {
                return administratorData;
            }
            else
            {
                throw new DatabaseApiException("No administrator found.");
            }
        }

        public AdministratorData CreateAdministrator(string firstName, string lastName, string nickname, string password)
        {
            AdministratorData administratorData = new AdministratorDataBuilder()
                .SetFirstName(firstName)
                .SetLastName(lastName)
                .SetNickname(nickname)
                .SetPassword(password)
                .Build();
            administratorData.UserId = _administrators.Count;
            _administrators.Add(administratorData);

            return administratorData;
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
