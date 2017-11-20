using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarTuner
{
    class Tone
    {
        string name;
        float pitch;
        float lowBorder;
        float upBorder;

        float diffToNext;
        float diffToPrev;
        float factor = (float)Math.Pow(2, (1 / (double)12));

        public Tone(float PITCH, string NAME)
        {
            Pitch = PITCH;
            Name = NAME;

            float prevTonePitch = Pitch / factor;
            DiffToPrev = pitch - prevTonePitch;
            LowBorder = pitch - DiffToPrev / 2;

            float nextTonePitch = Pitch * factor;
            diffToNext = nextTonePitch - Pitch;
            upBorder = Pitch + diffToNext / 2;

        }
        
        public int getError(float FREQ)
        {
            float diffrence = FREQ - pitch;

            if (FREQ < Pitch)
            {
                return (int)((diffrence / DiffToPrev) * 100);
            }

            if(Pitch < FREQ)
            {
                return (int)((diffrence / DiffToNext) * 100);
            }

            return 0;
        }

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

        public float Pitch
        {
            get
            {
                return pitch;
            }

            set
            {
                pitch = value;
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
    }
}
