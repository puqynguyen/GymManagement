using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BUS.services;
using BUS.Services;

namespace GUI.Control
{
    public partial class UCtrlChart : UserControl
    {
        MembershipService membershipService = new MembershipService();
        public UCtrlChart()
        {
            InitializeComponent();
            DataTable MonthlyMembershipRevenue = membershipService.GetMonthlyMembershipRevenue();
            if (MonthlyMembershipRevenue == null || MonthlyMembershipRevenue.Rows.Count == 0)
            {
                MessageBox.Show("No data available to display in the chart.");
                return;
            }

            PopulateChart(MonthlyMembershipRevenue);
        }
        private void PopulateChart(DataTable dataTable)
        {
            chart1.Invalidate();
            chart1.Series.Clear();
            chart1.ChartAreas[0].RecalculateAxesScale();

            Series series = new Series("Membership Revenue");
            series.ChartType = SeriesChartType.Column;
            foreach (DataRow row in dataTable.Rows)
            {
                string month = row["Month"].ToString();
                decimal revenue = Convert.ToDecimal(row["TotalRevenue"]);

                series.Points.AddXY(month, revenue);
            }

            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Title = "Month";
            chart1.ChartAreas[0].AxisY.Title = "Revenue (VND)";
            chart1.ChartAreas[0].AxisX.Interval = 1;
        }

    }
}
