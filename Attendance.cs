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
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
        }
        private SqlConnection con = Singleton.Instance.GetConnection();
        private TemplateClass _service = new AttendanceEvent(new EventAction());

        private void btnSave_Click(object sender, EventArgs e)
        {
          
            SqlCommand cnn = new SqlCommand("insert into attendances values(@StudentName,@Status)", con);
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);

            cnn.Parameters.AddWithValue("@Status", textBox3.Text);
            

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Save Succesfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _service.add("select * from attendances");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           

            SqlCommand cnn = new SqlCommand("update attendances set StudentName=@StudentName,Status=@Status where Id=@Id", con);
            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);

            cnn.Parameters.AddWithValue("@Status", textBox3.Text);


            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Succesfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          
            SqlCommand cnn = new SqlCommand("delete attendances where Id=@Id", con);
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
            dataGridView1.DataSource = _service.display("select * from attendances");
        }

        private void Attendance_Load(object sender, EventArgs e)
        {          
            dataGridView1.DataSource = _service.display("select * from attendances");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mn = new Main();
            mn.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = _service.search("select * from attendances where Id", int.Parse(textBox1.Text));
        }
    }
}
