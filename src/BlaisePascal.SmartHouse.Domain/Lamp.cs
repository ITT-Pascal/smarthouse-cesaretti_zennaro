namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        public bool IsOn { get; private set; }
        public int BrightnessPercentage { get; private set; }
        public Lamp(int brightness)
        {
            IsOn = true;
            ChangeBrightness(brightness);
        }

        public Lamp()
        {
            IsOn = false;
            BrightnessPercentage = 0;
        }


        public void SwitchOn_Off()
        {
            if (IsOn) 
            {
                IsOn = false;
                BrightnessPercentage = 0;
            } else
            {
                IsOn = true;
                ChangeBrightness(100);
            }

        }
        public void ChangeBrightness(int newBrightness)
        {
            if (IsOn == true)
            {
                BrightnessPercentage = LampValidator.BrightnessValidator(newBrightness);
                if (BrightnessPercentage == 0)
                {
                    IsOn = false;
                }
            }
            
        }
    }
}
