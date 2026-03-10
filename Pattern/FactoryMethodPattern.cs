using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolMangaement.Models;

namespace SchoolMangaement.Pattern
{
    //Interface for Factory Method Pattern
    public interface IPerson
    {
        void save(Persons per);
        void update(Persons per);
        void delete(Persons per);
    }
    //Concrete class for Student
    public class StudentService : IPerson
    {
        private SqlConnection con = Singleton.Instance.GetConnection();

        public void delete(Persons Per)
        {

            StudentModel student = (StudentModel)Per;

            SqlCommand cnn = new SqlCommand("delete students where Id=@studentid", con);
            cnn.Parameters.AddWithValue("@StudentId", student.Id);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Succesfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void save(Persons Per)
        {
            StudentModel student = (StudentModel)Per;

            SqlCommand cmd = new SqlCommand("insert into students values(@StudentName,@DateOfBirth,@Gender,@Phone,@Email,@Actice)", con);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Dob", student.DateOfBirth);
            cmd.Parameters.AddWithValue("@Gender", student.Gender);
            cmd.Parameters.AddWithValue("@Phone", student.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@Actice", "true");
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Save Succesfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void update(Persons per)
        {
            StudentModel student = (StudentModel)per;

            SqlCommand cnn = new SqlCommand("update students set StudentName=@StudentName,DateOfBirth=@dob,Gender=@gender,Phone=@phone,Email=@email where Id=@studentid", con);
            cnn.Parameters.AddWithValue("@StudentId", student.Id);
            cnn.Parameters.AddWithValue("@StudentName", student.Name);
            cnn.Parameters.AddWithValue("@Dob", student.DateOfBirth);
            cnn.Parameters.AddWithValue("@Gender", student.Gender);
            cnn.Parameters.AddWithValue("@Phone",student.PhoneNumber);
            cnn.Parameters.AddWithValue("@Email", student.Email);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Succesfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    //Concrete class for Teacher
    public class TeacherService : IPerson
    {
        private SqlConnection con = Singleton.Instance.GetConnection();

        public void delete(Persons per)
        {
            TeacherModel teacher = (TeacherModel)per;

            SqlCommand cnn = new SqlCommand("delete teachers where Id=@Id", con);
            cnn.Parameters.AddWithValue("@TeacherId", teacher.Id);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Succesfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void save(Persons per)
        {
            TeacherModel teacher = (TeacherModel)per;

            SqlCommand cnn = new SqlCommand("insert into teachers values(@TeacherName,@Gender,@Phone,@SectionName)", con);
            cnn.Parameters.AddWithValue("@TeacherName", teacher.Name);
            cnn.Parameters.AddWithValue("@Gender", teacher.Gender);
            cnn.Parameters.AddWithValue("@Phone", teacher.PhoneNumber);
            cnn.Parameters.AddWithValue("@SectionName", teacher.Section);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Save Succesfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void update(Persons per)
        {

            TeacherModel teacher = (TeacherModel)per;

            SqlCommand cnn = new SqlCommand("update teachers set TeacherName=@TeacherName,Gender=@Gender,Phone=@Phone ,SectionName=@SectionName where Id=@Id", con);
            cnn.Parameters.AddWithValue("@Id", teacher.Id);
            cnn.Parameters.AddWithValue("@TeacherName", teacher.Name);
            cnn.Parameters.AddWithValue("@Gender", teacher.Gender);
            cnn.Parameters.AddWithValue("@Phone", teacher.PhoneNumber);
            cnn.Parameters.AddWithValue("@SectionName", teacher.Section);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Succesfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    //Factory class to create objects of Student and Teacher
    public class PersonFactory
    {
        public IPerson CreatePerson(string personType)
        {
            if (personType == "Student")
            {
                return new StudentService();
            }
            else if (personType == "Teacher")
            {
                return new TeacherService();
            }
            else
            {
                throw new ArgumentException("Invalid person type");
            }
        }
    }
}
