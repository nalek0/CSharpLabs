using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSemProject.mvc
{
    class TerminalView : IView
    {
        private Model _model;

        public TerminalView(Model model)
        {
            _model = model;
            _model.State.UpdateEvent += this.OnUpdate;
        }

        public void OnUpdate(ModelState state)
        {
            if (state.AdministratorDataState == null)
            {
                Console.WriteLine("Not logined yet.");
            }
            else
            {
                Console.WriteLine($"Logined: {state.AdministratorDataState.Nickname}, {state.AdministratorDataState.FirstName} {state.AdministratorDataState.LastName}");
            }
        }
    }
}
