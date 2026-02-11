using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Asbtraction;

namespace BlaisePascal.SmartHouse.Domain.Devices.Illumination
{
    public static class LampValidator
    {
        private const int MaxBrightness = 100;
        private const int MinBrightness = 0;

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
