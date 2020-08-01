﻿using System;
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

        public MainWindow()
        {
            InitializeComponent();
            input = new InputController();
            jobQueue = new JobQueue();
            DataContext = input;
            dgProcessesTable.ItemsSource = jobQueue.JobList;
            //List<Job> t = new List<Job>() { new Job(1, 1, 3, 1), new Job(0, 1, 1, 1), new Job(2, 1, 5, 2), new Job(3, 1, 5, 0) };
            //JobByBurstComparer c = new JobByBurstComparer();
            //t.Sort(c);
        }

        private void btnAddProcess_Click(object sender, RoutedEventArgs e)
        {
            jobQueue.AddJob(new Job(input.JobNumber, input.ArrivalTime, input.Burst, input.Priority));
            dgProcessesTable.Items.Refresh();
        }
    }
}
