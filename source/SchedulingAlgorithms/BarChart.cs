using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;

namespace SchedulingAlgorithms
{
    public class BarChart
    {
        ChartArea m_area;
        Series m_barSeries;

        public BarChart(Chart chart)
        {
            m_area = new ChartArea("MainArea");
            chart.ChartAreas.Add(m_area);

            m_barSeries = new Series();
            m_barSeries.YValuesPerPoint = 10;
            chart.ChartAreas["GraphArea"].AxisY.Interval = 1;
            m_barSeries.ChartType = SeriesChartType.RangeBar;
            chart.Series.Add(m_barSeries);
        }

        public void Draw(Simulation simulation)
        {
            int time;
            while (simulation.Finished == false)
            {
                Job job = simulation.WorkStep();
                time = simulation.Time;
                if (job != null)
                {
                    time++;
                    m_barSeries.Points.AddXY(job.JobNumber, simulation.Time, time);
                }
                simulation.Time++;
            }
            m_barSeries.ChartArea = "GraphArea";
        }
    }
}
