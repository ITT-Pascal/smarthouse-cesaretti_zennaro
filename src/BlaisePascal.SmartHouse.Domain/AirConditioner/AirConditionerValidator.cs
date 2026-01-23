using BlaisePascal.SmartHouse.Domain.Asbtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.AirConditioner
{
    public static class AirConditionerValidator
    {
        public const int MaxTemperature = 50;
        public const int MinTemperature = 0;
        public const int DefaultTemperature = 18;

        public static void CheckIsOn(DeviceStatus status)
        {
            if (status != DeviceStatus.On)
                throw new InvalidOperationException("cannot modify air conditioner when it is off");
        }
        public static int SetTemperatureValueValidator(int value)
        {
            if (value < MinTemperature)
                return MinTemperature;

            if (value > MaxTemperature)
                return MaxTemperature;

            return value;
        }

        public static int CheckIsPositive(int value)
        {
            if (value <= 0)
                throw new ArgumentException("value must be greater than 0");
            return value;
        }
    }
}
