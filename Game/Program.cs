using System;

public class Game
{
    public string Name { get; set; }
    public int AveragePlayers { get; set; }
    public int MaxPlayers { get; set; }
    public double Rating { get; set; }

    public Game(string name, int averagePlayers, int maxPlayers, double rating)
    {
        Name = name;
        AveragePlayers = averagePlayers;
        MaxPlayers = maxPlayers;
        Rating = rating;
    }

    public static Game operator ++(Game game)
    {
        game.Rating += 0.1;
        if (game.Rating > 10)
        {
            game.Rating = 10;
        }
        return game;
    }

    public static Game operator --(Game game)
    {
        game.Rating -= 0.1;
        if (game.Rating < 0)
        {
            game.Rating = 0;
        }
        return game;
    }

    public override string ToString()
    {
        return $"Название: {Name}, Среднее кол-во игроков: {AveragePlayers}, Макс. кол-во игроков: {MaxPlayers}, Рейтинг: {Rating}";
    }
}

public static class PopularGame
{
    public static double RequiredRating { get; set; } = 8.5;
    public static int RequiredAveragePlayers { get; set; } = 1000;
    public static int RequiredMaxPlayers { get; set; } = 10000;

    public static bool IsPopular(Game game)
    {
        if (game == null)
        {
            return false;
        }
        return game.Rating >= RequiredRating &&
               game.AveragePlayers >= RequiredAveragePlayers &&
               game.MaxPlayers >= RequiredMaxPlayers;
    }
}

public class Example
{
    public static void Main(string[] args)
    {
        Game game1 = new Game("Game 1", 1200, 15000, 8.7);
        Game game2 = new Game("Game 2", 800, 9000, 7.5);
        Game game3 = new Game("Game 3", 1000, 10000, 8.5);


        Console.WriteLine(game1);
        Console.WriteLine($"Популярна? {PopularGame.IsPopular(game1)}");

        Console.WriteLine(game2);
        Console.WriteLine($"Популярна? {PopularGame.IsPopular(game2)}");

        Console.WriteLine(game3);
        Console.WriteLine($"Популярна? {PopularGame.IsPopular(game3)}");

        game3++;
        Console.WriteLine(game3);

        game3--;
        game3--;
        Console.WriteLine(game3);
    }
}