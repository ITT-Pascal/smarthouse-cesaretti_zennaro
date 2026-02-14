using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat
{
    public interface IThermostat: IHeatDevices
    {
        void SetTemperature(ThermostatTemperature temperature);
    }
}
