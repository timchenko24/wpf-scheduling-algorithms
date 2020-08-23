using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace SchedulingAlgorithms
{
    public class BarChart
    {
        ChartArea m_area;
        Series m_barSeries;
        Simulation m_simulation;

        public BarChart(Chart chart, Simulation simulation)
        {
            m_simulation = simulation;

            m_area = new ChartArea("MainArea");
            m_area.AxisX.Title = "Номера процессов";
            m_area.AxisY.Title = "Время";
            chart.ChartAreas.Add(m_area);

            m_barSeries = new Series();
            m_barSeries.YValuesPerPoint = 10;
            chart.ChartAreas["MainArea"].AxisY.Interval = 1;
            m_barSeries.ChartType = SeriesChartType.RangeBar;
            chart.Series.Add(m_barSeries);
        }

        public void Draw()
        {
            int time;
            while (m_simulation.Finished == false)
            {
                Job job = m_simulation.WorkStep();
                time = m_simulation.Time;
                if (job != null)
                {
                    time++;
                    m_barSeries.Points.AddXY(job.JobNumber, m_simulation.Time, time);
                }
                m_simulation.Time++;
            }
            m_barSeries.ChartArea = "MainArea";
        }

        public void Clear()
        {
            m_barSeries.Points.Clear();
            m_barSeries.ChartArea = "";
        }
    }
}
