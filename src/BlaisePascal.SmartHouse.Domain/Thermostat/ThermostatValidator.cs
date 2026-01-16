using BlaisePascal.SmartHouse.Domain.Asbtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Thermostat
{
    public static class ThermostatValidator
    {
        public const int MaxTemperature = 30;
        public const int MinTemperature = 10;

        public static void CheckIsOn(DeviceStatus deviceStatus)
        {
            if (deviceStatus != DeviceStatus.On)
                throw new InvalidOperationException("cannot modify thermostat when it is off");
        }
        
        public static void CheckIsPositive(int value)
        {
            if (value <= 0)
                throw new InvalidOperationException("value must be greater than 0");
        } 
        public static int TemperatureValidator(int temperature)
        {
            if (temperature < MinTemperature || temperature > MaxTemperature)
                throw new ArgumentOutOfRangeException($"Temperature must be between {MinTemperature} and {MaxTemperature} degrees Celsius.");
            return temperature;
        }
    }
}
