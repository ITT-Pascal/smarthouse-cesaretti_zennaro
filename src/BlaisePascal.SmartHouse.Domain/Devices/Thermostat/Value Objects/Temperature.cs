using BlaisePascal.SmartHouse.Domain.Devices.Thermostat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Thermostat
{
    public sealed record Temperature
    {
        public int value { get; init; }

        private Temperature(int temperature)
        {
            this.value = temperature;
        }
        
        public static Temperature CreateNew(int temperature)
        {
            if(temperature < ThermostatValidator.MinTemperature || temperature > ThermostatValidator.MaxTemperature)
                throw new ArgumentException($"Temperature must be between {ThermostatValidator.MinTemperature} and {ThermostatValidator.MaxTemperature}");

            return new Temperature(temperature);
        }

        public static int operator +(Temperature temperature, int value)
        {
            return temperature.value + value;
        }

        public static int operator -(Temperature temperature, int value)
        {
            return temperature.value - value;
        }
    }
}
