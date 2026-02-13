using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices
{
    public sealed record ThermostatTemperature
    {
        public int value { get; init; }

        private ThermostatTemperature(int temperature)
        {
            value = temperature;
        }
        
        public static ThermostatTemperature CreateNew(int temperature)
        {
            if(temperature < ThermostatValidator.MinTemperature || temperature > ThermostatValidator.MaxTemperature)
                throw new ArgumentException($"Temperature must be between {ThermostatValidator.MinTemperature} and {ThermostatValidator.MaxTemperature}");

            return new ThermostatTemperature(temperature);
        }

        public static int operator +(ThermostatTemperature temperature, int value)
        {
            return temperature.value + value;
        }

        public static int operator -(ThermostatTemperature temperature, int value)
        {
            return temperature.value - value;
        }
    }
}
