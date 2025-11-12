using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp : AbstractLamp
    {
        public TimeSpan Timer { get; set; }
        public DateTime EndHour { get; set; }
       
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
        public void EcoSwitchOn(TimeSpan timer)
        {
            if (!IsOn)
            {
                IsOn = true;
                Timer = timer;
                EndHour = DateTime.UtcNow.Add(Timer);
            }
            while (DateTime.UtcNow <= EndHour)
            {
                if (DateTime.UtcNow == EndHour)
                    IsOn = false;
            }
        }

        public override void SwitchOn_Off()
        {
            IsOn = !IsOn;
        }
        public override void ChangeBrightness(int newBrightness)
        {
            if (IsOn)
                BrightnessPercentage = Validator.Brightness(newBrightness);
        }
        public override void IncreaseBrightness(int increaseBy)
        {
            if (IsOn)
                BrightnessPercentage = Validator.Brightness(BrightnessPercentage + increaseBy);
        }
        public override void DecreaseBrightness(int decreaseBy)
        {
            if (IsOn)
                BrightnessPercentage = Validator.Brightness(BrightnessPercentage - decreaseBy);
        }
    }
}
