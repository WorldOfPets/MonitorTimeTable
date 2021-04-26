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
using timetable_v0.dbFolder;
using timetable_v0.supClass;

namespace timetable_v0.PageTableTime
{
    /// <summary>
    /// Interaction logic for EditTimeTable.xaml
    /// </summary>
    public partial class EditTimeTable : Page
    {
        public EditTimeTable()
        {
            InitializeComponent();
            //try
            //{ 
            dbClass.dbTimeTable = new dbFolder.timetable_v3Entities();

            cmbSubject.SelectedValuePath = "Id";
            cmbSubject.DisplayMemberPath = "Name";
            cmbSubject.ItemsSource = dbClass.dbTimeTable.Subject.OrderBy(x => x.Name).ToList();

            cmbTeacher.SelectedValuePath = "Id";
            cmbTeacher.DisplayMemberPath = "getTeacher";
            cmbTeacher.ItemsSource = dbClass.dbTimeTable.Teacher.ToList();

            cmbGroup.SelectedValuePath = "Id";
            cmbGroup.DisplayMemberPath = "Name";
            cmbGroup.ItemsSource = dbClass.dbTimeTable.Group.ToList();

            NumberGr = 1;
            btnN1.BorderBrush = Brushes.Green;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            var result = MessageBox.Show("Вы точно хотите внести изменения в расписание?", "..::Запрос на подтверждение::..", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                bool status;
                if (ChekStatus.IsChecked == true)
                {
                    status = true;
                }
                else status = false;
                TimeTableMain tableMain = new TimeTableMain
                {
                    idSubject = (int)cmbSubject.SelectedValue,
                    Date = Convert.ToDateTime(tboxDate.Text),
                    idTeacher = (int)cmbTeacher.SelectedValue,
                    Cabinet = tboxCabinet.Text,
                    Number = NumberGr,
                    idGroup = (int)cmbGroup.SelectedValue,
                    StatusSubject = status
                };
                dbClass.dbTimeTable.TimeTableMain.Add(tableMain);
                dbClass.dbTimeTable.SaveChanges();
                if (tableMain.StatusSubject == true)
                {
                    TimeSpanStatic timeSpanS = new TimeSpanStatic
                    {
                        IdTimeTableMain = tableMain.Id,
                        IdSubject = (int)cmbSubject.SelectedValue,
                        Date = Convert.ToDateTime(tboxDate.Text),
                        idTeacher = (int)cmbTeacher.SelectedValue,
                        Cabinet = tboxCabinet.Text,
                        Number = NumberGr,
                        idGroup = (int)cmbGroup.SelectedValue
                    };
                    dbClass.dbTimeTable.TimeSpanStatic.Add(timeSpanS);
                    dbClass.dbTimeTable.SaveChanges();
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public int NumberGr { get; set; }
        private void btnN1_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            var btn = (Button)sender;
            btnN1.BorderBrush = Brushes.Red;
            btnN2.BorderBrush = Brushes.Red;
            btnN3.BorderBrush = Brushes.Red;
            btnN4.BorderBrush = Brushes.Red;
            btnN5.BorderBrush = Brushes.Red;
            if (btn.Name == "btnN1") { btn.BorderBrush = Brushes.Green; NumberGr = 1; }
            else if (btn.Name == "btnN2") { btn.BorderBrush = Brushes.Green; NumberGr = 2; }
            else if (btn.Name == "btnN3") { btn.BorderBrush = Brushes.Green; NumberGr = 3; }
            else if (btn.Name == "btnN4") { btn.BorderBrush = Brushes.Green; NumberGr = 4; }
            else if (btn.Name == "btnN5") { btn.BorderBrush = Brushes.Green; NumberGr = 5; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
