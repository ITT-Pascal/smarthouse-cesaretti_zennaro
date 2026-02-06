using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Thermostat
{
    public static class TemperatureValidator
    {
        public const int MaxTemperature = 30;
        public const int MinTemperature = 10;

        public static int Validator(int temperature)
        {
            if (temperature > MaxTemperature)
                return MaxTemperature;

            if (temperature < MinTemperature)
                return MinTemperature;

            return temperature;
        }
    }
}
