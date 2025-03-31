using System;

public class Figure
{
    public double Area(double a)
    {
        return Math.Pow(a, 2);
    }

    public double Area(double a, double b)
    {
        return a * b;
    }

    public double Area(double a, double b, string shapeType)
    {
        if (shapeType != "треугольник")
        {
            Console.WriteLine("Внимание: Вычисляется площадь, как для прямоугольного треугольника, но shapeType != \"треугольник\".");
        }
        return (a * b) / 2.0;
    }

    public double Area(double a, double b, double h)
    {
        return ((a + b) * h) / 2.0;
    }

    public static void Main(string[] args)
    {
        Figure figure = new Figure();

        Console.WriteLine($"Площадь квадрата со стороной 5: {figure.Area(5)}");
        Console.WriteLine($"Площадь прямоугольника со сторонами 4 и 6: {figure.Area(4, 6)}");
        Console.WriteLine($"Площадь прямоугольного треугольника с катетами 3 и 8: {figure.Area(3, 8, "треугольник")}");
        Console.WriteLine($"Площадь трапеции с основаниями 2 и 7 и высотой 5: {figure.Area(2, 7, 5)}");
    }
}