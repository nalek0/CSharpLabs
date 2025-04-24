using DataDomenLevel.data;
using System.Collections.Generic;

namespace DataDomenLevel.api
{
    public interface IUserDatabaseAPIStrategy
    {
        UserData GetUser(long id);
        UserData BanUser(long id);
        List<UserData> GetUsers();
    }
}
