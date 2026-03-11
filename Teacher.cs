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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SchoolMangaement
{
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }
        private SqlConnection con = Singleton.Instance.GetConnection();
        private TemplateClass _service = new TeacherEvent(new EventAction());
        private PersonFactory _factory = new PersonFactory();
        private IPerson _person;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TeacherModel teacher = new TeacherModel
            {
                Name = textBox2.Text,
                Gender = textBox3.Text,
                PhoneNumber = textBox4.Text,
                Section = textBox5.Text
            };
            _person = _factory.CreatePerson("Teacher");
            _person.save(teacher);


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _service.add("select * from teachers");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            TeacherModel teacher = new TeacherModel
            {
                Id = int.Parse(textBox1.Text),
                Name = textBox2.Text,
                Gender = textBox3.Text,
                PhoneNumber = textBox4.Text,
                Section = textBox5.Text
            };
            _person = _factory.CreatePerson("Teacher");
            _person.update(teacher);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TeacherModel teacher = new TeacherModel
            {
                Id = int.Parse(textBox1.Text),
           
            };
            _person = _factory.CreatePerson("Teacher");
            _person.delete(teacher);

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
            dataGridView1.DataSource = _service.display("select * from teachers");
        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _service.display("select * from teachers");
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
            dataGridView1.DataSource = _service.search("select * from teachers where Id", int.Parse(textBox1.Text));
        }
    }
}
