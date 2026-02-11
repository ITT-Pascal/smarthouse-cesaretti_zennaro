using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Thermostat
{
    public sealed record Temperature
    {
        public const int MaxTemperature = 30;
        public const int MinTemperature = 10;

        public int value { get; init; }

        private Temperature(int value)
        {
            this.value = value;
        }
        
        public static Temperature CreateNew(int value)
        {
            TemperatureValidator.Validator(value);
            return new Temperature(value);
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
