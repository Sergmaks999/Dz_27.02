using System;

public class Arrays
{
    public int Max(int[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            throw new ArgumentException("Массив не может быть пустым или null.");
        }

        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        return max;
    }

    public double Max(double[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            throw new ArgumentException("Массив не может быть пустым или null.");
        }

        double max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        return max;
    }

    public static void Main(string[] args)
    {
        Arrays arrays = new Arrays();

        int[] intArray = { 1, 5, 2, 8, 3 };
        double[] doubleArray = { 1.5, 2.2, 0.8, 5.1, 3.7 };

        Console.WriteLine($"Максимальное число в массиве целых чисел: {arrays.Max(intArray)}");
        Console.WriteLine($"Максимальное число в массиве вещественных чисел: {arrays.Max(doubleArray)}");
    }
}