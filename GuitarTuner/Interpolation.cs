using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMySpline;
namespace GuitarTuner
{
    class Interpolation
    {
        CubicSpline cubicSpline;
        int radius = 4;
        int n = 30;
        float[] xs;
        float[] x;
        float[] y;

        public float[] Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public float[] X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public Interpolation()
        {
            cubicSpline = new CubicSpline();
            X = new float[2 * radius + 1];
            Y = new float[2 * radius + 1];
            xs = new float[n];
        }

      public float interpolatePitch(int MAX_INDEX, float[] Y_ARRAY)
        {
            setX(MAX_INDEX);
            setY(MAX_INDEX, Y_ARRAY);
            calcXs(MAX_INDEX);
           
            float[] ys = cubicSpline.FitAndEval(X, Y, xs);
            int interpolatedMAxIndex = getMaxIndex(ys);
            float interpolatedMaxX = xs[interpolatedMAxIndex];
            return interpolatedMaxX;
        }

        public int getMaxIndex(float[] ARRAY)
        {
            double maxVal = -1;
            int maxIndex = -1;
            for(int i =0; i < ARRAY.Length; ++i)
            {
                if(maxVal < ARRAY[i] )
                {
                    maxVal = ARRAY[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
        private void calcXs(int MAX_INDEX)
        {
            xs[0] = X[0];
            float step = (X[X.Length - 1] - X[0]) / (n - 1);
            for (int i = 1; i< n; ++i)
            {
                xs[i] = xs[i-1] + step;
            }
        }

        private void setY(int MAX_INDEX, float[] Y_ARRAY)
        {
            for(int i = 0; i< 2*radius+1; i++)
            {
                Y[i] = Y_ARRAY[MAX_INDEX - radius + i];
            }
        }

        private void setX(int MAX_INDEX)
        {
            for (int i = 0; i < 2 * radius +1; i++)
            {
                X[i] = MAX_INDEX - radius + i;
            }
        }
    }
}
