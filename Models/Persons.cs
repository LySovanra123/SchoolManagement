using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMangaement.Models
{
    public enum PersonType
    {
        Student,
        Teacher
    }
    public class Persons
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class StudentModel : Persons
    {
        public DateTime DateOfBirth { get; set; }
    }
    public class TeacherModel : Persons
    {
        public string Section { get; set; }
    }
}
