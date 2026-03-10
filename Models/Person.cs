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
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class Student : Person
    {
        public DateTime DateOfBirth { get; set; }
    }
    public class Teacher : Person
    {
        public string Section { get; set; }
    }
}
