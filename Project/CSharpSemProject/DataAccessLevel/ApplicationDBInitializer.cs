using System.Data.Entity;

namespace DataAccessLevel
{
    class ApplicationDBInitializer : DropCreateDatabaseAlways<ApplicationDBContext>
    {
        protected override void Seed(ApplicationDBContext context)
        {
            base.Seed(context);
        }
    }
}
