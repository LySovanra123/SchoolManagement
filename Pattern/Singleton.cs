using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMangaement.Pattern
{
    public class Singleton
    {
        public static readonly Singleton instance = new Singleton();
        private SqlConnection connection;

        public Singleton()
        {
            connection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=SchoolManagementDB;Integrated Security=True");
        }
        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }
        public SqlConnection GetConnection()
        {
           if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }
    }
}
