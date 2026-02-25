using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Door;
using BlaisePascal.SmartHouse.Domain.Devices.Door.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat
{
    public class Thermostat : AbstractDevice, IHeatDevices
    {
        public Temperature Temperature { get; private set; }
        public Temperature MinTemperature { get; private set; } = Temperature.CreateNew(10);
        public Temperature MaxTemperature { get; private set; } = Temperature.CreateNew(30);
        public Temperature DefaultTemperature { get; private set; } = Temperature.CreateNew(18);
        public int DefaultStep { get; private set; } = 4;

        public Thermostat(Name name, Temperature initialTemperature) : base(name)
        {
            Temperature = Temperature.ThermostatCreateNew(initialTemperature.Value);
        }

        public Thermostat(Name name) : base(name)
        {
            Temperature = DefaultTemperature;
        }

        public Thermostat(Guid id, Name name, DeviceStatus deviceStatus, DateTime creationHour, DateTime lastModified, Temperature initialTemperature) : base(id, name, deviceStatus, creationHour, lastModified)
        {
            Temperature = Temperature.ThermostatCreateNew(initialTemperature.Value);
        }

        public void SetTemperature(Temperature temperature)
        {
            ThermostatValidator.CheckIsOn(DeviceStatus);
            Temperature = Temperature.ThermostatCreateNew(temperature.Value);
            LastModified = DateTime.UtcNow;
        }

        public void SetTemperature()
        {
            ThermostatValidator.CheckIsOn(DeviceStatus);
            Temperature = DefaultTemperature;
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseTemperature()
        {
            ThermostatValidator.CheckIsOn(DeviceStatus);
            Temperature = Temperature.ThermostatCreateNew(Temperature + DefaultStep);
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseTemperature(int value)
        {
            ThermostatValidator.CheckIsOn(DeviceStatus);
            ThermostatValidator.CheckIsPositive(value);
            Temperature = Temperature.ThermostatCreateNew(Temperature + value);
            LastModified = DateTime.UtcNow;
        }

        public void DecreaseTemperature()
        {
            ThermostatValidator.CheckIsOn(DeviceStatus);
            Temperature = Temperature.ThermostatCreateNew(Temperature - DefaultStep);
            LastModified = DateTime.UtcNow;
        }

        public void DecreaseTemperature(int value)
        {
            ThermostatValidator.CheckIsOn(DeviceStatus);
            ThermostatValidator.CheckIsPositive(value);
            Temperature = Temperature.ThermostatCreateNew(Temperature - value);
            LastModified = DateTime.UtcNow;
        }
    }
}
