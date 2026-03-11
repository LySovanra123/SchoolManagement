using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolMangaement.Pattern;

namespace SchoolMangaement
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private ChangeState cs = new ChangeState();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            cs.SetState(new ConcreteStateStudent());
            cs.Request();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            cs.SetState(new ConcreteStateSubject());
            cs.Request();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            cs.SetState(new ConcreteStateTeacher());
            cs.Request();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            cs.SetState(new ConcreteStateSection());
            cs.Request();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            cs.SetState(new ConcreteStateEnrollment());
            cs.Request();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            cs.SetState(new ConcreteStateAttendance());
            cs.Request();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            cs.SetState(new ConcreteStateDashboard());
            cs.Request();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
