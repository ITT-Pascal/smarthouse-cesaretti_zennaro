using BlaisePascal.SmartHouse.Domain.Asbtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Thermostat
{
    //FINISHED
    public class Thermostat : AbstractDevice, IThermostat
    {
        public int Temperature { get; private set; }
        private int DefaultStep { get; set; } = 1;
        public int Step { get; private set; }
        private int DefaultTemperature { get; set; } = 18;
        private int MinTemperature { get; set; } = ThermostatValidator.MinTemperature;
        private int MaxTemperature { get; set; } = ThermostatValidator.MaxTemperature;

        public Thermostat(string name, int initialTemperature) : base(name)
        {
            SetTemperature(initialTemperature);
            Status = DeviceStatus.On;
            Step = DefaultStep;
        }

        public Thermostat(string name) : this(name, 18)
        {
            SetTemperature(DefaultTemperature);
            Status = DeviceStatus.On;
            Step = DefaultStep;
        }

        public void IncreaseTemperature()
        {
            ThermostatValidator.CheckIsOn(Status);
            SetTemperature(Temperature + DefaultStep);
            LastModified = DateTime.UtcNow;
        }

        public void DecreaseTemperature()
        {
            ThermostatValidator.CheckIsOn(Status);
            SetTemperature(Temperature - DefaultStep);
            LastModified = DateTime.UtcNow;
        }

        public void SetTemperature(int temperature)
        {
            ThermostatValidator.CheckIsOn(Status);
            Temperature = ThermostatValidator.TemperatureValidator(temperature);
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseTemperature(int step)
        {
            ThermostatValidator.CheckIsOn(Status);
            ThermostatValidator.CheckIsPositive(step);
            SetTemperature(Temperature +  step);
            LastModified = DateTime.UtcNow;
        }

        public void DecreaseTemperature(int step)
        {
            ThermostatValidator.CheckIsOn(Status);
            ThermostatValidator.CheckIsPositive(step);
            SetTemperature(Temperature - step);
            LastModified = DateTime.UtcNow;
        }

        public int GetDefaultStep()
        {
            return DefaultStep;
        }

        public int GetDefaultTemperature()
        {
            return DefaultTemperature;
        }

        public int GetMinTemperature()
        {
            return MinTemperature;
        }

        public int GetMaxTemperature()
        {
            return MaxTemperature;
        }
    }
}
