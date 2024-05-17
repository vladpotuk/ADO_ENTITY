using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ADO_ENTITY
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Studio { get; set; }
        public string Style { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("GamesDb");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            SeedDatabase();

            DisplayGames();
        }

        private static void SeedDatabase()
        {
            using (var context = new GameContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var games = new[]
                {
                    new Game { Name = "Adventure Quest", Studio = "Epic Games", Style = "Adventure", ReleaseDate = new DateTime(2020, 1, 1) },
                    new Game { Name = "Battle Arena", Studio = "Infinity Ward", Style = "Action", ReleaseDate = new DateTime(2021, 5, 20) },
                    new Game { Name = "Mystery Mansion", Studio = "Ubisoft", Style = "Puzzle", ReleaseDate = new DateTime(2019, 8, 15) }
                };

                context.Games.AddRange(games);
                context.SaveChanges();
            }
        }

        private static void DisplayGames()
        {
            using (var context = new GameContext())
            {
                var allGames = context.Games.ToList();

                Console.WriteLine("List of Games:");
                foreach (var game in allGames)
                {
                    Console.WriteLine($"Name: {game.Name}, Studio: {game.Studio}, Style: {game.Style}, Release Date: {game.ReleaseDate.ToShortDateString()}");
                }
            }
        }
    }
}using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using Microsoft.EntityFrameworkCore;

namespace 
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Studio { get; set; }
        public string Style { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("GamesDb");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            SeedDatabase();

            DisplayGames();
        }

        private static void SeedDatabase()
        {
            using (var context = new GameContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var games = new[]
                {
                    new Game { Name = "Adventure Quest", Studio = "Epic Games", Style = "Adventure", ReleaseDate = new DateTime(2020, 1, 1) },
                    new Game { Name = "Battle Arena", Studio = "Infinity Ward", Style = "Action", ReleaseDate = new DateTime(2021, 5, 20) },
                    new Game { Name = "Mystery Mansion", Studio = "Ubisoft", Style = "Puzzle", ReleaseDate = new DateTime(2019, 8, 15) }
                };

                context.Games.AddRange(games);
                context.SaveChanges();
            }
        }

        private static void DisplayGames()
        {
            using (var context = new GameContext())
            {
                var allGames = context.Games.ToList();

                Console.WriteLine("List of Games:");
                foreach (var game in allGames)
                {
                    Console.WriteLine($"Name: {game.Name}, Studio: {game.Studio}, Style: {game.Style}, Release Date: {game.ReleaseDate.ToShortDateString()}");
                }
            }
        }
    }
}