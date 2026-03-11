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
    public partial class Subject : Form
    {
        public Subject()
        {
            InitializeComponent();
        }
        private SqlConnection con = Singleton.Instance.GetConnection();
        private TemplateClass _service = new SubjectEvent(new EventAction());

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cnn = new SqlCommand("insert into subjects values(@SubjectName,@SectionName)", con);
            cnn.Parameters.AddWithValue("@SubjectName", textBox2.Text);
            cnn.Parameters.AddWithValue("@SectionName", textBox3.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Save Succesfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        { 
            dataGridView1.DataSource = _service.add("select * from subjects");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            

            SqlCommand cnn = new SqlCommand("update subjects set SubjectName=@SubjectName, SectionName=@SectionName where Id=@Id", con);
            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@SubjectName", textBox2.Text);
            cnn.Parameters.AddWithValue("@SectionName", textBox3.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Succesfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            

            SqlCommand cnn = new SqlCommand("delete subjects where Id=@Id", con);
            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Succesfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _service.add("select * from subjects");
        }

        private void Subject_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _service.add("select * from subjects");
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
            dataGridView1.DataSource = _service.search("select * from subjects where Id",int.Parse(textBox1.Text));
        }
    }
}
