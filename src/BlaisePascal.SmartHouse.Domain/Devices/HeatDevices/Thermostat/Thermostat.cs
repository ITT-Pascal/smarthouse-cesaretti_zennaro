using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat
{
    public class Thermostat : AbstractDevice
    {
        public ThermostatTemperature Temperature { get; private set; }
        public ThermostatTemperature DefaultTemperature { get; private set; } = ThermostatTemperature.CreateNew(18);
        public ThermostatTemperature MinTemperature { get; private set; } = ThermostatTemperature.CreateNew(10);
        public ThermostatTemperature MaxTemperature { get; private set; } = ThermostatTemperature.CreateNew(30);
        public int DefaultStep { get; private set; } = 4;

        public Thermostat(Name name, ThermostatTemperature initialTemperature) : base(name)
        {
            Temperature = initialTemperature;
        }

        public Thermostat(Name name) : base(name)
        {
            Temperature = DefaultTemperature;
        }

        public void SetTemperature(ThermostatTemperature temperature)
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
            Temperature = ThermostatTemperature.CreateNew(Temperature + DefaultStep);
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseTemperature(int value)
        {
            ThermostatValidator.CheckIsOn(Status);
            ThermostatValidator.CheckIsPositive(value);
            Temperature = ThermostatTemperature.CreateNew(Temperature + value);
            LastModified = DateTime.UtcNow;
        }

        public void DecreaseTemperature()
        {
            ThermostatValidator.CheckIsOn(Status);
            Temperature = ThermostatTemperature.CreateNew(Temperature - DefaultStep);
            LastModified = DateTime.UtcNow;
        }

        public void DecreaseTemperature(int value)
        {
            ThermostatValidator.CheckIsOn(Status);
            ThermostatValidator.CheckIsPositive(value);
            Temperature = ThermostatTemperature.CreateNew(Temperature - value);
            LastModified = DateTime.UtcNow;
        }
    }
}
