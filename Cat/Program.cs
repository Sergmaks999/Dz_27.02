using System;

public class Cat
{
    public string Name { get; set; }
    public string Breed { get; set; }
    public DateTime DateOfBirth { get; set; }
    public double Weight { get; set; }

    public Cat(string name, string breed, DateTime dateOfBirth, double weight)
    {
        Name = name;
        Breed = breed;
        DateOfBirth = dateOfBirth;
        Weight = weight;
    }
    public static bool operator <(Cat c1, Cat c2)
    {
        return c1.Weight < c2.Weight;
    }

    public static bool operator >(Cat c1, Cat c2)
    {
        return c1.Weight > c2.Weight;
    }

    public static bool operator ==(Cat c1, Cat c2)
    {
        if (ReferenceEquals(c1, c2)) return true;
        if (c1 is null || c2 is null) return false;
        return c1.Name == c2.Name && c1.Breed == c2.Breed && c1.DateOfBirth == c2.DateOfBirth && c1.Weight == c2.Weight;
    }

    public static bool operator !=(Cat c1, Cat c2)
    {
        return !(c1 == c2);
    }


    public static string operator *(Cat c1, Cat c2)
    {
        if (c1.Breed == c2.Breed)
        {
            return "селекция возможна";
        }
        else
        {
            return "селекция невозможна";
        }
    }

    public override string ToString()
    {
        return $"Кличка: {Name}, Порода: {Breed}, Дата рождения: {DateOfBirth.ToShortDateString()}, Вес: {Weight} кг";
    }
}

public static class WeightStandards
{
    public static double SmallWeight { get; set; } = 1;
    public static double MediumWeight { get; set; } = 3;
    public static double LargeWeight { get; set; } = 5;

    public static string GetWeightStatus(Cat cat)
    {
        if (cat == null)
        {
            return "Информация о котике отсутствует.";
        }

        if (cat.Weight < SmallWeight)
        {
            return "Котика очень худой";
        }
        else if (cat.Weight >= SmallWeight && cat.Weight < MediumWeight)
        {
            return "Котик худой";
        }
        else if (cat.Weight >= MediumWeight && cat.Weight < LargeWeight)
        {
            return "Котик полноват";
        }
        else
        {
            return "Котик полный";
        }
    }
}

public class Example
{
    public static void Main(string[] args)
    {
        Cat cat1 = new Cat("Мурзик", "Сиамская", DateTime.Parse("2022-05-10"), 2.8);
        Cat cat2 = new Cat("Васька", "Британская", DateTime.Parse("2023-11-20"), 4.0);
        Cat cat3 = new Cat("Снежок", "Сиамская", DateTime.Parse("2023-03-15"), 5.5);
        Cat cat4 = new Cat("Рыжик", "Персидская", DateTime.Parse("2023-03-15"), 0.8);

        Console.WriteLine($"{cat1.Name} > {cat2.Name}: {cat1 > cat2}");
        Console.WriteLine($"{cat2.Name} < {cat3.Name}: {cat2 < cat3}");

        Console.WriteLine($"{cat1} * {cat3}: {cat1 * cat3}");
        Console.WriteLine($"{cat1} * {cat2}: {cat1 * cat2}");

        Console.WriteLine(WeightStandards.GetWeightStatus(cat1)); 
        Console.WriteLine(WeightStandards.GetWeightStatus(cat2));
        Console.WriteLine(WeightStandards.GetWeightStatus(cat3)); 
        Console.WriteLine(WeightStandards.GetWeightStatus(cat4));
    }
}