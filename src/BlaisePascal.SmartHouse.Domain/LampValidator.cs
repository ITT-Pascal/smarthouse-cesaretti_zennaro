using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public static class LampValidator
    {
        public static int BrightnessValidator(int brightness)
        {
            if (brightness < 0 || brightness > 100)
                throw new ArgumentException("Brightness not valid");
            return brightness;
        }
    }
}
