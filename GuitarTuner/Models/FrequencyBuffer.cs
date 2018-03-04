using System;

namespace GuitarTuner
{
    /// <summary>
    /// Stores n size calculated frequencies and when is filled estimateS one output frequency. 
    /// It prevents some random changes in detected frequency.
    /// </summary>
    class FrequencyBuffer
    {
        private float[]         data;
        private int             size;
        private EstimationType  estimation;
        private int             position;

        public delegate void FrequencyBufferFilledEventHandler(object o, FrequencyBufferFilledEventArgs e);
        public event FrequencyBufferFilledEventHandler FrequencyBufferFilled;

        /// <summary>
        /// Sets up size of frequency buffer and type of estimation output frequency.
        /// </summary>
        /// <param name="SIZE">Size of buffer</param>
        /// <param name="ESTIMATION">Type of estimation: median or average</param>
        public FrequencyBuffer(int SIZE, EstimationType ESTIMATION)
        {
            size = SIZE;
            data = new float[size];
            estimation = ESTIMATION;
            position = 0;
        }

        public void AddFrequency(float FREQUENCY)
        {
            data[position] = FREQUENCY;
            position++;
            if(position >= size)
            {
                OnFrequencyBufferFilled();
            }
        }

        /// <summary>
        /// Called when buffer is filled. Output frequency is estimated and passed in event args.
        /// </summary>
        protected virtual void OnFrequencyBufferFilled()
        {
            position = 0;
            float estimatedFrequency = 0;
            if (estimation == EstimationType.Median)
                estimatedFrequency = GetMedian();
            if (estimation == EstimationType.Average)
                estimatedFrequency = GetAverage();

            if ((estimatedFrequency - data[0]) > 10) return;
            FrequencyBufferFilledEventArgs e = new FrequencyBufferFilledEventArgs
            {
                EstimatedFrequency = estimatedFrequency
            };

            FrequencyBufferFilled?.Invoke(this, e);
        }

        /// <summary>
        /// Calculates average of frequencies stored in buffer.
        /// </summary>
        /// <returns></returns>
        private float GetAverage()
        {
            float sum = 0f;
            foreach (var f in data)
            {
                sum += f;
            }

            return sum / size;
        }

        /// <summary>
        /// Calculates median of frequencies stored in buffer.
        /// </summary>
        /// <returns></returns>
        private float GetMedian()
        {
            Array.Sort(data);
            return data[size / 2];
        }
    }

    /// <summary>
    /// Enum for estimation type. Median or average.
    /// </summary>
    public enum EstimationType
    {
        Average, Median
    }
    
    public class FrequencyBufferFilledEventArgs : EventArgs
    {
        public float EstimatedFrequency { get; set; }
    }
}
