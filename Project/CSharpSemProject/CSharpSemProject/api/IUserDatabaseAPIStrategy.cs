using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSemProject.api
{
    interface IUserDatabaseAPIStrategy
    {
        UserData GetUser(long id);
        UserData BanUser(long id);
    }
}
