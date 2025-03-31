using System;

public class Figure
{
    public double Volume(double radius, double height)
    {
        return Math.PI * Math.Pow(radius, 2) * height;
    }

    public double Volume(double radius)
    {
        return (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
    }

    public static void Main(string[] args)
    {
        Figure figure = new Figure();

        double cylinderRadius = 3;
        double cylinderHeight = 7;
        double cylinderVolume = figure.Volume(cylinderRadius, cylinderHeight);
        Console.WriteLine($"Объем цилиндра с радиусом {cylinderRadius} и высотой {cylinderHeight} = {cylinderVolume}");

        double sphereRadius = 4;
        double sphereVolume = figure.Volume(sphereRadius);
        Console.WriteLine($"Объем шара с радиусом {sphereRadius} = {sphereVolume}");
    }
}