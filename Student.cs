using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolMangaement.Models;
using SchoolMangaement.Pattern;

namespace SchoolMangaement
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private SqlConnection con = Singleton.Instance.GetConnection();
        private TemplateClass _service = new StudentEvent(new EventAction());
        private PersonFactory _factory = new PersonFactory();
        private IPerson _person;

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StudentModel student = new StudentModel
            {
                Name = textBox2.Text,
                DateOfBirth = dateTimePicker1.Value,
                Gender = textBox3.Text,
                PhoneNumber = textBox4.Text,
                Email = textBox5.Text
            };
            _person = _factory.CreatePerson("Student");
            _person.save(student);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _service.add("select * from students");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            StudentModel student = new StudentModel
            {
                Id = int.Parse(textBox1.Text),
                Name = textBox2.Text,
                DateOfBirth = dateTimePicker1.Value,
                Gender = textBox3.Text,
                PhoneNumber = textBox4.Text,
                Email = textBox5.Text
            };
            _person = _factory.CreatePerson("Student");
            _person.update(student);
         
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            StudentModel student = new StudentModel
            {
                Id = int.Parse(textBox1.Text)       
            };
            _person = _factory.CreatePerson("Student");
            _person.delete(student);

        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        { 
            dataGridView1.DataSource = _service.display("select * from students");
        }

        private void Student_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _service.display("select * from students");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ChangeState cs = new ChangeState();
            cs.SetState(new ConcreteStateMain());
            cs.Request();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        { 
            dataGridView1.DataSource = _service.search("select * from students where Id",int.Parse(textBox1.Text));
        }

        public static explicit operator Student(Persons v)
        {
            throw new NotImplementedException();
        }
    }
}
