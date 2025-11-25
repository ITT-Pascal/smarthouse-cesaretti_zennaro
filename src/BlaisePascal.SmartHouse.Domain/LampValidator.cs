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

        public static int IsPositionInMinMax(int position, int min, int max)
        {
            if(position >=  min && position <= max)
            {
                return position;
            } else
            {
                throw new ArgumentException("positon not valid");
            }
        }

        public static int IsPositivePosition(int position)
        {
            if(position < 0)
            {
                throw new ArgumentException("position not valid");
            }
            else
            {
                return position;
            }
        }

        public static int IsInBrightnessRange(int value)
        {
            if(value >= MinBrightness && value <= MaxBrightness)
            {
                return value;
            } else
            {
                throw new ArgumentException($"value must be in {MinBrightness} and {MaxBrightness}");
            }
        }

     



      
    }
}
