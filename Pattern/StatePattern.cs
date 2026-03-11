using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMangaement.Pattern
{
    public interface IState
    {
        void Handle();
    }
    public class ConcreteStateEnrollment : IState
    {
        public void Handle()
        {
            Enrollment en = new Enrollment();
            en.Show();
        }
    }
    public class ConcreteStateAttendance : IState
    {
        public void Handle()
        {
            Attendance ae = new Attendance();
            ae.Show();
        }
    }
    public class ConcreteStateSection : IState
    {
        public void Handle()
        {
            Section sn = new Section();
            sn.Show();
        }
    }
    public class ConcreteStateSubject : IState
    {
        public void Handle()
        {
            Subject sj = new Subject();
            sj.Show();
        }
    }
    public class ConcreteStateStudent : IState
    {
        public void Handle()
        {
            Student st = new Student();
            st.Show();
        }
    }
    public class ConcreteStateTeacher : IState
    {
        public void Handle()
        {
            Teacher tr = new Teacher();
            tr.Show();
        }
    }
    public class ConcreteStateDashboard : IState
    {
        public void Handle()
        {
            Dashboard dd = new Dashboard();
            dd.Show();
        }
    }
    public class ConcreteStateMain : IState
    {
        public void Handle()
        {
            Main mn = new Main();
            mn.Show();
        }
    }
   
    class ChangeState
    {
        private IState _state;
        public void SetState(IState state)
        {
            _state = state;
        }
        public void Request()
        {
            _state.Handle();
        }
    }
}
