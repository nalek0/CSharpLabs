using Task2;

namespace Task2UnitTests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Model model = new Model();
            Controller controller = new Controller(model);
            model.OnFeeback += (feedback) => Assert.AreEqual(132, feedback.TotalSum);
            controller.OnInput("120", "10");
        }
    }
}
