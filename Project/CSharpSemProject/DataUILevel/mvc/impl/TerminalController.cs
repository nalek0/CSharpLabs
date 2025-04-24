using System;

namespace DataUILevel.mvc.impl
{
    public class TerminalController : IController
    {
        private IView _view;
        private Model _model;

        public TerminalController(IView view, Model model)
        {
            _view = view;
            _model = model;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Choose command:");

                if (_model.State.AdministratorDataState == null)
                {
                    Console.WriteLine("[1] Log in");
                    Console.WriteLine("[2] Create admin");
                    Console.WriteLine("[3] Exit");

                    string userInput = Console.ReadLine();

                    if (userInput == "1") // Log in
                    {
                        Console.Write("Put nickname: ");
                        string nickname = Console.ReadLine();
                        Console.Write("Put password: ");
                        string password = Console.ReadLine();

                        _model.LogIn(nickname, password);
                    }
                    else if (userInput == "2") // Create admin
                    {
                        Console.Write("Put first name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Put last name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Put nickname: ");
                        string nickname = Console.ReadLine();
                        Console.Write("Put password: ");
                        string password = Console.ReadLine();

                        _model.CreateAdmin(firstName, lastName, nickname, password);
                    }
                    else if (userInput == "3") // Exit
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
                else
                {
                    Console.WriteLine("[1] Log out");
                    Console.WriteLine("[2] Load users");
                    Console.WriteLine("[3] Load videos");
                    Console.WriteLine("[4] Load reports");
                    Console.WriteLine("[5] Exit");

                    string userInput = Console.ReadLine();

                    if (userInput == "1") // Log out
                    {
                        _model.LogOut();
                    }
                    else if (userInput == "2") // See users
                    {
                        _model.LoadUsers();
                    }
                    else if (userInput == "3") // See videos
                    {
                        _model.LoadVideos();
                    }
                    else if (userInput == "4") // See reports
                    {
                        _model.LoadReports();
                    }
                    else if (userInput == "5") // Exit
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
            }
        }
    }
}
