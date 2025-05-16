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
            IStadiumsAPI stadiumsAPI = new StadiumsAPI { ConnectionString = connectionString };
            ITeamStadiumRelation teamStadiumRelation = new TeamStadiumRelation { ConnectionString = connectionString };

            Console.WriteLine("==== Add Stadiums ====");
            var stadium1 = stadiumsAPI.Create("Stadium 1");
            var stadium2 = stadiumsAPI.Create("Stadium 2");
            var stadium3 = stadiumsAPI.Create("Stadium 3");

            Console.WriteLine("==== Add Teams ====");
            var team1 = teamsAPI.Create("Team 1", 2030);
            var team2 = teamsAPI.Create("Team 2", 2030);

            Console.WriteLine("==== Add Team-Stadium Relations ====");
            teamStadiumRelation.Create(team1.TeamId, stadium1.StadiumId);
            teamStadiumRelation.Create(team1.TeamId, stadium2.StadiumId);
            teamStadiumRelation.Create(team2.TeamId, stadium2.StadiumId);
            teamStadiumRelation.Create(team2.TeamId, stadium3.StadiumId);

            Console.WriteLine("==== Add Players ====");
            var address1 = addressesAPI.Create("RU", "SPb", "", "1", "");
            var address2 = addressesAPI.Create("RU", "SPb", "", "2", "");
            var address3 = addressesAPI.Create("RU", "SPb", "", "3", "");
            var players1 = playersAPI.Create("Player 1", "", address1.AddressId, team1.TeamId, 0);
            var players2 = playersAPI.Create("Player 2", "", address2.AddressId, team2.TeamId, 0);
            var players3 = playersAPI.Create("Player 3", "", address3.AddressId, team2.TeamId, 0);

            Console.WriteLine("==== Team1 Players ====");

            foreach (var data2 in playersAPI.ReadTeamPlayers(team1.TeamId))
            {
                Console.WriteLine(data2);

                if (data2.AddressId != null)
                    Console.WriteLine("  Address = " + addressesAPI.Read(data2.AddressId ?? 0).ToString());
                if (data2.TeamId != null)
                    Console.WriteLine("  Team = " + teamsAPI.Read(data2.TeamId ?? 0).ToString());
            }

            Console.WriteLine("==== Team1 Stadiums ====");

            foreach (var data2 in teamStadiumRelation.ReadStadiums(team1.TeamId))
            {
                var stadiumData = stadiumsAPI.Read(data2);
                Console.WriteLine(stadiumData);
            }

            Console.WriteLine("==== Team2 Players ====");

            foreach (var data2 in playersAPI.ReadTeamPlayers(team2.TeamId))
            {
                Console.WriteLine(data2);

                if (data2.AddressId != null)
                    Console.WriteLine("  Address = " + addressesAPI.Read(data2.AddressId ?? 0).ToString());
                if (data2.TeamId != null)
                    Console.WriteLine("  Team = " + teamsAPI.Read(data2.TeamId ?? 0).ToString());
            }

            Console.WriteLine("==== Team2 Stadiums ====");

            foreach (var data2 in teamStadiumRelation.ReadStadiums(team2.TeamId))
            {
                var stadiumData = stadiumsAPI.Read(data2);
                Console.WriteLine(stadiumData);
            }
        }
    }
}
