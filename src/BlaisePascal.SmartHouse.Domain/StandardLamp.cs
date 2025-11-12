namespace BlaisePascal.SmartHouse.Domain
{
    public class StandardLamp : AbstractLamp
    {
        public StandardLamp(int brightness) 
        {
            IsOn = true;
            ChangeBrightness(brightness);
        } 

        public StandardLamp()
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
                BrightnessPercentage = Validator.Brightness(newBrightness);
        }
        public override void IncreaseBrightness(int increaseBy)
        {
            if (IsOn)
            {
                if(BrightnessPercentage + increaseBy > MaxBrightness)
                {
                    BrightnessPercentage = MaxBrightness;
                } else
                {
                    BrightnessPercentage += Validator.Value(increaseBy);
                }
            }
                
        }
        public override void DecreaseBrightness(int decreaseBy)
        {
            if (IsOn)
            {
                if(BrightnessPercentage - decreaseBy < MinBrightness)
                {
                    BrightnessPercentage = MinBrightness;
                } else
                {
                    BrightnessPercentage -= Validator.Value(decreaseBy);
                }
            }
                
        }
    }
}
