using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction
{
    public interface IAbstractLamp: IDevice
    {
        void Brighten(int value);
        void Dimmer(int value);
        void SetBrightness(Brightness brightness);
    }
}
