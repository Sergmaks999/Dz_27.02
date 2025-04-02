using System;

public class Person
{
    public string FIO { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public string EyeColor { get; set; }

    public Person(string fio, string gender, int age, string eyeColor)
    {
        FIO = fio;
        Gender = gender;
        Age = age;
        EyeColor = eyeColor;
    }

    public static string operator +(Person p1, Person p2)
    {
        string color1 = p1.EyeColor.ToLower();
        string color2 = p2.EyeColor.ToLower();

        if (color1 == "карие" && color2 == "карие")
        {
            return "Карие";
        }
        else 
        
        if ((color1 == "зеленые" && color2 == "карие") || (color2 == "зеленые" && color1 == "карие"))
        {
            return "Карие";
        }
        else if ((color1 == "голубые" && color2 == "карие") || (color2 == "голубые" && color1 == "карие"))
        {
            return "Карие";
        }
        else 
        
        if (color1 == "зеленые" && color2 == "зеленые")
        {
            return "Зеленые";
        }
        else 
        
        if ((color1 == "зеленые" && color2 == "голубые") || (color2 == "зеленые" && color1 == "голубые"))
        {
            return "Голубые";
        }
        else 
        
        if (color1 == "голубые" && color2 == "голубые")
        {
            return "Голубые";
        }
        else
        {
            return "Невозможно определить цвет глаз";
        }
    }

    public override string ToString()
    {
        return $"ФИО: {FIO}, Пол: {Gender}, Возраст: {Age}, Цвет глаз: {EyeColor}";
    }
}

public static class WorkingCapacity
{
    public static int MinimumAge { get; set; } = 18;
    public static int MaximumAge { get; set; } = 70;

    public static bool IsWorkable(Person person)
    {
        if (person == null)
        {
            return false;
        }
        return person.Age >= MinimumAge && person.Age <= MaximumAge;
    }
}

public class Example
{
    public static void Main(string[] args)
    {
        Person p1 = new Person("Иванов Иван Иванович", "Мужской", 30, "Карие");
        Person p2 = new Person("Петрова Анна Сергеевна", "Женский", 25, "Зеленые");
        Person p3 = new Person("Сидоров Петр Петрович", "Мужской", 15, "Голубые");
        Person p4 = new Person("Козлов Алексей Викторович", "Мужской", 75, "Карие");

        string childEyeColor = p1 + p2;

        Console.WriteLine($"Работоспособен {p1.FIO}? {WorkingCapacity.IsWorkable(p1)}");
        Console.WriteLine($"Работоспособен {p3.FIO}? {WorkingCapacity.IsWorkable(p3)}");
        Console.WriteLine($"Работоспособен {p4.FIO}? {WorkingCapacity.IsWorkable(p4)}");
    }
}