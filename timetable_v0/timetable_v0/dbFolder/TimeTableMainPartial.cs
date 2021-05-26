using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timetable_v0.dbFolder
{
     public partial class TimeTableMain
    {
        public string gNumber
        {
            get
            {
                return $"Пара {Number}";
            }
        }
        public string Back
        {
            get
            {
                var now = DateTime.Now;
                if ((/*(now.Hour != 2) ||*/ (now.Hour == 9 && now.Minute > 0) || (now.Hour == 10 && now.Minute < 30)) && Number == 1) { return "#3A5199"; } 
                else if (((now.Hour == 10 && now.Minute > 30) || now.Hour == 11 || (now.Hour == 12 && now.Minute < 20)) && Number == 2) { return "#3A5199"; } 
                else if (((now.Hour == 12 && now.Minute > 20) || now.Hour == 13 || (now.Hour == 14 && now.Minute < 5)) && Number == 3) { return "#3A5199"; }
                else if (((now.Hour == 14 && now.Minute > 5) || (now.Hour == 15 && now.Minute < 55)) && Number == 4) { return "#3A5199"; } else return "#D5D6D2";
            }
        }

        public string getVis
        {
            get
            {
                var now = DateTime.Now;
                if (Number == 0)
                {
                    return "Collapsed";
                }
                else if (((/*(now.Hour != 2)||*/(now.Hour == 9 && now.Minute > 0) || (now.Hour == 10 && now.Minute < 30)) && Number == 1) || (((now.Hour == 20) || (now.Hour == 9 && now.Minute > 0) || (now.Hour == 10 && now.Minute < 30)) && Number == 2)) { return "Visible"; }
                else if ((((now.Hour == 10 && now.Minute > 30) || now.Hour == 11 || (now.Hour == 12 && now.Minute < 20)) && Number == 2) || (((now.Hour == 10 && now.Minute > 30) || now.Hour == 11 || (now.Hour == 12 && now.Minute < 20)) && Number == 3)) { return "Visible"; }
                else if ((((now.Hour == 12 && now.Minute > 20) || now.Hour == 13 || (now.Hour == 14 && now.Minute < 5)) && Number == 3) || (((now.Hour == 12 && now.Minute > 20) || now.Hour == 13 || (now.Hour == 14 && now.Minute < 5)) && Number == 4)) { return "Green"; }
                else if ((((now.Hour == 14 && now.Minute > 5) || (now.Hour == 15 && now.Minute < 55)) && Number == 4) || (((now.Hour == 14 && now.Minute > 5) || (now.Hour == 15 && now.Minute < 55)) && Number == 5)) { return "Visible"; }
                else if (((now.Hour == 15 && now.Minute > 55) || now.Hour == 15 || (now.Hour == 16 && now.Minute < 60)) && Number == 5) { return "Visible"; } else return "Collapsed";
            }
        }
        public string Fore
        {
            get
            {
                var now = DateTime.Now;
                if ((/*(now.Hour != 2) ||*/ (now.Hour == 9 && now.Minute > 0) || (now.Hour == 10 && now.Minute < 30)) && Number == 1) { return "#D5D6D2"; }
                else if (((now.Hour == 10 && now.Minute > 30) || now.Hour == 11 || (now.Hour == 12 && now.Minute < 20)) && Number == 2) { return "#D5D6D2"; }
                else if (((now.Hour == 12 && now.Minute > 20) || now.Hour == 13 || (now.Hour == 14 && now.Minute < 5)) && Number == 3) { return "#D5D6D2"; }
                else if (((now.Hour == 14 && now.Minute > 5) || (now.Hour == 15 && now.Minute < 55)) && Number == 4) { return "#D5D6D2"; } else return "#3A5199";
            }
        }


        public string rovCollaps
        {
            get 
            {
                if (Number == 0)
                {
                    return "Collapsed";
                }
                else return "Visible";
            }
        }
        public string subName 
        {
            get 
            {
                return $"{Subject.ShortName}/{Teacher.Surname} {Teacher.Name[0]}.{Teacher.MiddleName[0]}.";
            }
        }
    }
}
