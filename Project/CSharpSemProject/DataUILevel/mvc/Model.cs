using DataDomenLevel.data;
using DataDomenLevel.api;

namespace DataUILevel.mvc
{
    public class Model
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

        public void LoadUsers()
        {
            State.UserDataListState = _databaseApi.GetUsers();
        }

        public void LoadVideos()
        {
            State.VideoDataListState= _databaseApi.GetVideos();
        }

        public void LoadReports()
        {
            State.ReportDataListState = _databaseApi.GetReports();
        }
    }
}
