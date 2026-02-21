namespace BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction
{
    public sealed record Brightness
    {
        private const int MaxNormalBrightness = 100;
        private const int MaxEcoBrightness = 75;
        private const int MinNormalBrightness = 0;
        private const int MinEcoBrightness = 0;
          
        public int Value { get; init; }
        private Brightness(int brightness)
        {
            Value = brightness;
        }

        public static Brightness CreateNew(int brightness)
        {
            return new Brightness(brightness);
        }

         
        public static Brightness CreateNewNormal(int brightness)
        {
            if (brightness > MaxNormalBrightness)
                brightness = MaxNormalBrightness;

            if (brightness < MinNormalBrightness)
                brightness = MinNormalBrightness;

            return new Brightness(brightness);
        }

        public static Brightness CreateNewEco(int brightness)
        {
            if (brightness > MaxEcoBrightness)
                brightness = MaxEcoBrightness;

            if (brightness < MinEcoBrightness)
                brightness = MinEcoBrightness;

            return new Brightness(brightness);
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
