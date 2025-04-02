using System;

public class Ingredient
{
    public string Name { get; set; }
    public string Effect { get; set; }
    public double Price { get; set; }

    public Ingredient(string name, string effect, double price)
    {
        Name = name;
        Effect = effect;
        Price = price;
    }

    public static bool operator <(Ingredient i1, Ingredient i2)
    {
        return i1.Price < i2.Price;
    }

    public static bool operator >(Ingredient i1, Ingredient i2)
    {
        return i1.Price > i2.Price;
    }

    public static bool operator ==(Ingredient i1, Ingredient i2)
    {
        if (ReferenceEquals(i1, i2)) return true;
        if (i1 is null || i2 is null) return false;
        return i1.Price == i2.Price;
    }

    public static bool operator !=(Ingredient i1, Ingredient i2)
    {
        return !(i1 == i2);
    }

    public static Ingredient operator +(Ingredient i1, Ingredient i2)
    {
        return new Ingredient(
            "Зелье",
            $"{i1.Effect}, {i2.Effect}",
            (i1.Price + i2.Price) * 3 
        );
    }

    public override string ToString()
    {
        return $"Название: {Name}, Эффект: {Effect}, Цена: {Price}";
    }
}

public static class PriceCategory
{
    public static double LowPrice { get; set; } = 100;
    public static double MediumPrice { get; set; } = 500;
    public static double HighPrice { get; set; } = 1500;

    public static string GetPriceStatus(Ingredient ingredient)
    {
        if (ingredient == null)
        {
            return "Информация об ингредиенте отсутствует.";
        }

        if (ingredient.Price < LowPrice)
        {
            return "Цена очень низкая";
        }
        else if (ingredient.Price >= LowPrice && ingredient.Price < MediumPrice)
        {
            return "Цена низкая";
        }
        else if (ingredient.Price >= MediumPrice && ingredient.Price < HighPrice)
        {
            return "Цена завышена";
        }
        else
        {
            return "Цена слишком высокая";
        }
    }
}

public class Example
{
    public static void Main(string[] args)
    {
        Ingredient ingredient1 = new Ingredient("Корень мандрагоры", "Придает силы", 80);
        Ingredient ingredient2 = new Ingredient("Слезы единорога", "Лечит", 1200);
        Ingredient ingredient3 = new Ingredient("Жабры", "Дыхание под водой", 300);

        Console.WriteLine($"{ingredient1} > {ingredient2}: {ingredient1 > ingredient2}");
        Console.WriteLine($"{ingredient2} > {ingredient3}: {ingredient2 > ingredient3}");

        Ingredient potion = ingredient1 + ingredient2;
        Console.WriteLine($"Полученное зелье: {potion}");

        Console.WriteLine(PriceCategory.GetPriceStatus(ingredient1));
        Console.WriteLine(PriceCategory.GetPriceStatus(ingredient2)); 
        Console.WriteLine(PriceCategory.GetPriceStatus(ingredient3)); 
    }
}