using System;

namespace GuitarTuner
{
    /// <summary>
    /// Holds recorded audio samples and raises event when it is filled.
    /// </summary>
    class Buffer
    {
        float[]     data = null;
        int         size;
        int         position = 0;
        float       currentMax = -1;

        public delegate void BufferFilledEventHandler(Object o, BufferFilledEventArgs e);
        public event BufferFilledEventHandler BufferFilled;
        
        /// <summary>
        /// Sets up buffer with specific size
        /// </summary>
        /// <param name="SIZE">Buffer size</param>
        public Buffer(int SIZE)
        {
            size = SIZE;
            data = new float[size];
            ClearBuffer();
        }

        public float[] Data
        {
            get
            {
                return data;
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

        /// <summary>
        /// Raised when buffer is filled. Also volume in dB is calculated and passed in EventArgs.
        /// </summary>
        protected virtual void OnBufferFilled()
        {
            float vol = 20 * (float)Math.Log10(currentMax);
            if (float.IsInfinity(vol) || float.IsNaN(vol))
                vol = -90;
            BufferFilledEventArgs e = new BufferFilledEventArgs
            {
                Volume = vol
            };

            position = 0;
            currentMax = 0;
            BufferFilled?.Invoke(this, e);
        }

        /// <summary>
        /// Add audio sample to buffer.
        /// </summary>
        /// <param name="SAMPLE">Sample value</param>
        public void Add(float SAMPLE)
        {
            data[position] = SAMPLE;
            position++;
            if (SAMPLE > currentMax) currentMax = SAMPLE;

            if (position >= size)
            {
                OnBufferFilled();
            }
        }

        /// <summary>
        /// Sets all buffer values to 0.
        /// </summary>
        public void ClearBuffer()
        {
            for(int i = 0; i < size; ++i)
            {
                data[i] = 0f;
            }
            currentMax = -1f;
        }

    }

    public class BufferFilledEventArgs : EventArgs
    {
        public float Volume { get; set; }

    }
}
