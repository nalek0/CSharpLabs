using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSemProject.api
{
    interface IAdministratorDatabaseAPIStrategy
    {
        AdministratorData GetAdministrator(long id);
        AdministratorData CreateAdministrator(string firstName, string lastName, string nickname);
        AdministratorData RemoveAdministrator(long id);
        AdministratorData EditAdministrator(long id, string firstName, string lastName, string nickname);
    }
}
