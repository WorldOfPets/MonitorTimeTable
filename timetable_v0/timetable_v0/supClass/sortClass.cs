using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace timetable_v0.supClass
{
    class sortClass
    {
        public static void GetTimeSpan(int k, DataGrid dataGrid, TextBlock textBlock)
        {
            try
            { 
            supClass.dbClass.dbTimeTable = new dbFolder.timetable_v3Entities();
            var now = DateTime.Now;
            var allTimeTable = supClass.dbClass.dbTimeTable.TimeTableMain.Where(x => x.idGroup == k && x.Date.Value.Day == now.Day).OrderBy(x => x.Number).ToList();
            var group = supClass.dbClass.dbTimeTable.Group.FirstOrDefault(x => x.Id == k );
            textBlock.Text = group.Name;
                //foreach (var i in allTimeTable)
                //{
                //    if (i.Subject.ShortName.Length < 13)
                //    { 
                //        i.Subject.ShortName += $"/{i.Teacher.Surname} {i.Teacher.Name[0]}.{i.Teacher.MiddleName[0]}.";
                //    }
                //}
            foreach (var i in allTimeTable)
            {
                foreach (var j in allTimeTable)
                {
                        if ((i.Number == j.Number && i.idGroup == j.idGroup && i.idTeacher != j.idTeacher && i.Date == j.Date /*&& i.Cabinet != j.Cabinet && i.idSubject != j.idSubject*/&& i.Subject.ShortName.Length < 15 ))
                        {
                            i.Subject.ShortName = $"(1п){i.Subject.ShortName}/{i.Teacher.Surname} {i.Teacher.Name[0]}.{i.Teacher.MiddleName[0]}.\n(2п){j.Subject.ShortName}/{j.Teacher.Surname} {j.Teacher.Name[0]}.{j.Teacher.MiddleName[0]}.";
                            i.Cabinet += "\n" + j.Cabinet;
                            j.Number = 0;
                        }
                }
                    if (i.Subject.ShortName.Length < 15 && i.Number != 0)
                    {
                        i.Subject.ShortName = $"{i.Subject.ShortName}/{i.Teacher.Surname} {i.Teacher.Name[0]}.{i.Teacher.MiddleName[0]}.";
                    }
                }

            dataGrid.ItemsSource = allTimeTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //var bc = new BrushConverter();
            //if (group.idSpec == 1)
            //{
            //    textBlock.Background = (Brush)bc.ConvertFrom("#2F2E33");
            //}
            //else if (group.idSpec == 2)
            //{
            //    textBlock.Background = (Brush)bc.ConvertFrom("#2F2E33");
            //}
            //else if (group.idSpec == 3)
            //{
            //    textBlock.Background = (Brush)bc.ConvertFrom("#2F2E33");
            //}
            //else if (group.idSpec == 4)
            //{
            //    textBlock.Background = (Brush)bc.ConvertFrom("#2F2E33");
            //}
            //else if (group.idSpec == 5)
            //{
            //    textBlock.Background = (Brush)bc.ConvertFrom("#2F2E33");
            //}
        }
    }
}
