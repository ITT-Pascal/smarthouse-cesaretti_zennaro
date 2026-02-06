using BlaisePascal.SmartHouse.Domain.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.Illumination.Abstraction
{
    public interface IAbstractLamp: IDevice
    {
        void Brighten(int step);
        void Dimmer(int step);
        void SetBrightness(int brightness);
    }
}
