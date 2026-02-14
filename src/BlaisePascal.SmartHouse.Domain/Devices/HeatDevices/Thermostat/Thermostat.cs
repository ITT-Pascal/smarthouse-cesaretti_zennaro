using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Interfaces;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat
{
    //FINISHED
    public class Thermostat : AbstractDevice, IThermostat
    {
        public ThermostatTemperature Temperature { get; private set; }
        private int DefaultStep { get; set; } = 4;
        public ThermostatTemperature DefaultTemperature { get; private set; } = Temperature.CreateNew(18);
        public ThermostatTemperature MinTemperature { get; private set; } = AirConditionerTemperature.CreateNew(10);
        public ThermostatTemperature MaxTemperature { get; private set; } = AirConditionerTemperature.CreateNew(30);
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
            Temperature = ThermostatTemperature.CreateNew(Temperature + step);
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
            Temperature = ThermostatTemperature.CreateNew(Temperature - step);
            LastModified = DateTime.UtcNow;
        }
    }
}
