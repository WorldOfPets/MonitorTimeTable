using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace timetable_v0.PageTableTime
{
    /// <summary>
    /// Логика взаимодействия для TimePage.xaml
    /// </summary>
    public partial class TimePage : Page
    {
        public TimePage()
        {
            InitializeComponent();
            try
            { 
            cmbCourse.SelectedValuePath = "Id";
            cmbCourse.DisplayMemberPath = "Name";
            cmbCourse.ItemsSource = supClass.dbClass.dbTimeTable.Course.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmbCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try 
            { 
            cmbSpec.Text = null;
            cmbSpec.SelectedValuePath = "Id";
            cmbSpec.DisplayMemberPath = "Name";
            cmbSpec.ItemsSource = supClass.dbClass.dbTimeTable.Spec.Where(x => x.idCourse == (int)cmbCourse.SelectedValue).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmbSpec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            { 
            cmbGroup.Text = null;
            cmbGroup.SelectedValuePath = "Id";
            cmbGroup.DisplayMemberPath = "Name";
            if (cmbSpec.IsDropDownOpen) { cmbGroup.ItemsSource = supClass.dbClass.dbTimeTable.Group.Where(x => x.idSpec == (int)cmbSpec.SelectedValue).ToList(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbGroup.IsDropDownOpen)
                {
                    var now = DateTime.Now;
                    var allTimeTable = supClass.dbClass.dbTimeTable.TimeTableMain.Where(x => x.idGroup == (int)cmbGroup.SelectedValue && x.Date.Value.Day == now.Day).OrderBy(x => x.Number).ToList();
                    //DataGridTime.ItemsSource = allTimeTable;
                    foreach (var i in allTimeTable)
                    {
                        foreach (var j in allTimeTable)
                        {
                            if (i.Number == j.Number && i.Subject.Name != j.Subject.Name)
                            {
                                i.Teacher.MiddleName += "\n" + j.Teacher.Surname +" "+ j.Teacher.Name +" "+ j.Teacher.MiddleName;
                                i.Subject.Name += "\n" + j.Subject.Name;
                                i.Cabinet += "\n" + j.Cabinet;
                                j.Number = 0;
                            }
                        }
                    }
                    DataGridTime.ItemsSource = allTimeTable;
                }
                else DataGridTime.ItemsSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimeWin_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            var refresh = supClass.dbClass.dbTimeTable.TimeTableMain.ToList();
            foreach (var i in refresh)
            { 
                if(DateTime.Now.Date > i.Date)
                {
                    if (i.StatusSubject == false)
                    {
                        var save = supClass.dbClass.dbTimeTable.TimeSpanStatic.FirstOrDefault(x => x.IdTimeTableMain == i.Id);
                        i.idSubject = save.IdSubject;
                        i.Date = save.Date;
                        i.idTeacher = save.idTeacher;
                        i.Cabinet = save.Cabinet;
                        i.Number = save.Number;
                        i.idGroup = save.idGroup;
                        i.StatusSubject = true;
                    }
                    else if (i.StatusSubject == true)
                    {
                        var save = supClass.dbClass.dbTimeTable.TimeSpanStatic.FirstOrDefault(x => x.IdTimeTableMain == i.Id);
                        //save.Date = ((DateTime)i.Date).AddDays(14);
                        //i.Date = ((DateTime)i.Date).AddDays(14);
                    }
                }
            }
            supClass.dbClass.dbTimeTable.SaveChanges();
            TimeOnMonitor timeOnMonitor = new TimeOnMonitor();
            timeOnMonitor.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
