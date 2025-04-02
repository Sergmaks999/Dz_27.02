using System;

public class Post
{
    public int Id { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public string Message { get; set; }

    public Post(int id, int likes, int dislikes, string message)
    {
        Id = id;
        Likes = likes;
        Dislikes = dislikes;
        Message = message;
    }

    // Перегрузка оператора + (увеличение лайков)
    public static Post operator +(Post post, int likesToAdd)
    {
        post.Likes += likesToAdd;
        return post;
    }

    // Перегрузка оператора - (увеличение дизлайков)
    public static Post operator -(Post post, int dislikesToAdd)
    {
        post.Dislikes += dislikesToAdd;
        return post;
    }

    // Перегрузка оператора ++ (увеличение лайков на 1)
    public static Post operator ++(Post post)
    {
        post.Likes++;
        return post;
    }

    // Перегрузка оператора -- (увеличение дизлайков на 1)
    public static Post operator --(Post post)
    {
        post.Dislikes++;
        return post;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Лайки: {Likes}, Дизлайки: {Dislikes}, Сообщение: {Message}";
    }
}

public static class Recommendations
{
    public static bool IsRecommended(Post post)
    {
        if (post == null)
        {
            return false; // Или throw new ArgumentNullException(nameof(post));
        }

        return post.Likes >= post.Dislikes * 2;
    }
}

public class Example
{
    public static void Main(string[] args)
    {
        Post post1 = new Post(1, 100, 20, "Отличный пост!");
        Post post2 = new Post(2, 50, 30, "Интересная новость.");

        Console.WriteLine(post1);
        Console.WriteLine($"Рекомендовать? {Recommendations.IsRecommended(post1)}"); // True

        Console.WriteLine(post2);
        Console.WriteLine($"Рекомендовать? {Recommendations.IsRecommended(post2)}"); // False

        post1 = post1 + 50; // Добавляем 50 лайков
        Console.WriteLine(post1);

        post2 = post2 - 10; // Добавляем 10 дизлайков
        Console.WriteLine(post2);

        post1++; // Увеличиваем лайки на 1
        Console.WriteLine(post1);

        post2--; // Увеличиваем дизлайки на 1
        Console.WriteLine(post2);

        Console.WriteLine($"Рекомендовать {post1.Id}? {Recommendations.IsRecommended(post1)}"); // True
        Console.WriteLine($"Рекомендовать {post2.Id}? {Recommendations.IsRecommended(post2)}"); // False
    }
}