using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.Devices.CCTV
{
    public interface ICCTV: IDevice
    {
        void SetRotationDegrees();
        void SetRotationDegrees(float degrees);
        void IncreaseRotationDegrees();
        void IncreaseRotationDegrees(int value);
        void DecreaseRotationDegrees();
        void DecreaseRotationDegrees(int value);
        void SetZoom();
        void SetZoom(float zoom);
        void IncreaseZoom();
        void IncreaseZoom(int value);
        void DecreaseZoom();
        void DecreaseZoom(int value);
        void StartRecording();
        void StopRecording();
    }
}
