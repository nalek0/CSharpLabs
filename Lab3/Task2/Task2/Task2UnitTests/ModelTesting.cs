using Task2;

namespace Task2UnitTests
{
    [TestClass]
    public sealed class ModelTesting
    {
        [TestMethod]
        public void TestExample()
        {
            Model model = new Model();
            Controller controller = new Controller(model);
            model.OnFeeback += (feedback) => Assert.AreEqual(132, feedback.TotalSum);
            controller.OnInput("120", "10");
        }

        [TestMethod]
        [ExpectedException(typeof(ControllerException), "Controller should fail on invalid input.")]
        public void TestInvalidCostFormat()
        {
            Model model = new Model();
            Controller controller = new Controller(model);
            model.OnFeeback += (feedback) => { };
            controller.OnInput("120.5", "10");
        }

        [TestMethod]
        [ExpectedException(typeof(ControllerException), "Controller should fail on invalid input.")]
        public void TestInvalidTipsFormat()
        {
            Model model = new Model();
            Controller controller = new Controller(model);
            model.OnFeeback += (feedback) => { };
            controller.OnInput("120", "Null");
        }

        [TestMethod]
        [ExpectedException(typeof(ModelException), "Model should fail on invalid input.")]
        public void TestNegativeCost()
        {
            Model model = new Model();
            Controller controller = new Controller(model);
            model.OnFeeback += (feedback) => { };
            controller.OnInput("-120", "10");
        }

        [TestMethod]
        [ExpectedException(typeof(ModelException), "Model should fail on invalid input.")]
        public void TestNegativeTips()
        {
            Model model = new Model();
            Controller controller = new Controller(model);
            model.OnFeeback += (feedback) => { };
            controller.OnInput("120", "-10");
        }

        [TestMethod]
        [ExpectedException(typeof(ModelException), "Model should fail on invalid input.")]
        public void TestTooBigTips()
        {
            Model model = new Model();
            Controller controller = new Controller(model);
            model.OnFeeback += (feedback) => { };
            controller.OnInput("120", "110");
        }
    }
}
