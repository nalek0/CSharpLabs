using CSharpSemProject.mvc;
using CSharpSemProject.api;
using CSharpSemProject.api.impl;
using SemProjectUnitTesting.mocks;
using NSubstitute;
using CSharpSemProject.data;

namespace SemProjectUnitTesting
{
    [TestClass]
    public sealed class APIUsageTest
    {
        [TestMethod]
        public void TestModelLogic()
        {
            var adminApiStub = Substitute.For<IAdministratorDatabaseAPIStrategy>();
            var admin1 = new AdministratorDataBuilder()
                .SetFirstName("FirstName#1")
                .SetLastName("LastName#1")
                .SetNickname("Nickname#1")
                .SetPassword("****")
                .Build();
            var admin2 = new AdministratorDataBuilder()
                .SetFirstName("FirstName#2")
                .SetLastName("LastName#2")
                .SetNickname("Nickname#2")
                .SetPassword("****")
                .Build();

            adminApiStub.GetAdministrator(0).Returns(admin1);
            adminApiStub.GetAdministrator(1).Returns(admin2);
            adminApiStub.GetAdministrator("Nickname#1", "****").Returns(admin1);
            adminApiStub.GetAdministrator("Nickname#2", "****").Returns(admin2);

            DatabaseAPIFacade databaseAPI = new DatabaseAPIFacade(
                adminApiStub,
                new NullReportDatabaseAPI(),
                new NullUserDatabaseAPI(),
                new NullVideoDatabaseAPI());
            Model model = new Model(databaseAPI);

            model.LogIn("Nickname#1", "****");
            Assert.AreEqual("FirstName#1", model.State.AdministratorDataState.FirstName);
            Assert.AreEqual("LastName#1", model.State.AdministratorDataState.LastName);
            
            model.LogOut();
            Assert.AreEqual(null, model.State.AdministratorDataState);

            model.LogIn("Nickname#2", "****");
            Assert.AreEqual("FirstName#2", model.State.AdministratorDataState.FirstName);
            Assert.AreEqual("LastName#2", model.State.AdministratorDataState.LastName);

            model.LogOut();
            Assert.AreEqual(null, model.State.AdministratorDataState);

            model.LogIn("Nickname#3", "****");
            Assert.AreEqual(null, model.State.AdministratorDataState);
        }
    }
}
