using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for EndWindow.xaml
    /// </summary>
    public partial class EndWindow : Window
    {
        public EndWindow()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            var processes = Process.GetProcesses();
            foreach (var i in processes)
            {
                if(i.ProcessName == EndTextBox.Text)
                {
                    i.Kill();
                    break;
                }
            }
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
