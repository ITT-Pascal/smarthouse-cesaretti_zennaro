using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.Interfaces;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.Abstraction
{
    public interface IDevice: ISwitchable
    {
        void Rename(Name name);
    }
}
