using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarTuner
{
    class Tuning
    {
        string name;
        List<Tone> stringTones;

        public Tuning()
        {
            StringTones = new List<Tone>();
        }

        internal List<Tone> StringTones
        {
            get
            {
                return stringTones;
            }

            set
            {
                stringTones = value;
            }
        }

        public void AddString(string KEY, float PITCH)
        {
            StringTones.Add(new GuitarTuner.Tone(PITCH, KEY));
        }
    }
}
