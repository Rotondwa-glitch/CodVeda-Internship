
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementWebApp.Data;
using StudentManagementWebApp.Models;
using StudentManagementWebApp.Services;
namespace StudentManagementWebApp.Controllers
{
    public class StudentsController : Controller
    {
        // Database connection
        private readonly ApplicationDbContext _context;

        // Constructor: receives the database connection
        private readonly StudentService _studentService;

        public StudentsController(
            ApplicationDbContext context,
            StudentService studentService)
        {
            _context = context;
            _studentService = studentService;
        }



        public IActionResult Welcome()
        {
            string message = _studentService.GetWelcomeMessage();

            ViewBag.Message = message;

            return View();
        }
        // Display all students


        public async Task<IActionResult> Index(string? searchString, int page = 1)
        {
            // Number of students displayed per page
            int pageSize = 5;

            // Get students from the database
            var students = _context.Students.AsQueryable();

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                students = students.Where(s =>
                    s.FullName.Contains(searchString) ||
                    s.Email.Contains(searchString) ||
                    s.Course.Contains(searchString));
            }

            // Count matching students
            int totalStudents = await students.CountAsync();

            // Calculate how many pages are needed
            int totalPages = (int)Math.Ceiling((double)totalStudents / pageSize);

            // Get students for the current page
            var studentList = await students
                .OrderBy(s => s.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Send pagination information to the View
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.SearchString = searchString;

            return View(studentList);
        }


        // Display Add Student form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Save a new student
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        // Display Edit form
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // Save updated student information
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student updatedStudent)
        {
            if (id != updatedStudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Students.Update(updatedStudent);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(updatedStudent);
        }

        // Display Delete confirmation page
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // Delete student from database
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
