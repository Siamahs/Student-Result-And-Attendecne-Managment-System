using System;

// ABSTRACT CLASS
abstract class Person
{
    public string Name;
    public string Id;

    public Person(string name, string id)
    {
        Name = name;
        Id = id;
    }

    public abstract void Show();
}

// INTERFACE
interface IReport
{
    string CreateReport();
}

// RESULT CLASS
class Result
{
    public double OOP, DLD, CA;

    public Result(double oop, double dld, double ca)
    {
        OOP = oop; DLD = dld; CA = ca;
    }

    public Result(Result r)
    {
        OOP = r.OOP; DLD = r.DLD; CA = r.CA;
    }

    public void AddMark(double oop, double dld, double ca)
    {
        OOP = oop; DLD = dld; CA = ca;
    }

    public void AddMark(string subject, double mark)
    {
        if (subject == "OOP") OOP = mark;
        else if (subject == "DLD") DLD = mark;
        else if (subject == "CA") CA = mark;
    }

    private double CGPA(double mark)
    {
        if (mark >= 80) return 4.00;
        if (mark >= 75) return 3.75;
        if (mark >= 70) return 3.50;
        if (mark >= 65) return 3.25;
        if (mark >= 60) return 3.00;
        if (mark >= 55) return 2.75;
        if (mark >= 50) return 2.50;
        if (mark >= 45) return 2.25;
        if (mark >= 40) return 2.00;
        return 0.00;
    }

    public double AverageCGPA()
    {
        return (CGPA(OOP) + CGPA(DLD) + CGPA(CA)) / 3;
    }

    public void Display()
    {
        Console.WriteLine($"OOP: {OOP}, DLD: {DLD}, CA: {CA}, Average CGPA: {AverageCGPA():0.00}");
    }
}

// STUDENT CLASS
class Student : Person, IReport
{
    public Result Marks;
    private List<bool> attendance = new List<bool>();

    public Student(string name, string id, Result r) : base(name, id)
    {
        Marks = new Result(r);
    }

    public Student(Student other) : base(other.Name, other.Id)
    {
        Marks = new Result(other.Marks);
        attendance = new List<bool>(other.attendance);
    }

    public void MarkAttendance(bool present)
    {
        attendance.Add(present);
    }

    public double AttendancePercentage()
    {
        if (attendance.Count == 0) return 0;
        int presentDays = 0;
        foreach (var a in attendance)
            if (a) presentDays++;
        return (presentDays / (double)attendance.Count) * 100;
    }

    public override void Show()
    {
        Console.WriteLine($"--- {Name} ---");
        Console.WriteLine("[STUDENT INFO]");
        Console.WriteLine($"Name: {Name}, ID: {Id}");
        Marks.Display();
        Console.WriteLine($"Attendance: {AttendancePercentage():0.00}%\n");
    }

    public string CreateReport()
    {
        return $"Student Report → {Name} | OOP: {Marks.OOP}, DLD: {Marks.DLD}, CA: {Marks.CA}, " +
               $"Average CGPA: {Marks.AverageCGPA():0.00}, Attendance: {AttendancePercentage():0.00}%";
    }
}

// MAIN PROGRAM
class Program
{
    static void Main()
    {
        Console.WriteLine("=== STUDENT RESULT SYSTEM ===\n");

        Result r1 = new Result(85, 80, 78);
        Student s1 = new Student("Rashedul Islam Rifat", "2243081072", r1);
        s1.MarkAttendance(true);
        s1.MarkAttendance(true);
        s1.MarkAttendance(false);
        s1.Show();

        Result r2 = new Result(80, 70, 85);
        Student s2 = new Student("Sanjida Alam Moonmoon", "2243081071", r2);
        s2.MarkAttendance(true);
        s2.MarkAttendance(true);
        s2.MarkAttendance(true);
        s2.Show();

        Result r3 = new Result(60, 85, 74);
        Student s3 = new Student("FARDIN FAHAD", "2243081172", r3);
        s3.MarkAttendance(true);
        s3.MarkAttendance(false);
        s3.MarkAttendance(true);
        s3.Show();

        Result r4 = new Result(65, 70, 60);
        Student s4 = new Student("AMDADUL HAQUE SIAM", "2243081050", r4);
        s4.MarkAttendance(true);
        s4.MarkAttendance(true);
        s4.MarkAttendance(true);
        s4.Show();

        Result r5 = new Result(71, 74, 80);
        Student s5 = new Student("MD. ADNAN AREFIN RATUL", "2243081062", r5);
        s5.MarkAttendance(false);
        s5.MarkAttendance(true);
        s5.MarkAttendance(true);
        s5.Show();

        // ================= All Reports =================
        List<Student> students = new List<Student> { s1, s2, s3, s4, s5 };
        Console.WriteLine("--- All Reports ---");
        foreach (var s in students) Console.WriteLine(s.CreateReport());
    }
}
