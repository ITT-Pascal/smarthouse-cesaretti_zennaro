using BlaisePascal.SmartHouse.Domain.Asbtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Thermostat
{
    public class Thermostat : AbstractDevice
    {
        public int Temperature { get; private set; }
        public int DefaultStep { get; private set; } = 1;
        public int Step { get; private set; }
        public int DefaultTemperature { get; private set; } = 18;

        public Thermostat(string name, int initialTemperature) : base(name)
        {
            Temperature = ThermostatValidator.TemperatureValidator(initialTemperature);
            Status = DeviceStatus.On;
            Step = DefaultStep;
        }

        public Thermostat(string name) : base(name)
        {
            Temperature = DefaultTemperature;
            Status = DeviceStatus.On;
            Step = DefaultStep;
        }
        public void IncreaseTemperature()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot set thermostat when it is off");
            Temperature = ThermostatValidator.TemperatureValidator(Temperature + DefaultStep);
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot set thermostat when it is off");
            Temperature = ThermostatValidator.TemperatureValidator(Temperature - DefaultStep);
            LastModified = DateTime.UtcNow;
        }
        public void SetTemperature(int temperature)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot set thermostat when it is off");
            Temperature = ThermostatValidator.TemperatureValidator(temperature);
            LastModified = DateTime.UtcNow;
        }
        public void IncreaseTemperature(int step)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot set thermostat when it is off");
            Temperature = ThermostatValidator.TemperatureValidator(Temperature + step);
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature(int step)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot set thermostat when it is off");
            Temperature = ThermostatValidator.TemperatureValidator(Temperature - step);
            LastModified = DateTime.UtcNow;
        }
    }
}
