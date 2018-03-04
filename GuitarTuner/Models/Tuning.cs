using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarTuner
{
    /// <summary>
    /// Class representation of guitar tuning. Stores information about guitar strings pitches, and allows
    /// to choose tuning from few most popular guitar tunings.
    /// </summary>
    public class Tuning
    {
        string          name;
        List<Pitch>     stringsPitches;
        List<String>    tuningList;

        public Tuning()
        {
            stringsPitches = new List<Pitch>();
            tuningList = new List<string>
            {
                "Standard E",
                "Drop D",
                "Eb half step",
                "D whole step"
            };
        }

        public string Name { get => name; }
        public List<string> TuningList { get => tuningList; set => tuningList = value; }
        public List<Pitch> StringsPitches { get => stringsPitches; set => stringsPitches = value; }

        /// <summary>
        /// Gets tuning's name from list of possible tunings
        /// </summary>
        /// <param name="INDEX"></param>
        /// <returns></returns>
        public string GetTuningName(int INDEX)
        {
            return tuningList[INDEX];
        }

        /// <summary>
        /// Set current tuning from list of possible tunings
        /// </summary>
        /// <param name="INDEX"></param>
        public void SetTuning(int INDEX)
        {
            switch(INDEX)
            {
                case 0:
                    SetStandardTuning();
                    break;
                case 1:
                    SetDropDTuning();
                    break;
                case 2:
                    SetEbTuning();
                    break;
                case 3:
                    SetDTuning();
                    break;
            }

        }
        /// <summary>
        /// Add new string's pitch to current tuning.
        /// </summary>
        /// <param name="PITCH_NAME">Name of pitch</param>
        /// <param name="PITCH_FUNDAMENTAL">Fundamental frequency of pitch</param>
        public void AddString(string PITCH_NAME, float PITCH_FUNDAMENTAL)
        {
            stringsPitches.Add(new GuitarTuner.Pitch(PITCH_FUNDAMENTAL, PITCH_NAME));
        }

        public void SetStandardTuning()
        {
            if (name == "Standard E") return;

            stringsPitches.Clear();
            AddString("E6", 82.41f);
            AddString("A5", 110f);
            AddString("D4", 146.83f);
            AddString("G3", 196f);
            AddString("B2", 246.94f);
            AddString("E1", 329.63f);
            name = "Standard E";

        }

        public void SetDropDTuning()
        {
            if (name == "Drop D") return;

            stringsPitches.Clear();
            AddString("D6", 71.35f);
            AddString("A5", 110f);
            AddString("D4", 146.83f);
            AddString("G3", 196f);
            AddString("B2", 246.94f);
            AddString("E1", 329.63f);
            name = "Drop D";
        }

        public void SetEbTuning()
        {
            if (name == "Eb - half step") return;

            stringsPitches.Clear();
            AddString("Eb6", 77.8f);
            AddString("Ab5", 103.8f);
            AddString("Db4", 138.6f);
            AddString("Gb3", 185f);
            AddString("Bb2", 233.1f);
            AddString("Eb1", 311.1f);
            name = "Eb half step";
        }

        public void SetDTuning()
        {
            if (name == "D - whole step") return;

            stringsPitches.Clear();
            AddString("D6", 73.4f);
            AddString("G5", 98f);
            AddString("C4", 130.8f);
            AddString("F3", 174.6f);
            AddString("A2", 220f);
            AddString("D1", 293.7f);
            name = "D whole step";
        }
    }
}
