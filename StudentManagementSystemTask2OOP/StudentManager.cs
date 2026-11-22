
using StudentManagementSystemTask2OOP;
using System;
using System.Collections.Generic;

public class StudentManager
{

    //This method throws our own exception when an invalid age is provided.
    public void ValidateStudentAge(int age)
    {
        if (age <= 0 || age > 120)
        {
            throw new InvalidStudentException(
                "Student age must be between 1 and 120."
            );
        }
    }

    // Store student records
    private List<Student> students = new List<Student>();

    // Add a student

    public void AddStudent(Student student)
    {
        // Check whether the student number already exists
        bool studentExists = students.Exists(
            s => s.StudentNumber.Equals(
                student.StudentNumber,
                StringComparison.OrdinalIgnoreCase
            )
        );

        if (studentExists)
        {
            Console.WriteLine("Error: Student number already exists!");
            return;
        }

        students.Add(student);

        Console.WriteLine("Student added successfully!");
    }


    // Display all students
    public void ViewStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        foreach (Student student in students)
        {
            student.DisplayInformation();
        }
    }

    // Search for a student
    public void SearchStudent(string studentNumber)
    {
        Student? student = students.Find(
            s => s.StudentNumber.Equals(
                studentNumber
            )
        );

        if (student == null)
        {
            Console.WriteLine("Student not found.");
        }
        else
        {
            student.DisplayInformation();
        }
    }

    // Delete a student
    public void DeleteStudent(string studentNumber)
    {
        Student? student = students.Find(
            s => s.StudentNumber.Equals(
                studentNumber)
                
            
        );

        if (student == null)
        {
            Console.WriteLine("Student not found.");
        }
        else
        {
            students.Remove(student);
            Console.WriteLine("Student deleted successfully!");
        }
    }

    // Update student information
    public void UpdateStudent(
        string studentNumber,
        string newName,
        int newAge,
        string newCourse,
        double newMark)
    {
        Student? student = students.Find(
            s => s.StudentNumber.Equals(
                studentNumber,
                StringComparison.OrdinalIgnoreCase
            )
        );

        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        // Update student details
        student.Name = newName;
        student.Age = newAge;
        student.Course = newCourse;
        student.Mark = newMark;

        Console.WriteLine("Student updated successfully!");
    }

}
