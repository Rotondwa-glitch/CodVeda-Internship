
# CODEVDA TECHNOLOGY - .NET DEVELOPMENT INTERNSHIP

## LEVEL 1 DOCUMENTATION

**Intern:** Rotondwa Madi  
**Project:** Student Management System  
**Technology:** C# and .NET 9  
**IDE:** Visual Studio Community 2022  
**Level:** Level 1  

---

# TASK 2: C# BASICS AND OBJECT-ORIENTED PROGRAMMING

## 1. Introduction

I developed a Student Management System using C# and .NET. The application allows users to add, view, search, update and delete student records.

## 2. Object-Oriented Programming Concepts

The project demonstrates the following concepts:

- Encapsulation: Managing access to class data.
- Inheritance: Student and Teacher inherit from the Person class.
- Polymorphism: Different classes implement their own DisplayInformation() method.
- Constructors: Initialising objects when they are created.
- Properties: Managing student and teacher information.
- Methods: Performing operations within the application.

## 3. Main Classes

- Person.cs
- Student.cs
- Teacher.cs
- StudentManager.cs
- Program.cs

---

# TASK 3: EXCEPTION HANDLING AND DEBUGGING

## 1. Exception Handling

I implemented try-catch-finally blocks to handle errors and prevent unexpected application termination.

## 2. Duplicate Prevention

The application checks whether a student number already exists before adding a new student.

## 3. Custom Exceptions

I created an InvalidStudentException class to handle invalid student information, including student ages outside the permitted range.

## 4. Debugging

I used Visual Studio breakpoints and the Watch window to inspect variables and follow program execution.

## 5. Logging with Serilog

I installed and configured:

- Serilog
- Serilog.Sinks.Console
- Serilog.Sinks.File

The application records information messages, warnings and errors.

Log files are saved in the logs folder.

## 6. Testing Results

| Feature | Result |
|---|---|
| Exception handling | Successful |
| Duplicate prevention | Successful |
| Breakpoints and Watch | Successful |
| Serilog console logging | Successful |
| Serilog file logging | Successful |
| Shutdown logging | Successful |
| Exception logging | Successful |

## 7. Conclusion

Through this project, I improved my understanding of C#, object-oriented programming, exception handling, debugging and application logging.

The project helped me gain practical experience in developing and testing a .NET console application.
