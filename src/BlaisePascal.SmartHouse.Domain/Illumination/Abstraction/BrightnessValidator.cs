using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Illumination.Abstraction
{
    public static class BrightnessValidator
    {
        public const int MinBrightness = 0;
        public const int MaxBrightness = 100;

        public static int Validator(int brightness)
        {
            if (brightness < MinBrightness)
                return MinBrightness;

            if (brightness > MaxBrightness)
                return MaxBrightness;

            return brightness;
        }
    }
    
}
