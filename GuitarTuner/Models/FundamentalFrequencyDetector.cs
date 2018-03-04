using System;
using NAudio.Wave;
namespace GuitarTuner
{
    /// <summary>
    /// Wrapper class for calculating fundamental freuency in input audio signal.
    /// Uses autocorrelation method and spline interpolation to improve frequency resolution.
    /// </summary>
    public class FundamentalFrequencyDetector
    {
        private Recorder        recorder = null;
        private Autocorrelator  autocorrelator = null;
        private Interpolation   interpolator = null;
        private FrequencyBuffer frequencyBuffer = null;
        private int             sampleRate;
        private float           fundamentalFrequency;

        public delegate void FundametalFrequencyDetectedEventHandler(object o, FundamentalFrequencyDectectedEventArgs e);
        public event FundametalFrequencyDetectedEventHandler FundamentalFrequencyDetected;

        #region Parameters
        public float FundamentalFrequency { get => fundamentalFrequency; }
        public Recorder Recorder { get => recorder; set => recorder = value; }
        internal Autocorrelator Autocorrelator { get => autocorrelator; set => autocorrelator = value; }
        #endregion

        public FundamentalFrequencyDetector(int SAMPLE_RATE)
        {
            sampleRate = SAMPLE_RATE;
            int buffSize = (int)(sampleRate * 0.05);  // 50ms buffer size for min frequency 20Hz

            recorder = new Recorder(new WaveFormat(SAMPLE_RATE, 16, 1), buffSize);
            autocorrelator = new Autocorrelator(recorder.Buffer.Data, sampleRate);
            interpolator = new Interpolation();
            frequencyBuffer = new FrequencyBuffer(7, EstimationType.Median);

            recorder.Buffer.BufferFilled += OnBufferFilled;
            frequencyBuffer.FrequencyBufferFilled += OnFrequencyBufferFilled;
        }

        /// <summary>
        /// Enables recorder with specific device number and starts detecting.
        /// </summary>
        /// <param name="DEVICE_NUM">Device number.</param>
        public void StartDetecting(int DEVICE_NUM)
        {
            recorder.StartRecording(DEVICE_NUM);
        }

        /// <summary>
        /// Stops recorder. 
        /// </summary>
        public void Stop()
        {
            recorder.StopRecording();
        }

        /// <summary>
        /// Called when frequency buffer is filled. 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void OnFrequencyBufferFilled(object o, FrequencyBufferFilledEventArgs e)
        {
            fundamentalFrequency = e.EstimatedFrequency;
            OnFundamentalFrequencyDetected();
        }

        /// <summary>
        /// Called when audio samples buffer is filled. Starts main calculation chain. 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void OnBufferFilled(object o, BufferFilledEventArgs e)
        {
            //if (e.Volume < -50f) return;
            autocorrelator.CalculateAutocorrelation();
            int maxLag = autocorrelator.MaxValueLag;
            if (maxLag == autocorrelator.MinLag) return;
            float interpolatedVal = interpolator.Interpolate(maxLag, autocorrelator.Output);
            float frequency = sampleRate/ interpolatedVal;
            frequencyBuffer.AddFrequency(frequency);
        }

        /// <summary>
        /// Raised when frequency buffer is filled and fundamental frequency is estimated.
        /// </summary>
        protected virtual void OnFundamentalFrequencyDetected()
        {
            var e = new FundamentalFrequencyDectectedEventArgs()
            {
                Frequency = fundamentalFrequency
            };
            FundamentalFrequencyDetected?.Invoke(this, e);
        }
    }

    public class FundamentalFrequencyDectectedEventArgs : EventArgs
    {
        public float Frequency { get; set; }
    }
}
