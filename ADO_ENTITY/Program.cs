using System;
using System.Linq;

namespace ADO_ENTITY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SportsContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var teams = new[]
                {
                    new SportsTeam { TeamName = "Squad A", City = "Metropolis A", Wins = 10, Losses = 5, Draws = 3 },
                    new SportsTeam { TeamName = "Squad B", City = "Metropolis B", Wins = 8, Losses = 7, Draws = 3 },
                    new SportsTeam { TeamName = "Squad C", City = "Metropolis C", Wins = 12, Losses = 4, Draws = 2 }
                };

                context.Teams.AddRange(teams);
                context.SaveChanges();

                var allTeams = context.Teams.ToList();

                foreach (var team in allTeams)
                {
                    Console.WriteLine($"Team: {team.TeamName}, City: {team.City}, Wins: {team.Wins}, Losses: {team.Losses}, Draws: {team.Draws}");
                }
            }
        }
    }
}
