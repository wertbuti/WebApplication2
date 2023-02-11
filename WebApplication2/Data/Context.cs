using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        //public DbSet<StudentLesson> Lessons { get; set; }
    }
}
