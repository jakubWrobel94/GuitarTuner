using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarTuner
{
    /// <summary>
    /// Wrapper class for detecting fundamental frequency of input audio signal and converting to pitch.
    /// Also gives information about error between detected frequency and nearest pitch in chromatic scale.
    /// </summary> 
    public class PitchDetector
    {
        FundamentalFrequencyDetector    fundamentalDetector = null;
        FundamentalToPitch              pitchConverter = null;
        Pitch                           detectedPitch = null;
        int                             error;

        public FundamentalFrequencyDetector FundamentalDetector { get => fundamentalDetector; }

        public delegate void PitchFoundEventHandler(object o, PitchFoundEventArgs e);
        public event PitchFoundEventHandler PitchFound;

        /// <summary>
        /// Constructor. Sets objects with given sample rate.
        /// </summary>
        /// <param name="SAMPLE_RATE">Sample rate value</param>
        public PitchDetector(int SAMPLE_RATE)
        {
            fundamentalDetector = new FundamentalFrequencyDetector(SAMPLE_RATE);
            pitchConverter = new FundamentalToPitch();   
            fundamentalDetector.FundamentalFrequencyDetected += OnFundamentalFrequencyDetected;
        }

        /// <summary>
        /// Called when fundamental frequency is calculated. Than frequency is converted into pitch.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void OnFundamentalFrequencyDetected(object o, FundamentalFrequencyDectectedEventArgs e)
        {
            float frequency = e.Frequency;
            var pitch = pitchConverter.GetPitch(frequency);
            detectedPitch = pitch.Item1;
            error = pitch.Item2;
            OnPitchFound();
        }

        /// <summary>
        /// Start detecting with specific audio device
        /// </summary>
        /// <param name="DEVICE_NUM">Audio device number</param>
        public void StartDetecting(int DEVICE_NUM)
        {
            fundamentalDetector.StartDetecting(DEVICE_NUM);
        }

        /// <summary>
        /// Stops detecting
        /// </summary>
        public void Stop()
        {
            fundamentalDetector.Stop();
        }

        /// <summary>
        /// Called when pitch is calculated
        /// </summary>
        virtual protected void OnPitchFound()
        {
            var e = new PitchFoundEventArgs()
            {
                CurrentPitch = detectedPitch,
                Error = error
            };
            PitchFound?.Invoke(this, e);
        }

    }

    public class PitchFoundEventArgs : EventArgs
    {
        public Pitch CurrentPitch { get; set; }
        public int Error { get; set; }
    }
}
