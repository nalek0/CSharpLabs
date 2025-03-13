namespace CSharpSemProject.api
{
    interface IAdministratorDatabaseAPIStrategy
    {
        AdministratorData GetAdministrator(long id);
        AdministratorData GetAdministrator(string nickname, string password);
        AdministratorData CreateAdministrator(string firstName, string lastName, string nickname, string password);
        AdministratorData RemoveAdministrator(long id);
        AdministratorData EditAdministrator(long id, string firstName, string lastName, string nickname);
    }
}
