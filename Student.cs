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

            SqlCommand cnn = new SqlCommand("insert into students values(@StudentName,@DateOfBirth,@Gender,@Phone,@Email,@Actice)", con);
            cnn.Parameters.AddWithValue("@StudentId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Dob", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@Gender", textBox3.Text);
            cnn.Parameters.AddWithValue("@Phone", textBox4.Text);
            cnn.Parameters.AddWithValue("@Email", textBox5.Text);
            cnn.Parameters.AddWithValue("@Actice", "true");
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Save Succesfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _service.add("select * from students");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
    
            SqlCommand cnn = new SqlCommand("update students set StudentName=@StudentName,DateOfBirth=@dob,Gender=@gender,Phone=@phone,Email=@email where Id=@studentid", con);
            cnn.Parameters.AddWithValue("@StudentId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Dob", dateTimePicker1.Value);
            cnn.Parameters.AddWithValue("@Gender", textBox3.Text);
            cnn.Parameters.AddWithValue("@Phone", textBox4.Text);
            cnn.Parameters.AddWithValue("@Email", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Succesfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            SqlCommand cnn = new SqlCommand("delete students where Id=@studentid", con);
            cnn.Parameters.AddWithValue("@StudentId", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Succesfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Main mn = new Main();
            mn.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        { 
            dataGridView1.DataSource = _service.search("select * from students where Id",int.Parse(textBox1.Text));
        }
    }
}
