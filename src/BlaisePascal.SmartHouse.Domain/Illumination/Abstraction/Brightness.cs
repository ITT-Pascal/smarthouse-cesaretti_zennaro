using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Illumination.Abstraction
{
    public sealed record Brightness
    {
        public int value { get; init; }
        private Brightness(int brightness)
        {
            value = brightness;
        }

        public static Brightness CreateNew(int brightness)
        {
            BrightnessValidator.Validator(brightness);
            return new Brightness(brightness);
        }

        public static int operator +(Brightness brightness, int value)
        {
            return brightness.value + value;
        }

        public static int operator -(Brightness brightness, int value)
        {
            return brightness.value - value;
        }

        public static bool operator ==(Brightness brightness, int value) 
        {
            return brightness.value == value;
        }

        public static bool operator !=(Brightness brightness, int value)
        {
            return brightness.value != value;
        }
        public static bool operator >(Brightness brightness, int value)
        {
            return brightness.value > value;
        }

        public static bool operator >(Brightness brightness1, Brightness brightness2)
        {
            return brightness1.value == brightness2.value;
        }

        public static bool operator <(Brightness brightness1, Brightness brightness2)
        {
            return brightness1.value == brightness2.value;
        }

        public static bool operator <(Brightness brightness, int value)
        {
            return brightness.value > value;
        }

        public static bool operator <=(Brightness brightness, int value)
        {
            return brightness.value > value;
        }

        public static bool operator >=(Brightness brightness, int value)
        {
            return brightness.value > value;
        }
    }
}
