namespace GuitarTuner
{
    /// <summary>
    /// Calculates autocorrelation of input signal and searches max of autocorrelation's output.
    /// </summary>
    class Autocorrelator
    {
        private float[]     output = null;
        private float[]     input = null;

        //Only specific range of autocorrelation is necessary. Autocorrelation is calculated between min and max lags.
        private int         minLag, maxLag;
        private int         maxValueLag;
        private float       maxValue;


        public Autocorrelator(float[] INPUT, int SAMPLE_RATE)
        {
            input = INPUT;

            minLag = (int)(0.001 * SAMPLE_RATE);         // minimum autocorrelation lag - 0.001s for 1000Hz
            maxLag = (int)(0.05 * SAMPLE_RATE);          // maximum autocorrelation lag - 0.05s for 50Hz

            if (maxLag > input.Length)
                maxLag = input.Length;
            output = new float[maxLag];

            for(int i =0;i<maxLag; ++i)
            {
                output[i] = 0;
            }
        }

        public float[] Output { get => output; }
        public int MaxValueLag { get => maxValueLag; }
        public int MinLag { get => minLag; set => minLag = value; }

        /// <summary>
        /// Calculates autocorrealation of input and saves into output.
        /// </summary>
        public void CalculateAutocorrelation()
        {
            int outputSize = output.Length;
            int inputSize = input.Length;
            maxValue = -1;

            for (int lag = minLag; lag < maxLag; ++lag)
            {
                float lagSum = 0f;
                for(int i = 0; i < inputSize - lag; ++i)
                {
                    lagSum += (input[i] * input[i + lag]);
                }

                output[lag] = lagSum / outputSize;
                CheckIfMAx(lagSum, lag);
            }
        }

        private void CheckIfMAx(float SAMPLE_VALUE, int SAMPLE_INDEX)
        {
            if(SAMPLE_VALUE > maxValue)
            {
                maxValue = SAMPLE_VALUE;
                maxValueLag = SAMPLE_INDEX;
            }
        }
    }
}
