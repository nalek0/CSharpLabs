using System;

namespace DataUILevel.mvc.impl
{
    public class TerminalView : IView
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

            if (state.UserDataListState == null)
            {
                Console.WriteLine("Users not loaded.");
            }
            else
            {
                foreach (var user in state.UserDataListState)
                    Console.WriteLine($"User #{user.UserId} {user.Nickname}: {user.FirstName} {user.LastName}");
            }

            if (state.VideoDataListState == null)
            {
                Console.WriteLine("Videos not loaded.");
            }
            else
            {
                foreach (var video in state.VideoDataListState)
                    Console.WriteLine($"Video #{video.VideoId}: user={video.UserId} description={video.Description}");
            }

            if (state.ReportDataListState == null)
            {
                Console.WriteLine("Reports not loaded.");
            }
            else
            {
                foreach (var report in state.ReportDataListState)
                    Console.WriteLine($"Report #{report.ReportId}: video={report.VideoId} description={report.Description} ({report.Status})");
            }
        }
    }
}
