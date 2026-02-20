using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
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
            Temperature = initialTemperature;
        }

        public Thermostat(Name name) : base(name)
        {
            Temperature = DefaultTemperature;
        }

        public void SetTemperature(Temperature temperature)
        {
            ThermostatValidator.CheckIsOn(Status);
            Temperature = temperature;
            LastModified = DateTime.UtcNow;
        }

        public void SetTemperature()
        {
            ThermostatValidator.CheckIsOn(Status);
            Temperature = DefaultTemperature;
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseTemperature()
        {
            ThermostatValidator.CheckIsOn(Status);
            Temperature = Temperature.CreateNew(Temperature + DefaultStep);
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseTemperature(int value)
        {
            ThermostatValidator.CheckIsOn(Status);
            ThermostatValidator.CheckIsPositive(value);
            Temperature = Temperature.CreateNew(Temperature + value);
            LastModified = DateTime.UtcNow;
        }

        public void DecreaseTemperature()
        {
            ThermostatValidator.CheckIsOn(Status);
            Temperature = Temperature.CreateNew(Temperature - DefaultStep);
            LastModified = DateTime.UtcNow;
        }

        public void DecreaseTemperature(int value)
        {
            ThermostatValidator.CheckIsOn(Status);
            ThermostatValidator.CheckIsPositive(value);
            Temperature = Temperature.CreateNew(Temperature - value);
            LastModified = DateTime.UtcNow;
        }
    }
}
