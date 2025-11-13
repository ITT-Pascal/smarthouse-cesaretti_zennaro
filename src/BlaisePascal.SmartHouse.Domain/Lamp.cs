namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        public bool IsOn { get; set; }
        public int BrightnessPercentage { get; set; }
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
            IsOn = !IsOn;
        }
        public void ChangeBrightness(int newBrightness)
        {
            if (IsOn)
                BrightnessPercentage = Validator.Brightness(newBrightness);
        }
        public void IncreaseBrightness(int increaseBy)
        {
            if (IsOn)
            {
                BrightnessPercentage = Validator.Brightness(BrightnessPercentage + Validator.Value(increaseBy));
            }
                
        }
        public void DecreaseBrightness(int decreaseBy)
        {
            if (IsOn)
            {
                BrightnessPercentage = Validator.Brightness(BrightnessPercentage - Validator.Value(decreaseBy));
            }
                
        }
    }
}
