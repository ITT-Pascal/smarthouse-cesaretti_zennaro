using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public static class LampValidator
    {
        public const int MaxBrightness = 100;
        public const int MinBrightness = 0;

        public static int Britghness(int brightness)
        {
            if (brightness < MinBrightness)
                brightness = MinBrightness;
            else if (brightness > MaxBrightness)
                brightness = MaxBrightness;
            return brightness;
        }

        public static int Value(int value)
        {
            if (value <= 0 )
                throw new ArgumentException("value must be greater than 0");
            return value;
        }



      
    }
}
