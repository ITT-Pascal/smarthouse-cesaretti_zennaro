using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp : AbstractLamp
    {
        // TODO: make this Lamp Eco.
        public EcoLamp(int brightness)
        {
            IsOn = true;
            ChangeBrightness(brightness);
        }

        public EcoLamp()
        {
            IsOn = false;
            BrightnessPercentage = 0;
        }

        public override void SwitchOn_Off()
        {
            IsOn = !IsOn;
        }
        public override void ChangeBrightness(int newBrightness)
        {
            if (IsOn)
                BrightnessPercentage = BrightnessValidator(newBrightness);
        }

        public override int BrightnessValidator(int newBrightness)
        {
            if (newBrightness < 0 || newBrightness > 100)
                throw new ArgumentException("Brightness not valid");
            return newBrightness;
        }
    }
}
