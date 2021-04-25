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
using timetable_v0.supClass;
using timetable_v0.PageTableTime;

namespace timetable_v0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            { 
            dbClass.dbTimeTable = new dbFolder.timetable_v3Entities();
            perhod.frame = frm;
            frm.Navigate(new TimePage());
            var now = dbClass.dbTimeTable.TimeTableMain.FirstOrDefault();
            //var now = DateTime.Now;
            //tbTime.Text = (now.Hour).ToString() + (now.Minute).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            { 
                this.DragMove();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editMain_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
                frm.Navigate(new EditTimeTable());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimeSee_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                frm.Navigate(new TimePage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
