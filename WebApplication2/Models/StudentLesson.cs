namespace WebApplication2.Models
{
    public class StudentLesson
    {
        public int studentId { get; set; }
        public string StudentName { get; set; }



        public int LessonId { get; set; }
        public string LessonTitle { get; set; }
        public int LessonStudentId { get; set; }
        public int LessonNum { get; set; }

    }
}
