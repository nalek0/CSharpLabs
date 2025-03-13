using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Controller
    {
        private Model _model;

        public Controller(Model model)
        {
            _model = model;
        }

        public void OnInput(string cost, string tips)
        {
            int costConverted, tipsConverted;

            try
            {
                costConverted = Convert.ToInt32(cost);
            }
            catch (FormatException)
            {
                throw new ControllerException("Invalid cost format.");
            }

            try
            {
                tipsConverted = Convert.ToInt32(tips);
            }
            catch (FormatException)
            {
                throw new ControllerException("Invalid cost format.");
            }

            _model.OnInput(costConverted, tipsConverted);
        }
    }

    public class ControllerException : Exception
    {
        public ControllerException() { }
        public ControllerException(string message) : base(message) { }
        public ControllerException(string message, Exception inner) : base(message, inner) { }
    }
}
