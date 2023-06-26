using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TaskManager
{


    public class ProcessInfo
    {
        public string Name { get; set; }


        public int Id { get; set; }

        public int HandleCount { get; set; }

        public int ThreadCount { get; set; }

        public string Status { get; set; }



    }



    public partial class MainWindow : Window
    {
        public List<string> blackList;


        private DispatcherTimer timer1;
        private DispatcherTimer timer2;

        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            blackList = new List<string>();

            Show();





            timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromSeconds(30);
            timer1.Tick += Timer_Tick1;
            timer1.Start();



            timer2 = new DispatcherTimer();
            timer2.Interval = TimeSpan.FromSeconds(3);
            timer2.Tick += Timer_Tick2;
            timer2.Start();

        }
        private void Timer_Tick1(object sender, EventArgs e)
        {
            MessageBox.Show("Refreshed!");
            Show();
        }

        private void Timer_Tick2(object sender, EventArgs e)
        {
            KillNigga();
        }
        public void KillNigga()
        {
            var blacklistedProcesses = Process.GetProcesses()
.Where(p => blackList.Contains(p.ProcessName)).ToList();
            blacklistedProcesses.ForEach(a => a.Kill());

        }

        public void Show()
        {
            var processList = new List<ProcessInfo>();

            var processes = Process.GetProcesses();

            foreach (var process in processes)
            {

                processList.Add(new ProcessInfo
                {
                    Name = process.ProcessName,
                    Id = process.Id,
                    HandleCount = process.HandleCount,
                    ThreadCount = process.Threads.Count,
                    Status = process.Responding ? "Running" : "Suspended",
                });
            }
            processListView.ItemsSource = processList;
        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            var endWindow = new EndWindow();
            endWindow.Show();
        }

        private void BlackButton_Click(object sender, RoutedEventArgs e)
        {
            var blackWindow = new BlackWindow();
            blackWindow.ShowDialog();
            if (blackWindow.DialogResult == true)
            {
                string blackProcess = blackWindow.BlackTextBox.Text;
                blackList.Add(blackProcess);
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var createWindow = new CreateWindow();
            createWindow.Show();
        }
    }
}
