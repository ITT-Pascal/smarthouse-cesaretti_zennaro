using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner
{
    public interface IAirConditioner: IHeatDevices
    {
        void SetTemperature(AirConditionerTemperature temperature);
    }
}
