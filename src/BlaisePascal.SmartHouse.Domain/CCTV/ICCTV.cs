using BlaisePascal.SmartHouse.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTV
{
    public interface ICCTV: IDevice
    {
        void SetRotationDegrees(float degrees);
        void IncreaseRotationDegrees(int value);
        void DecreaseRotationDegrees(int value);
        void SetZoom(float zoom);
        void IncreaseZoom(int value);
        void DecreaseZoom(int value);
        void StartRecording();
        void StopRecording();
        float GetMaxZoom();
        float GetMinZoom();
        float GetMaxRotationDegrees();
        float GetMinRotationDegrees();
    }
}
