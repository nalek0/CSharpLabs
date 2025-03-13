using CSharpSemProject.api;

namespace CSharpSemProject.mvc
{

    class Model
    {
        private DatabaseAPIFacade _databaseApi;
        
        public ModelState State { get; }

        public Model(DatabaseAPIFacade databaseApi)
        {
            _databaseApi = databaseApi;
            State = new ModelState();
        }

        public void LogIn(string nickname, string password)
        {
            AdministratorData newAdministrator = _databaseApi.GetAdministrator(nickname, password);
            State.AdministratorDataState = newAdministrator;
        }

        public void CreateAdmin(string firstName, string lastName, string nickname, string password)
        {
            AdministratorData newAdministrator = _databaseApi.CreateAdministrator(firstName, lastName, nickname, password);
            State.AdministratorDataState = newAdministrator;
        }

        public void LogOut()
        {
            State.AdministratorDataState = null;
        }
    }
}
