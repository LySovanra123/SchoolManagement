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
    public partial class Section : Form
    {
        public Section()
        {
            InitializeComponent();
        }
        private SqlConnection con = Singleton.Instance.GetConnection();
        private TemplateClass _service = new SectionEvent(new EventAction());

        private void btnSave_Click(object sender, EventArgs e)
        {


            SqlCommand cnn = new SqlCommand("insert into sections values(@StudentName,@SectionName,@SubjectName)", con);
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@SectionName", textBox3.Text);
            cnn.Parameters.AddWithValue("@SubjectName", textBox4.Text);
       
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Save Succesfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
 
            dataGridView1.DataSource = _service.add("select * from sections");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
 

            SqlCommand cnn = new SqlCommand("update sections set StudentName=@studentname,SectionName=@section,SubjectName=@subject where Id=@sectionid", con);
            cnn.Parameters.AddWithValue("@SectionId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Section", textBox3.Text);
            cnn.Parameters.AddWithValue("Subject", textBox4.Text);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Succesfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
       
            SqlCommand cnn = new SqlCommand("delete sections where sectionid=@sectionid", con);
            cnn.Parameters.AddWithValue("@SectionId", int.Parse(textBox1.Text));
          

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
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _service.display("select * from sections");
        }

        private void Section_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _service.display("select * from sections");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mn = new Main();
            mn.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _service.search("select * from sections where Id", int.Parse(textBox1.Text));
        }
    }
}
