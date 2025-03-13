using CSharpSemProject.data;
using System.Collections.Generic;
using System.Linq;

namespace CSharpSemProject.api.impl
{
    /// <summary>
    /// Test administrator API strategy, that stores administrator data locally
    /// </summary>
    class LocalAdministratorDatabaseAPI : IAdministratorDatabaseAPIStrategy
    {
        private List<AdministratorData> _administrators;

        public LocalAdministratorDatabaseAPI()
        {
            _administrators = new List<AdministratorData>();
        }

        public AdministratorData GetAdministrator(long id)
        {
            AdministratorData administratorData = _administrators
                .Where((admin) => admin.UserId == id)
                .FirstOrDefault(null);

            return administratorData;
        }

        public AdministratorData GetAdministrator(string nickname, string password)
        {
            AdministratorData administratorData = _administrators
                .Where((admin) => admin.Nickname == nickname && admin.Password == password)
                .First();

            return administratorData;
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
            AdministratorData administratorData = GetAdministrator(id);

            if (administratorData != null)
                _administrators.Remove(administratorData);

            return administratorData;
        }

        public AdministratorData EditAdministrator(long id, string firstName, string lastName, string nickname)
        {
            AdministratorData administratorData = GetAdministrator(id);

            if (administratorData == null)
                return null;

            administratorData.FirstName = firstName;
            administratorData.LastName = firstName;
            administratorData.Nickname = firstName;

            return administratorData;
        }
    }
}
