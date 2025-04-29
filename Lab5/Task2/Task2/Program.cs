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
            var data = playersAPI.Create("Hello", "world");
            Console.WriteLine("==== Added player ====");
            Console.WriteLine(data);
            
            Console.WriteLine("==== Current Players ====");
            foreach (var data2 in playersAPI.ReadAll())
            {
                Console.WriteLine(data2);
            }
        }
    }
}
