using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.AirConditioner
{
    public static class AirConditionerValidator
    {
        private const int MaxTemperature = 50;
        private const int MinTemperature = 0;
        public static int SetTemperatureValueValidator(int value)
        {
            if (value < MinTemperature)
                return MinTemperature;
            else if (value > MaxTemperature)
                return MaxTemperature;
            else 
                return value;
        }

        public static int IncreaseValueValidator(int value)
        {
            if (value <= 0)
                throw new ArgumentException("value must be greater than 0");
            return value;
        }
    }
}
