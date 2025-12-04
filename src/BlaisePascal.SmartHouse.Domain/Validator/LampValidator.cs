using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain.Illumination;

namespace BlaisePascal.SmartHouse.Domain.Validator
{
    public static class LampValidator
    {
        public const int MaxBrightness = 100;
        public const int MinBrightness = 0;

        public static int BrightnessValidator(int brightness)
        {
            if (brightness < MinBrightness)
                brightness = MinBrightness;
            else if (brightness > MaxBrightness)
                brightness = MaxBrightness;
            return brightness;
        }

        public static int IsStepValid(int value)
        {
            if (value <= 0 )
                throw new ArgumentException("step must be greater than 0");
            
            return value;
        }

        public static int IsPositionValid(int value)
        {
            if(value < 0)
                throw new ArgumentException("position must be almost 0");
            

            return value;
        }

        public static int IsValueInMinMax(int value, int min, int max)
        {
            if(value < min || value > max)
                throw new ArgumentException("value must be in min, max");

            return value;
        }
       

     



      
    }
}
