using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSemProject
{
    class AdministratorData
    {
        public long UserId { get; set; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Nickname { get; }
        public string Password { get; }

        public AdministratorData(string firstName, string lastName, string nickname, string password)
        {
            this.UserId = -1;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Nickname = nickname;
            this.Password = password;
        }
    }
}
