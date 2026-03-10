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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          

            SqlCommand cnn = new SqlCommand("insert into teachers values(@TeacherName,@Gender,@Phone,@SectionName)", con);
            cnn.Parameters.AddWithValue("@TeacherName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Gender", textBox3.Text);
            cnn.Parameters.AddWithValue("@Phone", textBox4.Text);
            cnn.Parameters.AddWithValue("@SectionName", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Save Succesfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _service.add("select * from teachers");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
          

            SqlCommand cnn = new SqlCommand("update teachers set TeacherName=@TeacherName,Gender=@Gender,Phone=@Phone ,SectionName=@SectionName where Id=@Id", con);
            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@TeacherName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Gender", textBox3.Text);
            cnn.Parameters.AddWithValue("@Phone", textBox4.Text);
            cnn.Parameters.AddWithValue("@SectionName", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Succesfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            SqlCommand cnn = new SqlCommand("delete teachers where Id=@Id", con);
            cnn.Parameters.AddWithValue("@TeacherId", int.Parse(textBox1.Text));
            
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Succesfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Main mn = new Main();
            mn.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _service.search("select * from teachers where Id", int.Parse(textBox1.Text));
        }
    }
}
