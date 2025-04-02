using System;
using System.Globalization;

public class Abiturient
{
    public string FIO { get; set; }
    public double AverageGrade { get; set; }
    public double PersonalAchievements { get; set; }
    public DateTime ApplicationDate { get; set; }

    public Abiturient(string fio, double averageGrade, double personalAchievements, DateTime applicationDate)
    {
        FIO = fio;
        AverageGrade = averageGrade;
        PersonalAchievements = personalAchievements;
        ApplicationDate = applicationDate;
    }

    public static bool operator <(Abiturient a1, Abiturient a2)
    {
        if (a1.AverageGrade != a2.AverageGrade)
        {
            return a1.AverageGrade < a2.AverageGrade;
        }
        return a1.PersonalAchievements < a2.PersonalAchievements;
    }

    public static bool operator >(Abiturient a1, Abiturient a2)
    {
        if (a1.AverageGrade != a2.AverageGrade)
        {
            return a1.AverageGrade > a2.AverageGrade;
        }
        return a1.PersonalAchievements > a2.PersonalAchievements;
    }

    public static bool operator ==(Abiturient a1, Abiturient a2)
    {
        if (ReferenceEquals(a1, a2)) return true;

        if (a1 is null || a2 is null) return false;

        return a1.AverageGrade == a2.AverageGrade && a1.PersonalAchievements == a2.PersonalAchievements;
    }

    public static bool operator !=(Abiturient a1, Abiturient a2)
    {
        return !(a1 == a2);
    }



    public override string ToString()
    {
        return $"ФИО: {FIO}, Средний балл: {AverageGrade}, Баллы за достижения: {PersonalAchievements}, Дата подачи: {ApplicationDate.ToShortDateString()}";
    }
}

public static class Postup
{ 
    public static double PassingGrade { get; set; } = 4.5;

    public static bool IsEligible(Abiturient abiturient)
    {
        return abiturient != null && abiturient.AverageGrade >= PassingGrade;
    }
}


public class Example
{
    public static void Main(string[] args)
    {
        Abiturient a1 = new Abiturient("Иванов Иван Иванович", 4.7, 10, DateTime.Parse("2024-08-15"));
        Abiturient a2 = new Abiturient("Петров Петр Петрович", 4.7, 8, DateTime.Parse("2024-08-10"));
        Abiturient a3 = new Abiturient("Сидоров Сидор Сидорович", 4.2, 12, DateTime.Parse("2024-08-20"));

        Console.WriteLine($"{a1.FIO} > {a2.FIO}: {a1 > a2}");
        Console.WriteLine($"{a2.FIO} < {a1.FIO}: {a2 < a1}");
        Console.WriteLine($"{a1.FIO} == {a2.FIO}: {a1 == a2}");
        Console.WriteLine($"{a1.FIO} != {a2.FIO}: {a1 != a2}");
        Console.WriteLine($"{a1.FIO} > {a3.FIO}: {a1 > a3}");


        Console.WriteLine($"Проходной балл: {Postup.PassingGrade}");
        Console.WriteLine($"{a1.FIO} прошел?: {Postup.IsEligible(a1)}");
        Console.WriteLine($"{a3.FIO} прошел?: {Postup.IsEligible(a3)}");
    }
}