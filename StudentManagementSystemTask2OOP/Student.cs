
using StudentManagementSystemTask2OOP;
using System.Xml.Linq;

public class Student : Person
{
    public string StudentNumber { get; set; }
    public string Course { get; set; }
    public double Mark { get; set; }

    public Student(
        string name,
        int age,
        string studentNumber,
        string course,
        double mark
    ) : base(name, age)
    {
        StudentNumber = studentNumber;
        Course = course;
        Mark = mark;
    }

    public override void DisplayInformation()
    {
        Console.WriteLine("-------------------------");
        Console.WriteLine("Student Number: " + StudentNumber);
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
        Console.WriteLine("Course: " + Course);
        Console.WriteLine("Mark: " + Mark);
        Console.WriteLine("-------------------------");
    }
}
