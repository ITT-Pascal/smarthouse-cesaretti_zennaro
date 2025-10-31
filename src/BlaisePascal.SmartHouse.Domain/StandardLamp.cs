namespace BlaisePascal.SmartHouse.Domain
{
    public class StandardLamp : Lamp
    {

        public StandardLamp(int brigthness) 
        {
            IsOn = true;
            ChangeBrightness(brigthness);
        } 

        public StandardLamp()
        {
            IsOn = false;
            BrightnessPercentage = 0;
        }

        public override void SwitchOn_Off()
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
        public override void ChangeBrightness(int newBrightness)
        {
            if (newBrightness < 0 || newBrightness > 100)
                throw new ArgumentException("Brightness not valid");
            if (IsOn == true)
            {
                if(newBrightness == 0)
                {
                    BrightnessPercentage = newBrightness;
                    IsOn = false;
                } else
                {
                    BrightnessPercentage = newBrightness;
                }
            }

        }
    }
}
