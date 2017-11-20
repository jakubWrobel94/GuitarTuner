using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
namespace GuitarTuner
{
    class Tuner
    {
        TonesTable tonesTable = null;
        PitchFinder pitchFinder = null;
        Buffer buffer = null;
        Tone currentTone = null;
        int error = 0;
        WaveIn waveIn;
        WaveFormat format;
        int sampleRate = 80000;
        MonitoringState monitoringState;
        float volume = 0;
        VolumeMeter volumeMeter = null;
        Tuning tuning;

        #region Properties
        internal Tone CurrentTone
        {
            get
            {
                return currentTone;
            }

            set
            {
                currentTone = value;
            }
        }

        public int Error
        {
            get
            {
                return error;
            }

            set
            {
                error = value;
            }
        }

        public float Volume
        {
            get
            {
                return volume;
            }

            set
            {
                volume = value;
            }
        }

        internal PitchFinder PitchFinder
        {
            get
            {
                return pitchFinder;
            }

            set
            {
                pitchFinder = value;
            }
        }

        public WaveIn WaveIn
        {
            get
            {
                return waveIn;
            }

            set
            {
                waveIn = value;
            }
        }

        internal Buffer Buffer
        {
            get
            {
                return buffer;
            }

            set
            {
                buffer = value;
            }
        }

        internal Tuning Tuning
        {
            get
            {
                return tuning;
            }

            set
            {
                tuning = value;
            }
        }

        internal MonitoringState MonitoringState { get => monitoringState; set => monitoringState = value; }
        #endregion

        #region Events
        public delegate void ToneFoundEventHandler(Object o, EventArgs e);
        public event ToneFoundEventHandler ToneFound;
        #endregion

        public Tuner()
        {
            int timeWindow = sampleRate / 50; // 20ms time window => 1s / 50 = 20ms
            Buffer = new Buffer(timeWindow);
            volumeMeter = new VolumeMeter(timeWindow, this);
            tonesTable = new TonesTable();
            PitchFinder = new PitchFinder(Buffer, sampleRate);
            format = new WaveFormat(sampleRate, 16, 1);
            CurrentTone = new Tone(440, "A");
            Tuning = new Tuning();
            setStandardTuning();
            MonitoringState = MonitoringState.stopped;

            Buffer.BufferFilled += OnBufferFilled;

            PitchFinder.PitchFound += OnPitchFound;
        }



        private void OnPitchFound(object o, EventArgs e)
        {
            float pitch = PitchFinder.Pitch;
            Tuple<Tone, int> tone;
            try
            {
                tone = tonesTable.getTone(pitch);
            }
            catch (OutOfFrequencyRangeException)
            {

                return;
            }
            CurrentTone = tone.Item1;
            Error = tone.Item2;
            OnToneFound();
        }

        private void OnBufferFilled(object o, EventArgs e)
        {
            if (-90 < volume) PitchFinder.findPitch();
        }

        protected virtual void OnToneFound()
        {
            ToneFound?.Invoke(this, EventArgs.Empty);
            currentTone = null;
        }

        public void beginMonitoring(int DEVICE_NUM)
        {
            if (MonitoringState == MonitoringState.monitoring) return;

            MonitoringState = MonitoringState.monitoring;
            WaveIn = new WaveIn();
            WaveIn.DeviceNumber = DEVICE_NUM;
            WaveIn.WaveFormat = format;
            WaveIn.BufferMilliseconds = 100;
            WaveIn.StartRecording();
            WaveIn.DataAvailable += OnDataAvailable;


        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            byte[] tempBuffer = e.Buffer;
            int bytesRecorded = e.BytesRecorded;

            for (int i = 0; i < bytesRecorded; i += 2)
            {

                short sample = BitConverter.ToInt16(tempBuffer, i);

                float sample32 = sample / (float)short.MaxValue;
                Buffer.Add(sample32);
                volumeMeter.add(sample32);
            }
        }

        public void stopMonitoring()
        {
            if (MonitoringState == MonitoringState.monitoring)
            {
                WaveIn.StopRecording();
                MonitoringState = MonitoringState.stopped;
            }
        }

        private void setStandardTuning()
        {
            Tuning.AddString("E6", 82.41f);
            Tuning.AddString("A5", 110f);
            Tuning.AddString("D4", 146.83f);
            Tuning.AddString("G3", 196f);
            Tuning.AddString("B2", 246.94f);
            Tuning.AddString("E1", 329.63f);
        }
    }

    enum MonitoringState { monitoring, stopped};
}
