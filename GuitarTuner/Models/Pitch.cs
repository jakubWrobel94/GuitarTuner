using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarTuner
{
    /// <summary>
    /// Pitch class representation. Stores name, fundamental frequency values
    /// and distance to next or preverious pitch in chromatic scale.
    /// </summary>
    public class Pitch
    {
        string name;
        float fundamentalFrequency;
        float lowBorder;
        float upBorder;

        float diffToNext;
        float diffToPrev;
        
        public Pitch(float PITCH, string NAME)
        {
            fundamentalFrequency = PITCH;
            Name = NAME;

            float factor = (float)Math.Pow(2, (1 / (double)12));

            float prevTonePitch = fundamentalFrequency / factor;
            DiffToPrev = fundamentalFrequency - prevTonePitch;
            LowBorder = fundamentalFrequency - DiffToPrev / 2;

            float nextTonePitch = fundamentalFrequency * factor;
            diffToNext = nextTonePitch - fundamentalFrequency;
            upBorder = fundamentalFrequency + diffToNext / 2;

        }
        
        /// <summary>
        /// Returns error of frequency diffrence in cents
        /// </summary>
        /// <param name="FREQ">Frequency value</param>
        /// <returns>Error in cents</returns>
        public int GetError(float FREQ)
        {
            float diffrence = FREQ - fundamentalFrequency;

            if (FREQ < fundamentalFrequency)
            {
                return (int)((diffrence / DiffToPrev) * 100);
            }

            if(fundamentalFrequency < FREQ)
            {
                return (int)((diffrence / DiffToNext) * 100);
            }

            return 0;
        }

        #region Properties

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public float Fundamental
        {
            get
            {
                return fundamentalFrequency;
            }

        }

        public float LowBorder
        {
            get
            {
                return lowBorder;
            }

            set
            {
                lowBorder = value;
            }
        }

        public float UpBorder
        {
            get
            {
                return upBorder;
            }

            set
            {
                upBorder = value;
            }
        }

        public float DiffToNext
        {
            get
            {
                return diffToNext;
            }

            set
            {
                diffToNext = value;
            }
        }

        public float DiffToPrev
        {
            get
            {
                return diffToPrev;
            }

            set
            {
                diffToPrev = value;
            }
        }
        #endregion
    
    }
}
