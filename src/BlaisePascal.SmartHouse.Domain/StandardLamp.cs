namespace BlaisePascal.SmartHouse.Domain
{
    public class StandardLamp : AbstractLamp
    {
        private const int MaxBrightness = 100;
        private const int MinBrightness = 0;
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
                BrightnessPercentage = BrightnessValidator(newBrightness);
        }
        public override void IncreaseBrightness(int increaseBy)
        {
            if (IsOn)
                BrightnessPercentage = BrightnessValidator(BrightnessPercentage + increaseBy);
        }
        public override void DecreaseBrightness(int decreaseBy)
        {
            if (IsOn)
                BrightnessPercentage = BrightnessValidator(BrightnessPercentage - decreaseBy);
        }

        public override int BrightnessValidator(int newBrightness)
        {
            if (newBrightness < MinBrightness || newBrightness > MaxBrightness)
                throw new ArgumentException("Brightness not valid");
            return newBrightness;
        }
    }
}
