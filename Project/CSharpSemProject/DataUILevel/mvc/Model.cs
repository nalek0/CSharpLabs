using DataDomenLevel.data;
using DataDomenLevel.api;
using System;

namespace DataUILevel.mvc
{
    public class Model
    {
        public IDatabaseAPIFacade DatabaseAPI { get; set; }

        public ModelState State { get; }

        public Model()
        {
            State = new ModelState();
        }

        public void SetDatabaseAPI(IDatabaseAPIFacade databaseApi)
        {
            DatabaseAPI = databaseApi;
        }

        public void LogIn(string nickname, string password)
        {
            AdministratorData newAdministrator = DatabaseAPI.GetAdministrator(nickname, password);
            State.AdministratorDataState = newAdministrator;
        }

        public void CreateAdmin(string firstName, string lastName, string nickname, string password)
        {
            AdministratorData newAdministrator = DatabaseAPI.CreateAdministrator(firstName, lastName, nickname, password);
            State.AdministratorDataState = newAdministrator;
        }

        public void LogOut()
        {
            State.AdministratorDataState = null;
        }

        public void LoadUsers()
        {
            State.UserDataListState = DatabaseAPI.GetUsers();
        }

        public void LoadVideos()
        {
            State.VideoDataListState= DatabaseAPI.GetVideos();
        }

        public void LoadReports()
        {
            State.ReportDataListState = DatabaseAPI.GetReports();
        }
    }
}
