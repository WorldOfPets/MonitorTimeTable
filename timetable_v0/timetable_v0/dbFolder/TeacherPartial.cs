using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timetable_v0.dbFolder
{
    public partial class Teacher
    {
        public string getTeacher
        {
            get 
            {
                return $"{Surname} {Name} {MiddleName}";
            }
        }
    }
}
