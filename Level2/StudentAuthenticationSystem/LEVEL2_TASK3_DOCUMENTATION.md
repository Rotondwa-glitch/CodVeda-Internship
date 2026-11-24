# Level 2 – Task 3: Authentication and Authorization System

## 1. Project Overview

This project is an ASP.NET Core MVC web application that demonstrates user authentication and role-based authorization using ASP.NET Core Identity.

Users can register accounts, log in and access protected areas based on their assigned roles.

## 2. Technologies Used

- C#
- ASP.NET Core MVC (.NET 9)
- ASP.NET Core Identity
- Entity Framework Core
- SQLite
- Razor Views
- IIS Express
- Visual Studio 2022

## 3. Authentication Implementation

ASP.NET Core Identity was integrated to manage user accounts and authentication.

The application supports:
- User registration
- User login and logout
- Password validation
- Unique email addresses
- Secure password hashing through Identity
- Authentication cookies

## 4. Password Validation

The application enforces the following password requirements:

- Minimum length of 8 characters
- At least one uppercase letter
- At least one lowercase letter
- At least one digit
- At least one special character

## 5. Database Implementation

SQLite was configured with Entity Framework Core and ASP.NET Core Identity.

The database stores user account information and role information using Identity tables.

The database is named `authentication.db`.

## 6. Authorization Implementation

Role-based authorization was implemented using two roles:

- **Admin:** Can access the protected Admin Dashboard.
- **User:** Can access normal application functionality but cannot access the Admin Dashboard.

The Admin Dashboard is protected using:

`[Authorize(Roles = "Admin")]`

Roles are created automatically through an Identity role seeder.

## 7. Testing and Results

| Test | Expected result | Result |
|---|---|---|
| User registration | Account created | Passed |
| User login | Authentication successful | Passed |
| Admin dashboard | Admin access granted | Passed |
| Normal user dashboard access | Access denied | Passed |
| Database connection | Identity database accessible | Passed |
| IIS Express | Application starts successfully | Passed |

## 8. Application Hosting

The application was configured to run through IIS Express in Visual Studio 2022.

The application was tested using the IIS Express launch profile.

## 9. What I Learned

Through this project, I gained practical experience in:

- Implementing authentication with ASP.NET Core Identity.
- Creating and managing user accounts.
- Configuring password validation.
- Connecting Identity to SQLite using Entity Framework Core.
- Implementing role-based authorization.
- Protecting controller actions and pages.
- Testing access restrictions for different user roles.
- Running ASP.NET Core applications using IIS Express.

## 10. Conclusion

The Student Authentication System successfully demonstrates authentication and authorization in ASP.NET Core MVC.

Users can register and log in, while role-based authorization ensures that only administrators can access the protected Admin Dashboard.