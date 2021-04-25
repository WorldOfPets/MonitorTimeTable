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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace timetable_v0
{
    /// <summary>
    /// Логика взаимодействия для TimeOnMonitor.xaml
    /// </summary>
    public partial class TimeOnMonitor : Window
    {
        public int refresss { get; set; }
        public static int group { get; set; }
        public TimeOnMonitor()
        {
            InitializeComponent();
            try
            { 
            refresss = 0;
            group = 1; frm1.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 2; frm2.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 3; frm3.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 4; frm4.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 6; frm5.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 7; frm6.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 8; frm7.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 9; frm8.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 10; frm9.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 11; frm10.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 12; frm11.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 13; frm12.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 14; frm13.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 15; frm14.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 16; frm15.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 17; frm16.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 18; frm17.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 19; frm18.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 20; frm19.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 21; frm20.Navigate(new PageTableTime.DataGridOnMonitor());
            group = 22; frm21.Navigate(new PageTableTime.DataGridOnMonitor());
            date.Text = DateTime.Now.ToLongDateString();
            Disp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DispatcherTimer dispatcher = new DispatcherTimer();
        public void Disp()
        {
            try
            { 
            dispatcher = new DispatcherTimer();
            dispatcher.Interval = TimeSpan.FromSeconds(1);
            dispatcher.Tick += timer_tick;
            dispatcher.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer_tick(object sender, EventArgs e)
        {
            try
            {
                refresss++;
                time.Text = DateTime.Now.ToLongTimeString();
                if (refresss > 300)
                {
                    dispatcher.Stop();
                    TimeOnMonitor timeOnMonitor = new TimeOnMonitor();
                    timeOnMonitor.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
