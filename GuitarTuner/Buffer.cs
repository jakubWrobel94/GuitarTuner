using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarTuner
{
    class Buffer
    {
        float[] samples;
        int size;
        int count = 0;
        float volume;
        float treshold = 0.03f;
        float volumeSum;

        public delegate void BufferFilledEventHandler(Object o, EventArgs e);
        public event BufferFilledEventHandler BufferFilled;

        public Buffer(int SIZE)
        {
            size = SIZE;
            Samples = new float[size];
            for(int i = 0;i < size; ++i)
            {
                Samples[i] = 0;
            }
            Volume = 0;
            volumeSum = 0;
        }

        public float[] Samples
        {
            get
            {
                return samples;
            }

            set
            {
                samples = value;
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

        public int Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        protected virtual void OnBufferFilled()
        {
            count = 0;
            volume = (float)Math.Sqrt(volumeSum / size);
            volumeSum = 0;
            //if(Volume > 0.5*treshold)
                BufferFilled?.Invoke(this, EventArgs.Empty);
        }

        public void Add(float SAMPLE)
        {

            if (Math.Abs(SAMPLE) > treshold)
            {
                if (SAMPLE > 0) Samples[count] = SAMPLE - treshold;
                else Samples[count] = SAMPLE + treshold;

            }
            else Samples[count] = 0;

            volumeSum += SAMPLE*SAMPLE;
            count++;

            if (count >= size)
            {
                OnBufferFilled();
            }

        }

        
    }
}
