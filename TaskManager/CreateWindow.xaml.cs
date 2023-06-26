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
    /// Interaction logic for CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        public CreateWindow()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(CreateTextBox.Text);
            Close();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
