using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarTuner
{
    class PitchFinder
    {
        float[] buffer;
        int size;

        float[] peaks;
        int peaksCount = 0;
        int peaksCapacity = 3;
        float peaksSum;
        float peakVal;
        Interpolation interpolation;
        float[] autocorrelation;
        float pitch = 0;
        int sampleRate;

        public float Pitch
        {
            get
            {
                return pitch;
            }

            set
            {
                pitch = value;
            }
        }

        public float PeakVal
        {
            get
            {
                return peakVal;
            }

            set
            {
                peakVal = value;
            }
        }

        public delegate void PitchFoundEventHandler(Object o, EventArgs e);
        public event PitchFoundEventHandler PitchFound;

        public PitchFinder(Buffer BUFFER, int SAMPLE_RATE)
        {
            interpolation = new Interpolation();
            buffer = BUFFER.Samples;
            size = BUFFER.Size;
            autocorrelation = new float[size];
            peaks = new float[peaksCapacity];
            sampleRate = SAMPLE_RATE;
            PeakVal = 0;
        }

        public void findPitch()
        {
            calcAutocorrelation();
            findPeak();
        }

        public void calcAutocorrelation()
        {
            for (int offset = 0; offset < size; ++offset)
            {
                float sum = 0;

                for (int i = 0; i < size - offset; ++i)
                {
                    sum += buffer[i] * buffer[i + offset];
                }

                autocorrelation[offset] = sum*sum ;
            }
        }

        public void findPeak()
        {
            int maxIndex = -1;
            float maxValue = -1;
            int minFreqIndex = sampleRate / 50;
            int maxFreqIndex = sampleRate / 800;
            
            
            for (int i = maxFreqIndex; i < size && i < minFreqIndex; ++i)
            {
                if (autocorrelation[i] > maxValue)
                {
                    maxValue = autocorrelation[i];
                    maxIndex = i;
                }
            }
            if (maxIndex == maxFreqIndex) return;
            peakVal = maxValue;
            float interpolated = interpolation.interpolatePitch(maxIndex, autocorrelation);
            //peaks[peaksCount] = sampleRate / (float)maxIndex;
            peaks[peaksCount] = sampleRate / interpolated;
            peaksSum += peaks[peaksCount];
            peaksCount++;

            if(peaksCount >= peaksCapacity )
            {
                OnPitchFound();
            }
        }

        protected virtual void OnPitchFound()
        {

            // Pitch = peaksSum / peaksCapacity;
            medianPeak();
            peaksCount = 0;
            peaksSum = 0;
            PitchFound?.Invoke(this, EventArgs.Empty);
        }

        private void medianPeak()
        {
            Array.Sort(peaks);
            pitch = peaks[peaksCapacity / 2];

        }
    }
}
