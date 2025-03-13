using CSharpSemProject.api;
using CSharpSemProject;

namespace SemProjectUnitTesting.mocks
{
    /// <summary>
    /// Statick administrators database api
    /// </summary>
    class AdministratorDatabaseAPIMock : IAdministratorDatabaseAPIStrategy
    {
        private List<AdministratorData> _administrators = new List<AdministratorData>()
        {
            new AdministratorData() { UserId = 1, FirstName = "FirstName#1", LastName = "LastName#1", Nickname = "Nickname#1", Password = "****" },
            new AdministratorData() { UserId = 2, FirstName = "FirstName#2", LastName = "LastName#2", Nickname = "Nickname#2", Password = "****" }
        };

        public AdministratorData GetAdministrator(long id)
        {
            AdministratorData administratorData = _administrators
                .Find((admin) => admin.UserId == id);

            return administratorData;
        }

        public AdministratorData GetAdministrator(string nickname, string password)
        {
            AdministratorData administratorData = _administrators
                .Find((admin) => admin.Nickname == nickname && admin.Password == password);

            return administratorData;
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
