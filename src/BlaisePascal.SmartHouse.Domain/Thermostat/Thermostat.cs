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
        public Temperature Temperature { get; private set; }
        private int DefaultStep { get; set; } = 4;
        public Temperature DefaultTemperature { get; private set; } = Temperature.CreateNew(18);
        public Temperature MinTemperature { get; private set; } = Temperature.CreateNew(10);
        public Temperature MaxTemperature { get; private set; } = Temperature.CreateNew(30);
        public Thermostat(string name, int initialTemperature) : base(name)
        {
            Temperature = Temperature.CreateNew(initialTemperature);
        }

        public Thermostat(string name) : this(name, 18)
        {
            Temperature = DefaultTemperature;
        }

        public void SetTemperature(int temperature)
        {
            ThermostatValidator.CheckIsOn(Status);
            Temperature = Temperature.CreateNew(temperature);
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
