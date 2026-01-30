using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    public sealed record Brightness
    {
        public int value {  get; private set; }
        public Brightness(int brightness)
        {
            if (brightness < 0 || brightness > 100)
                throw new ArgumentException("brightness must be between 0 and 100");

            this.value = brightness;
        }

        public static Brightness CreateNew(int brightness)
        {
            return new Brightness(brightness);
        }
    }
}
