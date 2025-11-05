using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public abstract class AbstractLamp
    {
        public bool IsOn { get; protected set; }
        public int BrightnessPercentage { get; protected set; }

        public abstract void SwitchOn_Off();

        public abstract void ChangeBrightness(int newBrightness);

        public abstract int BrightnessValidator(int newBrightness);
    }
}
