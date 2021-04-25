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
    /// Логика взаимодействия для DataGridOnMonitor.xaml
    /// </summary>
    public partial class DataGridOnMonitor : Page
    {
        
        public DataGridOnMonitor()
        {
            InitializeComponent();
            try
            { 
                supClass.sortClass.GetTimeSpan(TimeOnMonitor.group, data, tb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
