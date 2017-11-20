using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarTuner
{
    class VolumeMeter
    {
        float[] buffer;
        float volumeDB;
        int count = 0;
        int size;
        Tuner tuner;

       

        public VolumeMeter(int SIZE,Tuner TUNER)
        {
            Buffer = new float[SIZE];
            VolumeDB = 0;
            Size = SIZE;
            tuner = TUNER;
            
        }

        public void add(float SAMPLE)
        {
            buffer[count] = Math.Abs(SAMPLE);
            count++;
            if(count >= Size)
            {
                count = 0;
                float peak = maxPeak();
                calcVolume(peak);
                
            }
        }

        private float maxPeak()
        {
            int maxIndex = -1;
            float maxValue = -1;

            for (int i = 0; i < Size ; ++i)
            {
                if (Buffer[i] > maxValue)
                {
                    maxValue = Buffer[i];
                    maxIndex = i;
                }
            }

            return maxValue;
        }

        private void calcVolume(float PEAK)
        {
            float volDb = 20*(float)Math.Log10(PEAK / 1.0f);
            VolumeDB = volDb;
            tuner.Volume = volumeDB;
        }

        

        public float[] Buffer
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

        public float VolumeDB
        {
            get
            {
                return volumeDB;
            }

            set
            {
                volumeDB = value;
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
    }
}
