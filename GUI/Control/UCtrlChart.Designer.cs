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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartSupplement = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMonth = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartSupplement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonth)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSupplement
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSupplement.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSupplement.Legends.Add(legend1);
            this.chartSupplement.Location = new System.Drawing.Point(423, 0);
            this.chartSupplement.Name = "chartSupplement";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSupplement.Series.Add(series1);
            this.chartSupplement.Size = new System.Drawing.Size(457, 257);
            this.chartSupplement.TabIndex = 0;
            this.chartSupplement.Text = "chart1";
            // 
            // chartMonth
            // 
            this.chartMonth.Location = new System.Drawing.Point(54, 53);
            this.chartMonth.Name = "chartMonth";
            this.chartMonth.Size = new System.Drawing.Size(300, 300);
            this.chartMonth.TabIndex = 0;
            // 
            // UCtrlChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartMonth);
            this.Controls.Add(this.chartSupplement);
            this.Margin = new System.Windows.Forms.Padding(2);
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
