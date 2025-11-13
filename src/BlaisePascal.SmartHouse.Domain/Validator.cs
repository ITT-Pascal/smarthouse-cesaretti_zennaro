using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public static class Validator
    {
        private const int MaxBrightness = 100;
        private const int MinBrightness = 0;
        public static int Brightness(int newBrightness)
        {
            if (newBrightness < MinBrightness)
                return MinBrightness;
            else if (newBrightness > MaxBrightness)
                return MaxBrightness;
            else
                return newBrightness;
        }

        public static int Value(int value)
        {
            if (value <= 0)
                throw new ArgumentException("value must be greater than 0");
            return value;
        }
    }
}
