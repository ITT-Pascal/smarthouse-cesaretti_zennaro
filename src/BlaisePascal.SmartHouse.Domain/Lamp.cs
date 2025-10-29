namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        public bool IsOn {  get; private set; }
        public int BrightnessPercentage { get; private set; }
        public Lamp(bool isOn, int brightness)
        {
            IsOn = isOn;
            if (IsOn)
            {
                if (brightness > 0 && brightness <= 100)
                {
                    BrightnessPercentage = brightness;
                }
                else
                {
                    throw new ArgumentException("BrightnessPercentage not valid");
                }
            }
            else
            {
                BrightnessPercentage = 0;
            }
        }
        public void SwitchOn_Off() => IsOn = !IsOn;
    }
}
