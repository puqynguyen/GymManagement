namespace GUI.Control
{
    partial class UCtrlChart
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartSupplement = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMonth = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartSupplement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonth)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSupplement
            // 
            chartArea3.Name = "ChartArea1";
            this.chartSupplement.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartSupplement.Legends.Add(legend3);
            this.chartSupplement.Location = new System.Drawing.Point(693, 0);
            this.chartSupplement.Name = "chartSupplement";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartSupplement.Series.Add(series3);
            this.chartSupplement.Size = new System.Drawing.Size(457, 257);
            this.chartSupplement.TabIndex = 0;
            this.chartSupplement.Text = "chart1";
            // 
            // chartMonth
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(63, 170);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(538, 241);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // UCtrlChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartMonth);
            this.Controls.Add(this.chartSupplement);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UCtrlChart";
            this.Size = new System.Drawing.Size(862, 432);
            ((System.ComponentModel.ISupportInitialize)(this.chartSupplement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSupplement;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMonth;
    }
}
