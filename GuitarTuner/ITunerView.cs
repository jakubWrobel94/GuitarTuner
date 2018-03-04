using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarTuner
{
    public interface ITunerView
    {
        void SetController(TunerController CONTROLLER);
        void SetTuningsListBox(Tuning TUNING);
        void SetDeviceList(IList<String> DEVICE_LIST);
        void SetDevicesBoxEnable(bool STATE);
        void ChangeVolumeLevel(float VOLUME);
        void ChangePitch(Pitch PITCH);
        void ChangeError(int ERROR_VAL);
        void ChangePitchLabelColor(bool GREEN_OR_RED);
        void ChangePitchBar(int FUNDAMENTAL);

        void AddDataToChart(float[] DATA);
        void RefreschChart();
        void DrawStringsLabels(Tuning TUNING);
        void ClearStringLabels();
       

        int DeviceNumber { get; set; }
        int TuningNumber { get; set; }
    }
}
