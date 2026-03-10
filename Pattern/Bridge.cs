using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace SchoolMangaement.Pattern
{
    // Interface
    public interface IEvent
    {
        DataTable add(string query);      
        DataTable search(string query,int id);
        DataTable display(string query);
    }
    // Concrete Implementor
    public class EventAction : IEvent
    {
        private SqlConnection con = Singleton.instance.GetConnection();

        public DataTable add(string query)
        {
            SqlCommand cnn = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
        public DataTable search(string query, int id)
        {
            SqlCommand cnn = new SqlCommand(query, con);
            cnn.Parameters.AddWithValue("@Id", id);

            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        public DataTable display(string query)
        {

            SqlCommand cnn = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
    }
    //Abstractor
    public abstract class TemplateClass
    {
        protected IEvent _event;

        public TemplateClass(IEvent ev)
        {
            _event = ev;
        }

        public virtual DataTable add(string query)
        {
            return _event.add(query);
        }
        public virtual DataTable search(string query, int id)
        {
            return _event.search(query, id);
        }

        public virtual DataTable display(string query)
        {
            return _event.display(query);
        }
    }
    //Refined Abstractions
    //=========================Enrollment Event=========================
    public class EnrollmentEvent : TemplateClass
    {
        public EnrollmentEvent(IEvent ev) : base(ev)
        {
        }

        public override DataTable add(string query)
        {
            return base.add(query);
        }

        public override DataTable display(string query)
        {
            return base.display(query);
        }

        public override DataTable search(string query, int id)
        {
            return base.search(query, id);
        }
    }
    //=========================Attendance Event=========================
    public class AttendanceEvent : TemplateClass
    {
        public AttendanceEvent(IEvent ev) : base(ev)
        {
        }

        public override DataTable add(string query)
        {       
            return base.add(query);
        }

        public override DataTable display(string query)
        {
            return base.display(query);
        }

        public override DataTable search(string query, int id)
        {
            return base.search(query, id);
        }
    }
    //=========================Student Event=========================
    public class StudentEvent : TemplateClass
    {
        public StudentEvent(IEvent ev) : base(ev)
        {
        }

        public override DataTable add(string query)
        {
            return base.add(query);
        }

        public override DataTable display(string query)
        {
            return base.display(query);
        }

        public override DataTable search(string query, int id)
        {
            return base.search(query, id);
        }
    }
    //=========================Teacher Event=========================
    public class TeacherEvent : TemplateClass
    {
        public TeacherEvent(IEvent ev) : base(ev)
        {
        }
        public override DataTable add(string query)
        {
            return base.add(query);
        }

        public override DataTable display(string query)
        {
            return base.display(query);
        }

        public override DataTable search(string query, int id)
        {
            return base.search(query, id);
        }
    }
    //=========================Subject Event=========================
    public class SubjectEvent : TemplateClass
    {
        public SubjectEvent(IEvent ev) : base(ev)
        {
        }
        public override DataTable add(string query)
        {
            return base.add(query);
        }

        public override DataTable display(string query)
        {
            return base.display(query);
        }

        public override DataTable search(string query, int id)
        {
            return base.search(query, id);
        }
    }
    //=========================Section Event=========================
    public class SectionEvent : TemplateClass
    {
        public SectionEvent(IEvent ev) : base(ev)
        {
        }
        public override DataTable add(string query)
        {
            return base.add(query);
        }

        public override DataTable display(string query)
        {
            return base.display(query);
        }

        public override DataTable search(string query, int id)
        {
            return base.search(query, id);
        }
    }
}
