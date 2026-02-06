using BlaisePascal.SmartHouse.Domain.Asbtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Illumination.Abstraction
{
    public static class AbstractLampValidator
    {
        public const int MinBrightness = 0;
        public const int MaxBrightness = 100;

        public static void CheckIsOn(DeviceStatus status)
        {
            if (status != DeviceStatus.On)
                throw new InvalidOperationException("Cannot modify lamp when device is off");
        }

        public static int IsPositive(int value)
        {
            if (value <= 0)
                throw new ArgumentException("value must be greater than 0");

            return value;
        }

     
    }
}
