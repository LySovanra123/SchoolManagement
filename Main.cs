using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolMangaement
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Student st = new Student();
            st.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Subject sj = new Subject();
            sj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Teacher tr = new Teacher();
            tr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Section sn = new Section();
            sn.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Enrollment en = new Enrollment();
            en.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Attendance ae = new Attendance();
            ae.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Dashboard dd= new Dashboard();
            dd.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
