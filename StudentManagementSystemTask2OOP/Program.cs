
using StudentManagementSystemTask2OOP;
using Serilog;
using System;


StudentManager manager = new StudentManager();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File(
        "logs/student-management-.log",
        rollingInterval: RollingInterval.Day
    )
    .CreateLogger();

Log.Information("Student Management System started.");

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("=================================");
    Console.WriteLine("     STUDENT MANAGEMENT SYSTEM");
    Console.WriteLine("=================================");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. View Students");
    Console.WriteLine("3. Search Student");
    Console.WriteLine("4. Delete Student");
    Console.WriteLine("5. Update Student");
    Console.WriteLine("6. Exit");
    Console.WriteLine("=================================");

    Console.Write("Select an option: ");

    string choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        case "1":

            Console.Write("Enter student number: ");
            string number = Console.ReadLine() ?? "";

            Console.Write("Enter student name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter student age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            if (age == 0 || age < 1)
            {
                Console.WriteLine("Invalid age!");
                age =  Convert.ToInt32(Console.ReadLine());
               
            }
        
                
            

            Console.Write("Enter course: ");
            string course = Console.ReadLine() ?? "";

            Console.Write("Enter student mark: ");

            double mark = Convert.ToDouble(Console.ReadLine());

            if ( mark < 0 || mark > 100)
            {
                Console.WriteLine("Mark must be between 0 and 100.");
                
            }

            if (string.IsNullOrWhiteSpace(number)
                || string.IsNullOrWhiteSpace(name)
                || string.IsNullOrWhiteSpace(course))
            {
                Console.WriteLine("Please fill in all details.");
                break;
            }

            Student newStudent = new Student(
                name,
                age,
                number,
                course,
                mark
            );

            manager.AddStudent(newStudent);

            break;

        case "2":

            manager.ViewStudents();

            break;

        case "3":

            Console.Write("Enter student number: ");
            string searchNumber = Console.ReadLine() ?? "";

            manager.SearchStudent(searchNumber);

            break;

        case "4":

            Console.Write("Enter student number: ");
            string deleteNumber = Console.ReadLine() ?? "";

            manager.DeleteStudent(deleteNumber);

            break;


        case "5":

            Console.Write("Enter student number to update: ");
            string updateNumber = Console.ReadLine() ?? "";

            Console.Write("Enter new student name: ");
            string newName = Console.ReadLine() ?? "";

            Console.Write("Enter new age: ");

            if (!int.TryParse(Console.ReadLine(), out int newAge)
                || newAge <= 0)
            {
                Console.WriteLine("Invalid age!");
                break;
            }

            Console.Write("Enter new course: ");
            string newCourse = Console.ReadLine() ?? "";

            Console.Write("Enter new mark: ");

            if (!double.TryParse(Console.ReadLine(), out double newMark)
                || newMark < 0 || newMark > 100)
            {
                Console.WriteLine("Invalid mark!");
                break;
            }

            if (string.IsNullOrWhiteSpace(newName)
                || string.IsNullOrWhiteSpace(newCourse)
                || string.IsNullOrWhiteSpace(updateNumber))
            {
                Console.WriteLine("All fields are required.");
                break;
            }

            manager.UpdateStudent(
                updateNumber,
                newName,
                newAge,
                newCourse,
                newMark
            );

            break;

        case "6":

            running = false;

            Console.WriteLine("Thank you for using the system!");

            break;


        default:

            Console.WriteLine("Invalid option. Try again.");

            break;
    }

    

}

Log.Information("Student Management System shutting down.");

Log.CloseAndFlush();

Console.WriteLine("Application closed successfully.");


Console.WriteLine();
Console.WriteLine("===== EXCEPTION HANDLING TEST =====");

//exception helps the program to not crash after the invalid input
try
{
    Console.Write("Enter your age: ");

    int age = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Your age is: " + age);
}
catch (FormatException)
{
    Console.WriteLine("Error: Please enter a valid whole number.");
}
catch (OverflowException)
{
    Console.WriteLine("Error: The number is too large.");
}
catch (InvalidStudentException ex)
{
    Console.WriteLine("Custom Error: " + ex.Message);

    Log.Error(ex, "Student validation failed.");
}
finally
{
    Console.WriteLine("Age input test completed.");
}




