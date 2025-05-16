using System;
using Task2.api;
using Task2.api.impl;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=localhost\\SQLEXPRESS;" +
                "Initial Catalog=Lab5Task2Database;" +
                "Integrated Security=True;";

            IPlayersAPI playersAPI = new PlayersAPI { ConnectionString = connectionString };

            Console.WriteLine("==== Current Players ====");
            foreach (var data2 in playersAPI.ReadAll())
            {
                Console.WriteLine(data2);
            }
            
            Console.WriteLine("==== Clean Players ====");
            foreach (var data2 in playersAPI.ReadAll())
            {
                playersAPI.Delete(data2.PlayerId);
                Console.WriteLine(data2);
            }

            Console.WriteLine("==== Current Players ====");
            foreach (var data2 in playersAPI.ReadAll())
            {
                Console.WriteLine(data2);
            }

            Console.WriteLine("==== Add Player ====");
            var newPlayer = playersAPI.Create("firstName", "secondName");
            Console.WriteLine(newPlayer);
            
            Console.WriteLine("==== Update Player ====");
            newPlayer.NumberOfGoals = 101;
            playersAPI.Update(newPlayer.PlayerId, newPlayer);

            Console.WriteLine("==== Current Players ====");
            foreach (var data2 in playersAPI.ReadAll())
            {
                Console.WriteLine(data2);
            }
        }
    }
}
