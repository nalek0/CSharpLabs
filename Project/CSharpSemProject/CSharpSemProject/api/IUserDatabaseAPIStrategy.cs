namespace CSharpSemProject.api
{
    interface IUserDatabaseAPIStrategy
    {
        UserData GetUser(long id);
        UserData BanUser(long id);
    }
}
