using System;

public class Arrays
{
    public double Average(int[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            throw new ArgumentException("Массив не может быть пустым или null.");
        }

        double sum = 0;
        foreach (int num in arr)
        {
            sum += num;
        }

        return sum / arr.Length;
    }

    public double Average(double[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            throw new ArgumentException("Массив не может быть пустым или null.");
        }

        double sum = 0;
        foreach (double num in arr)
        {
            sum += num;
        }

        return sum / arr.Length;
    }

    public static void Main(string[] args)
    {
        Arrays arrays = new Arrays();

        int[] intArray = { 1, 2, 3, 4, 5 };
        double[] doubleArray = { 1.5, 2.5, 3.5, 4.5, 5.5 };

        Console.WriteLine($"Среднее арифметическое массива целых чисел: {arrays.Average(intArray)}");
        Console.WriteLine($"Среднее арифметическое массива вещественных чисел: {arrays.Average(doubleArray)}");
    }
}