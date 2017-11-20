using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarTuner
{
    class TonesTable
    {
        Tone[] tones;
        string[] keyLetters = { "A", "Bb", "B", "C", "C#", "D", "Eb", "E", "F", "F#","G","G#" };
        int capacity = 64;
        
        public TonesTable()
        {
            Tones = new Tone[capacity];
            Tones[0] = new Tone(55, keyLetters[0]);
            float factor = (float)Math.Pow(2, 1 / (double)12);

            for (int halftone = 1; halftone < capacity; ++halftone)
            {
                float freq = Tones[halftone - 1].Pitch * factor;
                string letter = keyLetters[halftone % 12];
                Tones[halftone] = new Tone(freq, letter);
            }
        }

        

        internal Tone[] Tones
        {
            get
            {
                return tones;
            }

            set
            {
                tones = value;
            }
        }

        public Tuple<Tone,int> getTone(float FREQ)
        {
            if (FREQ < 55 || 2000 < FREQ) throw new OutOfFrequencyRangeException();
            int index = capacity/2;
            if (tones[index].LowBorder < FREQ && FREQ < tones[index].UpBorder)
            {
                int error = Tones[index].getError(FREQ);
                return new Tuple<Tone, int>(Tones[index], error);
            }
            if (FREQ < Tones[index].LowBorder) return getTone(FREQ, 0, index);
            if (Tones[index].UpBorder < FREQ) return getTone(FREQ, index, capacity);
            return null;

        }
        public Tuple<Tone,int> getTone(float FREQ, double START_IDX, double END_IDX)
        {
            int index =(int) Math.Floor( (START_IDX + END_IDX)/2 );

            if (tones[index].LowBorder < FREQ && FREQ < tones[index].UpBorder)
            {
                int error = Tones[index].getError(FREQ);
                return new Tuple<Tone, int>(Tones[index], error);
            }

            if (FREQ < Tones[index].LowBorder) return getTone(FREQ, START_IDX, index);
            if (Tones[index].UpBorder < FREQ) return getTone(FREQ, index, END_IDX);
            
            return null;

        }
    }
}
