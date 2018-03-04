using System;

namespace GuitarTuner
{
    /// <summary>
    /// Converts fundamental frequency to pitch. Stores 65 semitones starting from A = 27,5 Hz to C# = 1141.69Hz
    /// </summary>
    class FundamentalToPitch
    {
        Pitch[] chromaticScale;
        string[] keyLetters = { "A", "Bb", "B", "C", "C#", "D", "Eb", "E", "F", "F#","G","G#" };
        int capacity = 65;
        
        public FundamentalToPitch()
        {
            Tones = new Pitch[capacity];
            Tones[0] = new Pitch(27.5f, keyLetters[0]);
            float factor = (float)Math.Pow(2, 1 / (double)12);

            for (int halftone = 1; halftone < capacity; ++halftone)
            {
                float freq = Tones[halftone - 1].Fundamental * factor;
                string letter = keyLetters[halftone % 12];
                Tones[halftone] = new Pitch(freq, letter);
            }
        }

       
        internal Pitch[] Tones
        {
            get
            {
                return chromaticScale;
            }

            set
            {
                chromaticScale = value;
            }
        }

        /// <summary>
        /// Finds pitch with given fundamental frequency and returns pitch and error
        /// </summary>
        /// <param name="FREQ">Fundamental frequency</param>
        /// <returns>Pitch and error</returns>
        /// Binary search implemented.
        public Tuple<Pitch,int> GetPitch(float FREQ)
        {
            if (FREQ < 20 || 1140 < FREQ) throw new OutOfFrequencyRangeException();
            int index = capacity/2;
            if (chromaticScale[index].LowBorder < FREQ && FREQ < chromaticScale[index].UpBorder)
            {
                int error = Tones[index].GetError(FREQ);
                return new Tuple<Pitch, int>(Tones[index], error);
            }
            if (FREQ < Tones[index].LowBorder) return GetPitch(FREQ, 0, index);
            if (Tones[index].UpBorder < FREQ) return GetPitch(FREQ, index, capacity);
            return null;

        }

        private Tuple<Pitch,int> GetPitch(float FREQ, double START_IDX, double END_IDX)
        {
            int index =(int) Math.Floor( (START_IDX + END_IDX)/2 );

            if (chromaticScale[index].LowBorder < FREQ && FREQ < chromaticScale[index].UpBorder)
            {
                int error = Tones[index].GetError(FREQ);
                return new Tuple<Pitch, int>(Tones[index], error);
            }

            if (FREQ < Tones[index].LowBorder) return GetPitch(FREQ, START_IDX, index);
            if (Tones[index].UpBorder < FREQ) return GetPitch(FREQ, index, END_IDX);
            
            return null;

        }
    }
}
