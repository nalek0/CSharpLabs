using System.Collections.Generic;

namespace CSharpSemProject.api
{
    public interface IUserDatabaseAPIStrategy
    {
        UserData GetUser(long id);
        UserData BanUser(long id);
        List<UserData> GetUsers();
    }
}
