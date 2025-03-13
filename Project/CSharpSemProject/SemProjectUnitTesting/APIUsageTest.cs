using CSharpSemProject.mvc;
using CSharpSemProject.api;
using CSharpSemProject.api.impl;
using SemProjectUnitTesting.mocks;

namespace SemProjectUnitTesting
{
    [TestClass]
    public sealed class APIUsageTest
    {
        [TestMethod]
        public void TestAdministratorAPI()
        {
            DatabaseAPIFacade databaseAPI = new DatabaseAPIFacade(
                new AdministratorDatabaseAPIMock(),
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
