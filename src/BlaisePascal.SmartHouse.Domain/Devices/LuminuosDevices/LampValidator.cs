using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.Devices.Illumination
{
    public static class LampValidator
    {
        public const int MinBrightness = 0;
        public const int MaxBrightness = 100;
        public static int BrightnessValidator(int value)
        {
            if (value < MinBrightness)
                return MinBrightness;

            if (value > MaxBrightness)
                return MaxBrightness;

            return value;
        }
        public static int IsPositionValid(int value)
        {
            if(value < 0)
                throw new ArgumentException("position must be almost 0");

            return value;
        }

        public static int IsInMinMax(int value, int min, int max)
        {
            if(value < min || value > max)
                throw new ArgumentException("value must be in min, max");

            return value;
        }
    }
}
