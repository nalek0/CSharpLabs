using DataDomenLevel.data;
using System.Collections.Generic;

namespace DataDomenLevel.api
{
    public interface IAdministratorDatabaseAPIStrategy
    {
        List<AdministratorData> GetAdministrators();
        AdministratorData GetAdministrator(int id);
        AdministratorData GetAdministrator(string nickname, string password);
        AdministratorData CreateAdministrator(string firstName, string lastName, string nickname, string password);
        AdministratorData RemoveAdministrator(int id);
        AdministratorData EditAdministrator(int id, string firstName, string lastName, string nickname);
    }
}
