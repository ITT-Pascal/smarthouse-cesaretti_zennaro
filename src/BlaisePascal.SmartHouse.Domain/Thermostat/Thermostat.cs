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
        private int DefaultStep { get; set; } = 4;
        public int DefaultTemperature { get; private set; } = 18;
        public int MinTemperature { get; private set; } = ThermostatValidator.MinTemperature;
        public int MaxTemperature { get; private set; } = ThermostatValidator.MaxTemperature;

        public Thermostat(string name, int initialTemperature) : base(name)
        {
            SetTemperature(initialTemperature);
        }

        public Thermostat(string name) : this(name, 18)
        {
            SetTemperature(DefaultTemperature);
        }

        public void SetTemperature(int temperature)
        {
            ThermostatValidator.CheckIsOn(Status);
            Temperature = ThermostatValidator.TemperatureValidator(temperature);
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
            SetTemperature(Temperature + DefaultStep);
            LastModified = DateTime.UtcNow;
        }

        public void DecreaseTemperature()
        {
            ThermostatValidator.CheckIsOn(Status);
            SetTemperature(Temperature - DefaultStep);
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
    }
}
