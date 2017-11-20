using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarTuner
{
    public partial class Form1 : Form
    {
        Tuner tuner = null;

        public Form1()
        {
            InitializeComponent();
            tuner = new Tuner();
            setTrackBarTones();
            for(int i = 0; i < NAudio.Wave.WaveIn.DeviceCount; i++)
            {
                comboBoxDevices.Items.Add(NAudio.Wave.WaveIn.GetCapabilities(i).ProductName);
            }
            comboBoxDevices.SelectedIndex = 0;
            tuner.ToneFound += OnToneFound;
            tuner.Buffer.BufferFilled += OnBuffer_BufferFilled;
        }

        private void OnBuffer_BufferFilled(object o, EventArgs e)
        {
            labelVolume.Text = (tuner.Volume).ToString("#.##");
            
            progressBarVolumeLevel.Value = (int)tuner.Volume + 90;
            
        }

        private void OnToneFound(object o, EventArgs e)
        {
            labelPitch.Text = tuner.CurrentTone.Pitch.ToString();
            labelKey.Text = tuner.CurrentTone.Name;
            labelError.Text = tuner.Error.ToString();
            trackBarError.Value = tuner.Error;
            int pitch = (int)tuner.PitchFinder.Pitch;
            if (pitch > trackBarTones.Maximum) trackBarTones.Value = trackBarTones.Maximum;
            else trackBarTones.Value = pitch; 
            
            if (Math.Abs(tuner.Error) < 5) labelKey.ForeColor = Color.Green;
            else labelKey.ForeColor = Color.Red;
            
        }

        private void buttonStartMonitoring_Click(object sender, EventArgs e)
        {
            tuner.beginMonitoring(comboBoxDevices.SelectedIndex);
        }

        private void buttonStopMonitoring_Click(object sender, EventArgs e)
        {
            tuner.stopMonitoring();
        }

        private void setTrackBarTones()
        {
            float unit = (float)trackBarTones.Height/(trackBarTones.Maximum - trackBarTones.Minimum);
            foreach(Tone tone in tuner.Tuning.StringTones)
            {
                float dFreq = tone.Pitch - trackBarTones.Minimum;
                int dPx = (int)(dFreq * unit);
                Label letter = new Label();
                letter.Parent = this;
                letter.Width = 30;
                letter.Height = 15;
                
                Point location = trackBarTones.Location;
                location.X += 25;
                location.Y -=  dPx - trackBarTones.Height;
                letter.Location = location;
                letter.Text = tone.Name;
                letter.Enabled = true;
                letter.BringToFront();
            }
        }
    }
}
