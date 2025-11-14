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

        public void SwitchOn()
        {
            if (!IsOn)
                IsOn = true;   
        }

        public void SwitchOff()
        {
            if (IsOn)
                IsOn = false;
        }
        public void ChangeBrightness(int newBrightness)
        {
            if (IsOn)
                BrightnessPercentage = Validator.BritghnessValue(newBrightness);
        }
        public void IncreaseBrightness(int increaseBy)
        {
            if (IsOn)
            {
                BrightnessPercentage += Validator.Value(increaseBy);
                if(BrightnessPercentage > 100)
                    BrightnessPercentage = 100;
            }
                
        }
        public void DecreaseBrightness(int decreaseBy)
        {
            if (IsOn)
            {
                BrightnessPercentage -= Validator.Value(decreaseBy);
                if (BrightnessPercentage < 0)
                    BrightnessPercentage = 0;
            }
                
        }
    }
}
