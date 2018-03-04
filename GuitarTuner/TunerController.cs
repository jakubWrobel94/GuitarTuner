using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarTuner
{
    /// <summary>
    /// Controls communication between view UI and tuner models.
    /// </summary>
    public class TunerController
    {
        private ITunerView      view;
        private PitchDetector   pitchDetector;
        private Tuning          tuningType;

        public TunerController(ITunerView VIEW, PitchDetector DETECTOR)
        {      
            tuningType = new Tuning();
            tuningType.SetStandardTuning();
            pitchDetector = DETECTOR;
            view = VIEW;
            view.SetController(this);
            view.DrawStringsLabels(tuningType);
            view.SetDeviceList(GetDeviceList());
            view.SetTuningsListBox(tuningType);
            view.DeviceNumber = 0;

            pitchDetector.FundamentalDetector.Recorder.Buffer.BufferFilled += OnBufferFilled;
            pitchDetector.PitchFound += OnPitchFound;
        }

        private void OnBufferFilled(object o, BufferFilledEventArgs e)
        {
            view.ChangeVolumeLevel(e.Volume + 90);
        }

        private void OnPitchFound(object o, PitchFoundEventArgs e)
        {
            view.ChangePitch(e.CurrentPitch);
            view.ChangeError(e.Error);
            if (PitchIsCorrect(e.CurrentPitch) && ErrorIsCorrect(e.Error))
                view.ChangePitchLabelColor(true);
            else
                view.ChangePitchLabelColor(false);
            view.ChangePitchBar((int)pitchDetector.FundamentalDetector.FundamentalFrequency);
            view.AddDataToChart(pitchDetector.FundamentalDetector.Autocorrelator.Output);
        }

        public void StartDetecting()
        {
            pitchDetector.StartDetecting(view.DeviceNumber);
            view.AddDataToChart(pitchDetector.FundamentalDetector.Autocorrelator.Output);
            view.SetDevicesBoxEnable(false);
        }

        public void StopDetecting()
        {
            pitchDetector.Stop();
            view.SetDevicesBoxEnable(true);
        }

        List<String> GetDeviceList()
        {          
            int deviceCount = NAudio.Wave.WaveIn.DeviceCount;
            var deviceList = new List<string>(deviceCount);
            for(int i = 0; i < deviceCount; ++i)
            {
                deviceList.Add(NAudio.Wave.WaveIn.GetCapabilities(i).ProductName);
            }
            return deviceList;
        }

        public void ChangeTuning(int INDEX)
        {
            tuningType.SetTuning(INDEX);
            view.ClearStringLabels();
            view.DrawStringsLabels(tuningType);
        }

        /// <summary>
        /// Returns true when detected pitch is equal to one of the current tuning strings pitch. 
        /// Otherwise returns false
        /// </summary>
        /// <param name="PITCH"></param>
        /// <returns></returns>
        public bool PitchIsCorrect(Pitch PITCH)
        {
            foreach(var stringPitch in tuningType.StringsPitches)
            {
                if (Math.Abs(stringPitch.Fundamental - PITCH.Fundamental) < 0.1)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Returns true when error is between -5 and 5 cents
        /// </summary>
        /// <param name="ERROR"></param>
        /// <returns></returns>
        public bool ErrorIsCorrect(int ERROR)
        {
            if (-5 <= ERROR && ERROR <= 5)
                return true;
            else
                return false;
        }
    }
}
