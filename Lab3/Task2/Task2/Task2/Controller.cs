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
            int costConverted = Convert.ToInt32(cost);
            int tipsConverted = Convert.ToInt32(tips);
            _model.OnInput(costConverted, tipsConverted);
        }
    }
}
