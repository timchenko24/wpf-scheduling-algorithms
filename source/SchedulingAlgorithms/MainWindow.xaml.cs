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
            btnStartSimulation.IsEnabled = false;
            input = new InputController
            {
                JobNumber = 0
            };
            jobQueue = new JobQueue();
            simulation = new Simulation();
            chart = new BarChart(Chart, simulation);
            DataContext = input;
            dgProcessesTable.ItemsSource = jobQueue.JobList;
        }

        private void btnAddProcess_Click(object sender, RoutedEventArgs e)
        {
            jobQueue.AddJob(new Job(input.JobNumber, input.ArrivalTime, input.Burst, input.Priority));
            tbProcessName.Text = input.JobNumber++.ToString();
            dgProcessesTable.Items.Refresh();
        }

        private void CheckJobQueueSize()
        {
            if (jobQueue.GetSize() > 1) btnStartSimulation.IsEnabled = true;
        }

        private void rbFCFS_Checked(object sender, RoutedEventArgs e)
        {
            simulation.Algorithm = new FCFS(jobQueue);
            CheckJobQueueSize();
        }

        private void rbRoundRobin_Checked(object sender, RoutedEventArgs e)
        {
            simulation.Algorithm = new RoundRobin(jobQueue);
            CheckJobQueueSize();
        }

        private void rbSJF_Checked(object sender, RoutedEventArgs e)
        {
            simulation.Algorithm = new SJF(jobQueue);
            CheckJobQueueSize();
        }

        private void rbPriority_Checked(object sender, RoutedEventArgs e)
        {
            simulation.Algorithm = new Priority(jobQueue);
            CheckJobQueueSize();
        }

        private void btnStartSimulation_Click(object sender, RoutedEventArgs e)
        {
            chart.Draw();
            dgProcessesTable.Items.Refresh();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            simulation.Reset();
            jobQueue.Clear();
            chart.Clear();
            dgProcessesTable.Items.Refresh();
            rbFCFS.IsChecked = false;
            rbPriority.IsChecked = false;
            rbRoundRobin.IsChecked = false;
            rbSJF.IsChecked = false;
            btnStartSimulation.IsEnabled = false;
        }
    }
}
