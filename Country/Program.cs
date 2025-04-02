using System;

public class Country
{
    public string Name { get; set; }
    public long Population { get; set; }
    public double Area { get; set; }

    public Country(string name, long population, double area)
    {
        Name = name;
        Population = population;
        Area = area;
    }

    public static Country operator +(Country c1, Country c2)
    {
        return new Country(
            $"{c1.Name} и {c2.Name}",
            c1.Population + c2.Population,
            c1.Area + c2.Area 
        );
    }

    public static bool operator <(Country c1, Country c2)
    {
        if (c1.Population != c2.Population)
        {
            return c1.Population < c2.Population;
        }
        return c1.Area < c2.Area;
    }

    public static bool operator >(Country c1, Country c2)
    {
        if (c1.Population != c2.Population)
        {
            return c1.Population > c2.Population;
        }
        return c1.Area > c2.Area;
    }

    public static bool operator ==(Country c1, Country c2)
    {
        if (ReferenceEquals(c1, c2)) return true;
        if (c1 is null || c2 is null) return false;

        return c1.Population == c2.Population && c1.Area == c2.Area;
    }

    public static bool operator !=(Country c1, Country c2)
    {
        return !(c1 == c2);
    }


    public override string ToString()
    {
        return $"Название: {Name}, Население: {Population}, Площадь: {Area}";
    }
}

public static class Empire
{
    public static long RequiredPopulation { get; set; } = 300000;
    public static double RequiredArea { get; set; } = 900000;

    public static string IsAnEmpire(Country country)
    {
        if (country == null)
        {
            return "Информация о государстве отсутствует.";
        }
        if (country.Population >= RequiredPopulation && country.Area >= RequiredArea)
        {
            return "Это государство – империя";
        }
        else
        {
            return "Это не империя";
        }
    }
}

public class Example
{
    public static void Main(string[] args)
    {
        Country russia = new Country("Россия", 144000000, 17098246);
        Country usa = new Country("США", 331000000, 9833520);
        Country germany = new Country("Германия", 83000000, 357022);

        Country united = russia + germany;
        Console.WriteLine($"Объединенное государство: {united}");

        Console.WriteLine($"{russia} > {usa}: {russia > usa}");
        Console.WriteLine($"{usa} > {russia}: {usa > russia}");
        Console.WriteLine($"{germany} < {russia}: {germany < russia}"); 

        Console.WriteLine(Empire.IsAnEmpire(russia));
        Console.WriteLine(Empire.IsAnEmpire(usa)); 
        Country empire = new Country("Империя", 350000, 1000000);
        Console.WriteLine(Empire.IsAnEmpire(empire));
    }
}