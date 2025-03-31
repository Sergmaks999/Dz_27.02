using System;

public class Figure
{
    public double SurfaceArea(double radius, double height)
    {
        return 2 * Math.PI * radius * (radius + height);
    }

    public double SurfaceArea(double radius)
    {
        return 4 * Math.PI * Math.Pow(radius, 2);
    }

    public static void Main(string[] args)
    {
        Figure figure = new Figure();

        double cylinderRadius = 3;
        double cylinderHeight = 7;
        double cylinderSurfaceArea = figure.SurfaceArea(cylinderRadius, cylinderHeight);
        Console.WriteLine($"Площадь поверхности цилиндра с радиусом {cylinderRadius} и высотой {cylinderHeight} = {cylinderSurfaceArea}");

        double sphereRadius = 4;
        double sphereSurfaceArea = figure.SurfaceArea(sphereRadius);
        Console.WriteLine($"Площадь поверхности шара с радиусом {sphereRadius} = {sphereSurfaceArea}");
    }
}