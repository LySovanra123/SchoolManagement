using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SchoolMangaement.Pattern;


namespace SchoolMangaement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = Singleton.instance.GetConnection();

            String username = txtUsername.Text;
            String password = txtPassword.Text;
            SqlCommand cnn = new SqlCommand("Select AdminName,AdminPassword from Admins where AdminName ='" + username + "' and AdminPassword='" + password + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0) 
            { 
                Main mn = new Main();
                mn.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
