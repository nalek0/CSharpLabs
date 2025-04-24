using CSharpSemProject.mvc;
using CSharpSemProject.api;
using SemProjectUnitTesting.mocks;  
using NSubstitute;
using CSharpSemProject.data;

namespace SemProjectUnitTesting
{
    [TestClass]
    public sealed class ModelTest
    {
        [TestMethod]
        public void TestModelAdminExist()
        {
            var adminApiStub = Substitute.For<IAdministratorDatabaseAPIStrategy>();
            var admin1 = new AdministratorDataBuilder()
                .SetFirstName("FirstName#1")
                .SetLastName("LastName#1")
                .SetNickname("Nickname#1")
                .SetPassword("****")
                .Build();
            adminApiStub.GetAdministrator(0).Returns(admin1);
            adminApiStub.GetAdministrator("Nickname#1", "****").Returns(admin1);

            DatabaseAPIFacade databaseAPI = new DatabaseAPIFacade(
                adminApiStub,
                new NullReportDatabaseAPI(),
                new NullUserDatabaseAPI(),
                new NullVideoDatabaseAPI());
            Model model = new Model(databaseAPI);

            model.LogIn("Nickname#1", "****");
            Assert.AreEqual("FirstName#1", model.State.AdministratorDataState.FirstName);
            Assert.AreEqual("LastName#1", model.State.AdministratorDataState.LastName);
        }

        [TestMethod]
        public void TestModelAdminNotExist()
        {
            var adminApiStub = Substitute.For<IAdministratorDatabaseAPIStrategy>();
            var admin1 = new AdministratorDataBuilder()
                .SetFirstName("FirstName#1")
                .SetLastName("LastName#1")
                .SetNickname("Nickname#1")
                .SetPassword("****")
                .Build();
            adminApiStub.GetAdministrator(0).Returns(admin1);
            adminApiStub.GetAdministrator("Nickname#1", "****").Returns(admin1);

            DatabaseAPIFacade databaseAPI = new DatabaseAPIFacade(
                adminApiStub,
                new NullReportDatabaseAPI(),
                new NullUserDatabaseAPI(),
                new NullVideoDatabaseAPI());
            Model model = new Model(databaseAPI);

            model.LogIn("Nickname#2", "****");
            Assert.AreEqual(null, model.State.AdministratorDataState);
        }
    }
}
