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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SchoolMangaement.Pattern;

namespace SchoolMangaement
{
    public partial class Enrollment : Form
    {
        public Enrollment()
        {
            InitializeComponent();
        }
        private TemplateClass _service = new EnrollmentEvent(new EventAction());

        private SqlConnection con = Singleton.Instance.GetConnection();

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker2.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            SqlCommand cnn = new SqlCommand("insert into enrollments values(@StudentName,@SectionName,@EnrollDate)", con);
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);

            cnn.Parameters.AddWithValue("@SectionName", textBox3.Text);
            cnn.Parameters.AddWithValue("@EnrollDate", dateTimePicker2.Value);
                
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Save Succesfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _service.add("select * from enrollments");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cnn = new SqlCommand("update enrollments set StudentName=@StudentName,SectionName=@Section,EnrollDate=@EnrollDate where Id=@EId", con);
            cnn.Parameters.AddWithValue("@EId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text);

            cnn.Parameters.AddWithValue("@Section", textBox3.Text);
            cnn.Parameters.AddWithValue("@EnrollDate", dateTimePicker2.Value);

            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Succesfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cnn = new SqlCommand("delete enrollments where Id=@EId", con);
            cnn.Parameters.AddWithValue("@EId", int.Parse(textBox1.Text));

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
            dataGridView1.DataSource = _service.display("select * from enrollments");
        }

        private void Enrollment_Load(object sender, EventArgs e)
        {

            SqlCommand cnn = new SqlCommand("select * from enrollments", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        ////private void button1_Click(object sender, EventArgs e)
        ////{
        ////    this.Close();
        ////    Main mn = new Main();
        ////    mn.Show();
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            ChangeState cs = new ChangeState();
            cs.SetState(new ConcreteStateMain());
            cs.Request();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        { 
            dataGridView1.DataSource = _service.search("select * from enrollments where Id", int.Parse(textBox1.Text));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
