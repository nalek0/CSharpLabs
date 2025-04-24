using DataDomenLevel.data;
using DataDomenLevel.api;
using DataAccessLevel.api;
using DataUILevel.mvc;
using DataUILevel.mvc.impl;

namespace CSharpSemProject
{
    class Application
    {
        static void Main(string[] args)
        {
            DatabaseAPIFacade databaseAPI = new DatabaseAPIFacade(
                new LocalAdministratorDatabaseAPI(),
                new LocalReportDatabaseAPI(),
                new LocalUserDatabaseAPI(),
                new LocalVideoDatabaseAPI());
            Model model = new Model(databaseAPI);
            IView view = new TerminalView(model);
            IController controller = new TerminalController(view, model);

            controller.Run();
        }
    }
}
