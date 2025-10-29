namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        public bool IsOn { get; private set; }
        public int BrightnessPercentage { get; private set; }
        public Lamp(bool isOn, int brightness)
        {
            IsOn = isOn;
            BrightnessPercentage = LampValidator.BrightnessValidator(brightness);
        }
        public void SwitchOn_Off() => IsOn = !IsOn;
        public void ChangeBrightness(int newBrightness) => BrightnessPercentage = LampValidator.BrightnessValidator(newBrightness);
    }
}
