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
    /// Логика взаимодействия для testText.xaml
    /// </summary>
    public partial class testText : Page
    {
        public testText()
        {
            InitializeComponent();
            int i = 1;
            tbRun.Text = null;
            List<dbFolder.Subject> listRan = new List<dbFolder.Subject>();
            listRan = supClass.dbClass.dbTimeTable.Subject.ToList();
            foreach (dbFolder.Subject subject in listRan)
            {
                tbRun.Text += $"***{i} {subject.ShortName} - {subject.Name} ";
                i++;
            }
        }
    }
}
