using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SchedulingAlgorithms
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InputController input;
        JobQueue jobQueue;
        Simulation simulation;
        BarChart chart;

        public MainWindow()
        {
            InitializeComponent();
            tbProcessName.IsEnabled = false;
            input = new InputController
            {
                JobNumber = 0
            };
            jobQueue = new JobQueue();
            simulation = new Simulation();
            chart = new BarChart(Chart);
            DataContext = input;
            dgProcessesTable.ItemsSource = jobQueue.JobList;
            //List<Job> t = new List<Job>() { new Job(1, 1, 3, 1), new Job(0, 1, 1, 1), new Job(2, 1, 5, 2), new Job(3, 1, 5, 0) };
            //JobByBurstComparer c = new JobByBurstComparer();
            //t.Sort(c);
        }

        private void btnAddProcess_Click(object sender, RoutedEventArgs e)
        {
            jobQueue.AddJob(new Job(input.JobNumber, input.ArrivalTime, input.Burst, input.Priority));
            tbProcessName.Text = input.JobNumber++.ToString();
            dgProcessesTable.Items.Refresh();
        }

        private void rbFCFS_Checked(object sender, RoutedEventArgs e)
        {
            simulation.Algorithm = new FCFS(jobQueue);
        }

        private void rbRoundRobin_Checked(object sender, RoutedEventArgs e)
        {
            simulation.Algorithm = new RoundRobin(jobQueue);
        }

        private void rbSJF_Checked(object sender, RoutedEventArgs e)
        {
            simulation.Algorithm = new SJF(jobQueue);
        }

        private void rbPriority_Checked(object sender, RoutedEventArgs e)
        {
            simulation.Algorithm = new Priority(jobQueue);
        }

        private void btnStartSimulation_Click(object sender, RoutedEventArgs e)
        {
            chart.Draw(simulation);
            simulation.Reset();
            dgProcessesTable.Items.Refresh();
        }
    }
}
