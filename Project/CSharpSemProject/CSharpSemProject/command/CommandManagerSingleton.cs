using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSemProject.command
{
    class CommandManagerSingleton
    {
        private static CommandManagerSingleton _instance = null;

        public void Execute(IAdministratorCommand command)
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }

        public static CommandManagerSingleton GetInstance()
        {
            if (_instance == null)
                _instance = new CommandManagerSingleton();

            return _instance;
        }
    }
}
