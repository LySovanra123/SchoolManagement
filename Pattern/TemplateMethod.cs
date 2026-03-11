using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents.DocumentStructures;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SchoolMangaement.Pattern
{
    public abstract class TemplateMethod
    {
        public void TemplateMethodBase(string name, string password)
        {
            bool success = SendQuery(name, password);
            Result(success);
        }

        public abstract bool SendQuery(string name, string password);

        public void Result(bool success)
        {
            if (success)
            {
                //this.Hide();
                Main mn = new Main();
                mn.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }
    }
    public class RequestToAdmin : TemplateMethod
    {
        public override bool SendQuery(string name, string password)
        {
            SqlConnection con = Singleton.instance.GetConnection();

            SqlCommand cmd = new SqlCommand(
            "SELECT COUNT(*) FROM Admins WHERE AdminName=@name AND AdminPassword=@pass", con);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@pass", password);

            int count = (int)cmd.ExecuteScalar();

            return count > 0;
        }
    }

}
