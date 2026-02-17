using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.LuminuosDevices
{
    public class EcoLampValidator
    {
        public const int MinBrightness = 0;
        public const int MaxBrightness = 75;
        public static int BrightnessValidator(int value)
        {
            if (value < MinBrightness)
                return MinBrightness;

            if (value > MaxBrightness)
                return MaxBrightness;

            return value;
        }
    }
}
