namespace BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction
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
            return new Brightness(LampValidator.BrightnessValidator(brightness));
        }

        public static int operator +(Brightness brightness, int value)
        {
            return brightness.value + value;
        }


        public static int operator -(Brightness brightness, int value)
        {
            return brightness.value - value;
        }


        public static bool operator >(Brightness brightness1, Brightness brightness2)
        {
            return brightness1.value > brightness2.value;
        }
        public static bool operator <(Brightness brightness1, Brightness brightness2)
        {
            return brightness1.value < brightness2.value;
        }


        public static bool operator >=(Brightness brightness1, int value)
        {
            return brightness1.value >= value;
        }

        public static bool operator <=(Brightness brightness1, int value)
        {
            return brightness1.value <= value;
        }
    }
}
