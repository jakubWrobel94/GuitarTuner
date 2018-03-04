using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
namespace GuitarTuner
{
    /// <summary>
    /// Records audio with audio input device using WaveIn and sends samples to the buffer.
    /// </summary>
    public class Recorder
    {
        WaveIn waveIn = null;
        WaveFormat format = null;
        Buffer buffer = null;
        RecordingState state;

        public Recorder(WaveFormat FORMAT, int BUFFER_SIZE)
        {
            format = FORMAT;
            buffer = new Buffer(BUFFER_SIZE);
            state = RecordingState.Stopped;

        }

        internal Buffer Buffer { get => buffer; }

        /// <summary>
        /// Start recording with specific audio device
        /// </summary>
        /// <param name="DEVIVE_NUM">Audio input device number</param>
        public void StartRecording(int DEVIVE_NUM)
        {
            if (state == RecordingState.Recording) return;

            state = RecordingState.Recording;
            waveIn = new WaveIn
            {
                DeviceNumber = DEVIVE_NUM,
                WaveFormat = format,
                BufferMilliseconds = 100
            };
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.StartRecording();
        }

        /// <summary>
        /// Stops recording
        /// </summary>
        public void StopRecording()
        {
            if (state == RecordingState.Stopped) return;
            state = RecordingState.Stopped;
            waveIn.StopRecording();
            waveIn.Dispose();
        }

        /// <summary>
        /// Called when recorded data is available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            byte[] tempBuffer = e.Buffer;
            int bytesRecorded = e.BytesRecorded;

            for (int i = 0; i < bytesRecorded; i += 2)
            {
                short sample16 = BitConverter.ToInt16(tempBuffer, i);
                float sample32 = sample16 / (float)short.MaxValue;
                buffer.Add(sample32);               
            }
        }

        enum RecordingState { Recording, Stopped };
    }
}
