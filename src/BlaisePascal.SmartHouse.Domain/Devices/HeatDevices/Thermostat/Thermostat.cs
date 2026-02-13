using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat
{
    //FINISHED
    public class Thermostat : AbstractDevice, IHeatDevices
    {
        public ThermostatTemperature Temperature { get; private set; }
        private int DefaultStep { get; set; } = 4;
        public ThermostatTemperature DefaultTemperature { get; private set; } = ValueObjects.AirConditionerTemperature.CreateNew(18);
        public ThermostatTemperature MinTemperature { get; private set; } = ValueObjects.AirConditionerTemperature.CreateNew(10);
        public ThermostatTemperature MaxTemperature { get; private set; } = ValueObjects.AirConditionerTemperature.CreateNew(30);
        public Thermostat(string name, int initialTemperature) : base(name)
        {
            Temperature = ThermostatTemperature.CreateNew(initialTemperature);
        }

        public Thermostat(string name) : base(name)
        {
            Temperature = DefaultTemperature;
        }

        public void SetTemperature(int temperature)
        {
            ThermostatValidator.CheckIsOn(Status);
            temperature = ThermostatValidator.TemperatureValueValidator(temperature);
            Temperature = ThermostatTemperature.CreateNew(temperature);
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
