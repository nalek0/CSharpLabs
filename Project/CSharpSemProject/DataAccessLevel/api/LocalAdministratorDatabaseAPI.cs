using DataDomenLevel.data;
using DataDomenLevel.api;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLevel.api
{
    /// <summary>
    /// Test administrator API strategy, that stores administrator data locally
    /// </summary>
    public class LocalAdministratorDatabaseAPI : IAdministratorDatabaseAPIStrategy
    {
        private List<AdministratorData> _administrators;

        public LocalAdministratorDatabaseAPI()
        {
            _administrators = new List<AdministratorData>();
        }

        public List<AdministratorData> GetAdministrators()
        {
            return _administrators;
        }

        public AdministratorData GetAdministrator(int id)
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
            AdministratorData administratorData = new AdministratorData()
            {
                UserId = 1,
                FirstName = firstName,
                LastName = lastName,
                Nickname = nickname,
                Password = password,
            };
            administratorData.UserId = _administrators.Count;
            _administrators.Add(administratorData);

            return administratorData;
        }
        
        public AdministratorData RemoveAdministrator(int id)
        {
            AdministratorData administratorData = GetAdministrator(id);

            if (administratorData != null)
                _administrators.Remove(administratorData);

            return administratorData;
        }

        public AdministratorData EditAdministrator(int id, string firstName, string lastName, string nickname)
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
