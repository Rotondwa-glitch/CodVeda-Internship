
# CodVeda Internship - Level 2 Task 2
## ASP.NET Core MVC Student Management System

### 1. Project Overview

I developed a Student Management System using ASP.NET Core MVC.

The purpose of this project was to understand web application development using the Model-View-Controller architecture and implement student management functionality.

### 2. Technologies Used

- C#
- ASP.NET Core MVC
- .NET 9
- Entity Framework Core
- SQLite
- Razor Views
- HTML
- Bootstrap
- Dependency Injection
- Middleware
- Visual Studio 2022

### 3. Features Implemented

- MVC architecture.
- Student registration.
- Displaying student records.
- Editing student information.
- Deleting student records.
- Form validation using Data Annotations.
- SQLite database integration.
- Entity Framework Core migrations.
- Permanent student record storage.
- Student search by name, email and course.
- Pagination.
- Custom Dependency Injection service.
- Custom request logging middleware.
- HTTP request and response logging.

### 4. MVC Architecture

The application follows the MVC design pattern.

Model:
The Student model represents student information, including ID, full name, email, age and course.

View:
Razor Views display student information and provide forms for adding, editing and deleting records.

Controller:
StudentsController handles student operations and communicates with the database.

### 5. Database Integration

I used SQLite as the database and Entity Framework Core to communicate with it.

I created ApplicationDbContext and used database migrations to create the Students table.

Student records are stored permanently and remain available after restarting the application.

### 6. Dependency Injection

I implemented Dependency Injection using AddScoped.

I created a StudentService class and injected it into StudentsController.

This helped me understand how ASP.NET Core manages application services.

### 7. Middleware

I developed custom RequestLoggingMiddleware.

It records incoming HTTP requests, response status codes and request processing times.

### 8. Challenges and Solutions

- I learned how to structure an ASP.NET Core MVC application.
- I implemented database operations using Entity Framework Core.
- I fixed search functionality and tested filtering.
- I implemented pagination while preserving search results.
- I learned how to inject services into controllers.
- I created custom middleware to monitor HTTP requests.

### 9. Testing

I tested student registration, viewing, editing and deletion.

I also tested form validation, database persistence, searching, pagination, Dependency Injection and middleware.

All implemented features were tested successfully.

### 10. Conclusion

This project improved my understanding of ASP.NET Core MVC and C# web development.

I gained practical experience working with databases, Entity Framework Core, Razor Views, Dependency Injection, middleware and application testing.
