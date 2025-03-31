using System;

public class Figure
{
    public double SurfaceArea(double a)
    {
        return 6 * Math.Pow(a, 2);
    }

    public double SurfaceArea(double a, double b, double c)
    {
        return 2 * (a * b + a * c + b * c);
    }

    public static void Main(string[] args)
    {
        Figure figure = new Figure();

        double cubeSide = 5;
        double cubeSurfaceArea = figure.SurfaceArea(cubeSide);
        Console.WriteLine($"Площадь поверхности куба со стороной {cubeSide} = {cubeSurfaceArea}");

        double a = 2;
        double b = 3;
        double c = 4;
        double parallelepipedSurfaceArea = figure.SurfaceArea(a, b, c);
        Console.WriteLine($"Площадь поверхности прямоугольного параллелепипеда со сторонами {a}, {b}, {c} = {parallelepipedSurfaceArea}");
    }
}