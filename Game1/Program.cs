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

    public static bool operator <(Game game1, Game game2)
    {
        int game1Wins = 0;
        if (game1.AveragePlayers > game2.AveragePlayers) game1Wins++;
        if (game1.MaxPlayers > game2.MaxPlayers) game1Wins++;
        if (game1.Rating > game2.Rating) game1Wins++;

        return game1Wins < 2;  
    }

    public static bool operator >(Game game1, Game game2)
    {
        int game1Wins = 0;
        if (game1.AveragePlayers > game2.AveragePlayers) game1Wins++;
        if (game1.MaxPlayers > game2.MaxPlayers) game1Wins++;
        if (game1.Rating > game2.Rating) game1Wins++;

        return game1Wins > 1;
    }

    public static bool operator ==(Game game1, Game game2)
    {
        return game1.AveragePlayers == game2.AveragePlayers &&
               game1.MaxPlayers == game2.MaxPlayers &&
               game1.Rating == game2.Rating;
    }

    public static bool operator !=(Game game1, Game game2)
    {
        return !(game1 == game2);
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
        Game game3 = new Game("Game 3", 1200, 15000, 8.0);

        Console.WriteLine(game1);
        Console.WriteLine(game2);

        Console.WriteLine($"{game1.Name} > {game2.Name}: {game1 > game2}"); 
        Console.WriteLine($"{game1.Name} < {game2.Name}: {game1 < game2}"); 

        Console.WriteLine($"{game1.Name} > {game3.Name}: {game1 > game3}");
        Console.WriteLine($"{game1.Name} == {game3.Name}: {game1 == game3}");

        Console.WriteLine($"Является популярной {game1.Name}? {PopularGame.IsPopular(game1)}");
        Console.WriteLine($"Является популярной {game2.Name}? {PopularGame.IsPopular(game2)}");
    }
}