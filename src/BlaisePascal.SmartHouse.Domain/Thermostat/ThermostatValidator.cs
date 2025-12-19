using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Thermostat
{
    public static class ThermostatValidator
    {
        private const int MaxTemperature = 30;
        private const int MinTemperature = 10;
        public static int TemperatureValidator(int temperature)
        {
            if (temperature < MinTemperature || temperature > MaxTemperature)
                throw new ArgumentOutOfRangeException($"Temperature must be between {MinTemperature} and {MaxTemperature} degrees Celsius.");
            return temperature;
        }
    }
}
