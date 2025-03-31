using System;

public class Figure
{
    public double Volume(double a)
    {
        return Math.Pow(a, 3);
    }

    public double Volume(double a, double b, double c)
    {
        return a * b * c;
    }

    public static void Main(string[] args)
    {
        Figure figure = new Figure();

        double cubeSide = 5;
        double cubeVolume = figure.Volume(cubeSide);
        Console.WriteLine($"Объем куба со стороной {cubeSide} = {cubeVolume}");

        double a = 2;
        double b = 3;
        double c = 4;
        double parallelepipedVolume = figure.Volume(a, b, c);
        Console.WriteLine($"Объем прямоугольного параллелепипеда со сторонами {a}, {b}, {c} = {parallelepipedVolume}");
    }
}