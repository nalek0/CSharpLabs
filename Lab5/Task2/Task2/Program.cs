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
            IAdressesAPI addressesAPI = new AddressesAPI { ConnectionString = connectionString };
            ITeamsAPI teamsAPI = new TeamsAPI { ConnectionString = connectionString };

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
            var newPlayer = playersAPI.Create("firstName", "secondName", null, null, 0);
            Console.WriteLine(newPlayer);
            
            Console.WriteLine("==== Update Player ====");
            newPlayer.NumberOfGoals = 101;
            var newAddress = addressesAPI.Create("RU", "SPb", "Street", "1", "100");
            var newTeam = teamsAPI.Create("SuperTeam", 2025);
            newPlayer.AddressId = newAddress.AddressId;
            newPlayer.TeamId = newTeam.TeamId;
            playersAPI.Update(newPlayer.PlayerId, newPlayer);

            Console.WriteLine("==== Add Player2 ====");
            var newPlayer2 = playersAPI.Create("firstName2", "secondName2", null, newTeam.TeamId, 0);
            Console.WriteLine(newPlayer2);

            Console.WriteLine("==== Add Player2 ====");
            var newPlayer3 = playersAPI.Create("firstName2", "secondName2", null, null, 0);
            Console.WriteLine(newPlayer3);

            Console.WriteLine("==== Current Players ====");
            foreach (var data2 in playersAPI.ReadAll())
            {
                Console.WriteLine(data2);

                if (data2.AddressId != null)
                {
                    Console.WriteLine("  Address = " + addressesAPI.Read(data2.AddressId ?? 0).ToString());
                }

                if (data2.TeamId != null)
                {
                    Console.WriteLine("  Team = " + teamsAPI.Read(data2.TeamId ?? 0).ToString());
                }
            }

            Console.WriteLine("==== New Team Players ====");
            foreach (var data2 in playersAPI.ReadTeamPlayers(newTeam.TeamId))
            {
                Console.WriteLine(data2);

                if (data2.AddressId != null)
                {
                    Console.WriteLine("  Address = " + addressesAPI.Read(data2.AddressId ?? 0).ToString());
                }

                if (data2.TeamId != null)
                {
                    Console.WriteLine("  Team = " + teamsAPI.Read(data2.TeamId ?? 0).ToString());
                }
            }
        }
    }
}
