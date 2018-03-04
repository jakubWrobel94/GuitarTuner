namespace GuitarTuner
{
    partial class TunerView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea18 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonStartMonitoring = new System.Windows.Forms.Button();
            this.buttonStopMonitoring = new System.Windows.Forms.Button();
            this.FrequencyLabel = new System.Windows.Forms.Label();
            this.PitchLabel = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.ErrorBar = new System.Windows.Forms.TrackBar();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.DevicesBox = new System.Windows.Forms.ComboBox();
            this.VolumeBar = new System.Windows.Forms.ProgressBar();
            this.PitchBar = new System.Windows.Forms.TrackBar();
            this.CorrelationChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TuningsListBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PitchBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CorrelationChart)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartMonitoring
            // 
            this.buttonStartMonitoring.Location = new System.Drawing.Point(197, 23);
            this.buttonStartMonitoring.Name = "buttonStartMonitoring";
            this.buttonStartMonitoring.Size = new System.Drawing.Size(75, 23);
            this.buttonStartMonitoring.TabIndex = 0;
            this.buttonStartMonitoring.Text = "Monitor";
            this.buttonStartMonitoring.UseVisualStyleBackColor = true;
            this.buttonStartMonitoring.Click += new System.EventHandler(this.buttonStartMonitoring_Click);
            // 
            // buttonStopMonitoring
            // 
            this.buttonStopMonitoring.Location = new System.Drawing.Point(197, 52);
            this.buttonStopMonitoring.Name = "buttonStopMonitoring";
            this.buttonStopMonitoring.Size = new System.Drawing.Size(75, 23);
            this.buttonStopMonitoring.TabIndex = 1;
            this.buttonStopMonitoring.Text = "Stop monitoring";
            this.buttonStopMonitoring.UseVisualStyleBackColor = true;
            this.buttonStopMonitoring.Click += new System.EventHandler(this.buttonStopMonitoring_Click);
            // 
            // FrequencyLabel
            // 
            this.FrequencyLabel.AutoSize = true;
            this.FrequencyLabel.Location = new System.Drawing.Point(146, 118);
            this.FrequencyLabel.Name = "FrequencyLabel";
            this.FrequencyLabel.Size = new System.Drawing.Size(25, 13);
            this.FrequencyLabel.TabIndex = 2;
            this.FrequencyLabel.Text = "440";
            // 
            // PitchLabel
            // 
            this.PitchLabel.AutoSize = true;
            this.PitchLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PitchLabel.ForeColor = System.Drawing.Color.Green;
            this.PitchLabel.Location = new System.Drawing.Point(106, 109);
            this.PitchLabel.Name = "PitchLabel";
            this.PitchLabel.Size = new System.Drawing.Size(25, 24);
            this.PitchLabel.TabIndex = 3;
            this.PitchLabel.Text = "A";
            this.PitchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLabel.Location = new System.Drawing.Point(135, 172);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(18, 18);
            this.ErrorLabel.TabIndex = 5;
            this.ErrorLabel.Text = "0";
            // 
            // ErrorBar
            // 
            this.ErrorBar.Enabled = false;
            this.ErrorBar.Location = new System.Drawing.Point(12, 145);
            this.ErrorBar.Maximum = 50;
            this.ErrorBar.Minimum = -50;
            this.ErrorBar.Name = "ErrorBar";
            this.ErrorBar.Size = new System.Drawing.Size(260, 45);
            this.ErrorBar.TabIndex = 6;
            this.ErrorBar.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.AutoSize = true;
            this.VolumeLabel.Location = new System.Drawing.Point(159, 237);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(41, 13);
            this.VolumeLabel.TabIndex = 7;
            this.VolumeLabel.Text = "volume";
            // 
            // DevicesBox
            // 
            this.DevicesBox.FormattingEnabled = true;
            this.DevicesBox.Location = new System.Drawing.Point(24, 23);
            this.DevicesBox.Name = "DevicesBox";
            this.DevicesBox.Size = new System.Drawing.Size(163, 21);
            this.DevicesBox.TabIndex = 8;
            // 
            // VolumeBar
            // 
            this.VolumeBar.Location = new System.Drawing.Point(53, 236);
            this.VolumeBar.Maximum = 90;
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.Size = new System.Drawing.Size(100, 14);
            this.VolumeBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.VolumeBar.TabIndex = 9;
            // 
            // PitchBar
            // 
            this.PitchBar.Enabled = false;
            this.PitchBar.Location = new System.Drawing.Point(278, 23);
            this.PitchBar.Maximum = 400;
            this.PitchBar.Minimum = 50;
            this.PitchBar.Name = "PitchBar";
            this.PitchBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.PitchBar.Size = new System.Drawing.Size(45, 245);
            this.PitchBar.TabIndex = 10;
            this.PitchBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.PitchBar.Value = 50;
            // 
            // CorrelationChart
            // 
            chartArea18.Name = "ChartArea1";
            this.CorrelationChart.ChartAreas.Add(chartArea18);
            this.CorrelationChart.Location = new System.Drawing.Point(344, 23);
            this.CorrelationChart.Name = "CorrelationChart";
            series18.ChartArea = "ChartArea1";
            series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series18.Name = "Series1";
            this.CorrelationChart.Series.Add(series18);
            this.CorrelationChart.Size = new System.Drawing.Size(377, 235);
            this.CorrelationChart.TabIndex = 11;
            this.CorrelationChart.Text = "chart1";
            // 
            // TuningsListBox
            // 
            this.TuningsListBox.FormattingEnabled = true;
            this.TuningsListBox.Location = new System.Drawing.Point(24, 52);
            this.TuningsListBox.Name = "TuningsListBox";
            this.TuningsListBox.Size = new System.Drawing.Size(163, 21);
            this.TuningsListBox.TabIndex = 12;
            this.TuningsListBox.SelectedIndexChanged += new System.EventHandler(this.TuningsListBox_SelectedIndexChanged);
            // 
            // TunerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(733, 286);
            this.Controls.Add(this.TuningsListBox);
            this.Controls.Add(this.CorrelationChart);
            this.Controls.Add(this.PitchBar);
            this.Controls.Add(this.VolumeBar);
            this.Controls.Add(this.DevicesBox);
            this.Controls.Add(this.VolumeLabel);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.PitchLabel);
            this.Controls.Add(this.FrequencyLabel);
            this.Controls.Add(this.buttonStopMonitoring);
            this.Controls.Add(this.buttonStartMonitoring);
            this.Controls.Add(this.ErrorBar);
            this.Name = "TunerView";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PitchBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CorrelationChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartMonitoring;
        private System.Windows.Forms.Button buttonStopMonitoring;
        private System.Windows.Forms.Label FrequencyLabel;
        private System.Windows.Forms.Label PitchLabel;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.TrackBar ErrorBar;
        private System.Windows.Forms.Label VolumeLabel;
        private System.Windows.Forms.ComboBox DevicesBox;
        private System.Windows.Forms.ProgressBar VolumeBar;
        private System.Windows.Forms.TrackBar PitchBar;
        private System.Windows.Forms.DataVisualization.Charting.Chart CorrelationChart;
        private System.Windows.Forms.ComboBox TuningsListBox;
    }
}

