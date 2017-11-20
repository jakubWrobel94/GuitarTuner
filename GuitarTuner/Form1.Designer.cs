namespace GuitarTuner
{
    partial class Form1
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
            this.buttonStartMonitoring = new System.Windows.Forms.Button();
            this.buttonStopMonitoring = new System.Windows.Forms.Button();
            this.labelPitch = new System.Windows.Forms.Label();
            this.labelKey = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.trackBarError = new System.Windows.Forms.TrackBar();
            this.labelVolume = new System.Windows.Forms.Label();
            this.comboBoxDevices = new System.Windows.Forms.ComboBox();
            this.progressBarVolumeLevel = new System.Windows.Forms.ProgressBar();
            this.trackBarTones = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTones)).BeginInit();
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
            // labelPitch
            // 
            this.labelPitch.AutoSize = true;
            this.labelPitch.Location = new System.Drawing.Point(146, 118);
            this.labelPitch.Name = "labelPitch";
            this.labelPitch.Size = new System.Drawing.Size(25, 13);
            this.labelPitch.TabIndex = 2;
            this.labelPitch.Text = "440";
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKey.ForeColor = System.Drawing.Color.Green;
            this.labelKey.Location = new System.Drawing.Point(106, 109);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(25, 24);
            this.labelKey.TabIndex = 3;
            this.labelKey.Text = "A";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.Location = new System.Drawing.Point(135, 172);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(18, 18);
            this.labelError.TabIndex = 5;
            this.labelError.Text = "0";
            // 
            // trackBarError
            // 
            this.trackBarError.Enabled = false;
            this.trackBarError.Location = new System.Drawing.Point(12, 145);
            this.trackBarError.Maximum = 50;
            this.trackBarError.Minimum = -50;
            this.trackBarError.Name = "trackBarError";
            this.trackBarError.Size = new System.Drawing.Size(260, 45);
            this.trackBarError.TabIndex = 6;
            this.trackBarError.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(159, 237);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(41, 13);
            this.labelVolume.TabIndex = 7;
            this.labelVolume.Text = "volume";
            // 
            // comboBoxDevices
            // 
            this.comboBoxDevices.FormattingEnabled = true;
            this.comboBoxDevices.Location = new System.Drawing.Point(24, 23);
            this.comboBoxDevices.Name = "comboBoxDevices";
            this.comboBoxDevices.Size = new System.Drawing.Size(163, 21);
            this.comboBoxDevices.TabIndex = 8;
            // 
            // progressBarVolumeLevel
            // 
            this.progressBarVolumeLevel.Location = new System.Drawing.Point(53, 236);
            this.progressBarVolumeLevel.Maximum = 90;
            this.progressBarVolumeLevel.Name = "progressBarVolumeLevel";
            this.progressBarVolumeLevel.Size = new System.Drawing.Size(100, 14);
            this.progressBarVolumeLevel.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarVolumeLevel.TabIndex = 9;
            // 
            // trackBarTones
            // 
            this.trackBarTones.Location = new System.Drawing.Point(278, 23);
            this.trackBarTones.Maximum = 400;
            this.trackBarTones.Minimum = 50;
            this.trackBarTones.Name = "trackBarTones";
            this.trackBarTones.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarTones.Size = new System.Drawing.Size(45, 227);
            this.trackBarTones.TabIndex = 10;
            this.trackBarTones.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarTones.Value = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 262);
            this.Controls.Add(this.trackBarTones);
            this.Controls.Add(this.progressBarVolumeLevel);
            this.Controls.Add(this.comboBoxDevices);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.labelPitch);
            this.Controls.Add(this.buttonStopMonitoring);
            this.Controls.Add(this.buttonStartMonitoring);
            this.Controls.Add(this.trackBarError);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartMonitoring;
        private System.Windows.Forms.Button buttonStopMonitoring;
        private System.Windows.Forms.Label labelPitch;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.TrackBar trackBarError;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.ComboBox comboBoxDevices;
        private System.Windows.Forms.ProgressBar progressBarVolumeLevel;
        private System.Windows.Forms.TrackBar trackBarTones;
    }
}

