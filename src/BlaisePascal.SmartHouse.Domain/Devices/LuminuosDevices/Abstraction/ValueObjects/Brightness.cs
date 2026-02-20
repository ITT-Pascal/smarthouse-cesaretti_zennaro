namespace BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction
{
    public sealed record Brightness
    {
        public int Value { get; init; }
        private Brightness(int brightness)
        {
            Value = brightness;
        }

        public static Brightness CreateNew(int brightness)
        {
            return new Brightness(LampValidator.BrightnessValidator(brightness));
        }

        public static int operator +(Brightness brightness, int value)
        {
            return brightness.Value + value;
        }


        public static int operator -(Brightness brightness, int value)
        {
            return brightness.Value - value;
        }


        public static bool operator >(Brightness brightness1, Brightness brightness2)
        {
            return brightness1.Value > brightness2.Value;
        }
        public static bool operator <(Brightness brightness1, Brightness brightness2)
        {
            return brightness1.Value < brightness2.Value;
        }


        public static bool operator >=(Brightness brightness1, int value)
        {
            return brightness1.Value >= value;
        }

        public static bool operator <=(Brightness brightness1, int value)
        {
            return brightness1.Value <= value;
        }
    }
}
