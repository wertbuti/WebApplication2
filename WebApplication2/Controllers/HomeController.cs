using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Context _context;

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            var students = _context.Students.ToList();
            var lessons = _context.Lessons.ToList();

            //var query = _context.Students.Where(x=>x.Id>2).Count();

            //var query = _context.Students.Join(_context.Lessons,
            //    students => students.Id,
            //    lessons => lessons.StudentId,
            //    (students, lessons) => new StudentLesson
            //    {
            //        studentId = students.Id,
            //        StudentName = students.Name,
            //        LessonId = lessons.Id,
            //        LessonTitle = lessons.Title,
            //        LessonStudentId = lessons.StudentId,
            //        LessonNum = lessons.Num
            //    }
            //    ).ToList();

            //var query = students.Join(lessons,
            //    students => students.Id,
            //    lessons => lessons.StudentId,
            //    (students, lessons) => new StudentLesson
            //    {
            //        studentId = students.Id,
            //        StudentName = students.Name,
            //        LessonId = lessons.Id,
            //        LessonTitle = lessons.Title,
            //        LessonStudentId = lessons.StudentId,
            //        LessonNum = lessons.Num
            //    }
            //    ).ToList();

            var query2 = from stu in students
                         join less in lessons
                         on stu.Id equals less.StudentId
                         where stu.Name == "reza"
                         select new StudentLesson
                         {
                             studentId = stu.Id,
                             StudentName = stu.Name,
                             LessonId = less.Id,
                             LessonTitle = less.Title,
                             LessonStudentId = less.StudentId,
                             LessonNum = less.Num
                         };
           // var query3 = _context.Students.Include("Lessons").ToList();

            var x = query2.Count();

            return View(query2);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}