using TestMySpline;

namespace GuitarTuner
{
    /// <summary>
    /// Interpolates signal using spline interpolation for resolution improvement.
    /// </summary>
    class Interpolation
    {
        CubicSpline cubicSpline;
        int radius = 2;
        int n = 20;
        float[] xOutput;
        float[] yOutput;

        float[] xInput;
        float[] yInput;

        /// <summary>
        /// Contructor. 
        /// </summary>
        public Interpolation()
        {
            cubicSpline = new CubicSpline();
            xInput = new float[2 * radius + 1];
            yInput = new float[2 * radius + 1];
            xOutput = new float[n];
            yOutput = new float[n];
        }

        /// <summary>
        /// Calculates interpolation on input signal, around it's max index and returns interpolated max index.
        /// </summary>
        /// <param name="MAX_INDEX">Max index of input signal.</param>
        /// <param name="Y_ARRAY">Input signal.</param>
        /// <returns>Interpolated max index</returns>
      public float Interpolate(int MAX_INDEX, float[] Y_ARRAY)
        {
            SetXInput(MAX_INDEX);
            SetYInput(MAX_INDEX, Y_ARRAY);
            CalcXOutput(MAX_INDEX);
           
            yOutput = cubicSpline.FitAndEval(xInput, yInput, xOutput);
            int interpolatedMAxIndex = GetMaxInterpolatedValueIndex();
            float interpolatedMaxX = xOutput[interpolatedMAxIndex];
            return interpolatedMaxX;
        }


        public int GetMaxInterpolatedValueIndex()
        {
            double maxVal = -1;
            int maxIndex = -1;
            for(int i =0; i < yOutput.Length; ++i)
            {
                if(maxVal < yOutput[i] )
                {
                    maxVal = yOutput[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        /// <summary>
        /// Calculates output indexes vector around max index.
        /// </summary>
        /// <param name="MAX_INDEX">MAx value index</param>
        private void CalcXOutput(int MAX_INDEX)
        {
            xOutput[0] = xInput[0];
            float step = (xInput[xInput.Length - 1] - xInput[0]) / (n - 1);
            for (int i = 1; i< n; ++i)
            {
                xOutput[i] = xOutput[i-1] + step;
            }
        }

        /// <summary>
        /// Sets yInput.
        /// </summary>
        /// <param name="MAX_INDEX">Max value index.</param>
        /// <param name="Y_ARRAY">Input signal values.</param>
        private void SetYInput(int MAX_INDEX, float[] Y_ARRAY)
        {
            for(int i = 0; i< 2*radius+1; i++)
            {
                yInput[i] = Y_ARRAY[MAX_INDEX - radius + i];
            }
        }

        /// <summary>
        /// Sets xInput
        /// </summary>
        /// <param name="MAX_INDEX">Max value index</param>
        private void SetXInput(int MAX_INDEX)
        {
            for (int i = 0; i < 2 * radius +1; i++)
            {
                xInput[i] = MAX_INDEX - radius + i;
            }
        }
    }
}
