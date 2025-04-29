using DataDomenLevel.data;
using DataDomenLevel.api;
using DataAccessLevel.api;
using DataUILevel.mvc;
using DataUILevel.mvc.impl;
using Autofac;

namespace CSharpSemProject
{
    class Application
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<NullAdministratorDatabaseAPI>()
                .As<IAdministratorDatabaseAPIStrategy>()
                .SingleInstance();

            builder.RegisterType<DatabaseAPIFacade>()
                .As<IDatabaseAPIFacade>()
                .InstancePerLifetimeScope();

            builder.RegisterType<NullReportDatabaseAPI>()
                .As<IReportDatabaseAPIStrategy>();
            builder.RegisterType<NullUserDatabaseAPI>()
                .As<IUserDatabaseAPIStrategy>();
            builder.RegisterType<NullVideoDatabaseAPI>()
                .As<IVideoDatabaseAPIStrategy>();

            var container = builder.Build();
            var scope = container.BeginLifetimeScope();

            Model model = new Model();
            model.DatabaseAPI = scope.Resolve<IDatabaseAPIFacade>();
            
            IView view = new TerminalView(model);
            IController controller = new TerminalController(view, model);

            controller.Run();
        }
    }
}
