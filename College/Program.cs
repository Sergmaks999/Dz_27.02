using System;

public class College
{
    public string CollegeName { get; set; }
    public int StudentCount { get; set; }
    public int ClassroomCount { get; set; }
    public int TeacherCount { get; set; }

    public College(string collegeName, int studentCount, int classroomCount, int teacherCount)
    {
        CollegeName = collegeName;
        StudentCount = studentCount;
        ClassroomCount = classroomCount;
        TeacherCount = teacherCount;
    }

    public static bool operator <(College c1, College c2)
    {
        if (c1.StudentCount != c2.StudentCount)
        {
            return c1.StudentCount < c2.StudentCount;
        }
        return c1.ClassroomCount < c2.ClassroomCount;
    }

    public static bool operator >(College c1, College c2)
    {
        if (c1.StudentCount != c2.StudentCount)
        {
            return c1.StudentCount > c2.StudentCount;
        }
        return c1.ClassroomCount > c2.ClassroomCount;
    }

    public static bool operator ==(College c1, College c2)
    {
        if (ReferenceEquals(c1, c2)) return true;

        if (c1 is null || c2 is null) return false;

        return c1.StudentCount == c2.StudentCount && c1.ClassroomCount == c2.ClassroomCount;
    }

    public static bool operator !=(College c1, College c2)
    {
        return !(c1 == c2);
    }

    public override string ToString()
    {
        return $"Название: {CollegeName}, Студентов: {StudentCount}, Аудиторий: {ClassroomCount}, Преподавателей: {TeacherCount}";
    }
}

public static class Standard
{
    public static int RequiredStudentCount { get; set; } = 100;
    public static int RequiredTeacherCount { get; set; } = 10;

    public static bool IsConforming(College college)
    {
        if (college == null) return false;

        return college.TeacherCount >= (double)college.StudentCount / RequiredStudentCount * RequiredTeacherCount;
    }
}


public class Example
{
    public static void Main(string[] args)
    {
        College college1 = new College("Колледж 1", 200, 20, 20);
        College college2 = new College("Колледж 2", 200, 25, 22);
        College college3 = new College("Колледж 3", 150, 15, 15);


        Console.WriteLine($"{college1.CollegeName} > {college2.CollegeName}: {college1 > college2}");
        Console.WriteLine($"{college2.CollegeName} < {college1.CollegeName}: {college2 < college1}");
        Console.WriteLine($"{college1.CollegeName} == {college2.CollegeName}: {college1 == college2}");
        Console.WriteLine($"{college1.CollegeName} != {college2.CollegeName}: {college1 != college2}");
        Console.WriteLine($"{college1.CollegeName} > {college3.CollegeName}: {college1 > college3}");

        Console.WriteLine(college1);
        Console.WriteLine($"Соответствует стандарту? {Standard.IsConforming(college1)}");

        Console.WriteLine(college3);
        Console.WriteLine($"Соответствует стандарту? {Standard.IsConforming(college3)}");

        College college4 = new College("Колледж 4", 250, 20, 20);
        Console.WriteLine(college4);
        Console.WriteLine($"Соответствует стандарту? {Standard.IsConforming(college4)}");
    }
}