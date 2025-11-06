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
            if (newBrightness < 0 || newBrightness > 100)
                throw new ArgumentException("Brightness not valid");
            return newBrightness;
        }
    }
}
