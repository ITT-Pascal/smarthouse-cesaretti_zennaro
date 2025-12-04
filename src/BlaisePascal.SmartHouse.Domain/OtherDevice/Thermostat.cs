using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Thermostat : AbstractDevice
    {
        public int Temperature { get; private set; }
        public const int DefaultStep = 1;
        public int Step { get; private set; }
        public const int DefaultTemperature = 20;
        public Thermostat(string name, int initialTemperature) : base(name)
        {
            Temperature = ThermostatValidator.TemperatureValidator(initialTemperature);
            Status = ObjectStatus.DeviceStatus.On;
            Step = DefaultStep;
        }
        public Thermostat(string name) : this(name, DefaultTemperature) { }
        public void IncreaseTemperature()
        {
            Temperature = ThermostatValidator.TemperatureValidator(Temperature + DefaultStep);
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature()
        {
            Temperature = ThermostatValidator.TemperatureValidator(Temperature - DefaultStep);
            LastModified = DateTime.UtcNow;
        }
        public void SetTemperature(int temperature)
        {
            Temperature = ThermostatValidator.TemperatureValidator(temperature);
            LastModified = DateTime.UtcNow;
        }
        public void IncreaseTemperature(int step)
        {
            Temperature = ThermostatValidator.TemperatureValidator(Temperature + step);
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature(int step)
        {
            Temperature = ThermostatValidator.TemperatureValidator(Temperature - step);
            LastModified = DateTime.UtcNow;
        }
    }
}
