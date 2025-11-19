namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp : AbstractLamp
    {
        public Lamp(string name) : base(name) { }
        public override void SwitchOn()
        {
            if (Status == DeviceStatus.Off)
            {
                Status = DeviceStatus.On;
                LastModified = DateTime.Now;
            } else
            {
                throw new InvalidOperationException("the lamp is already on");
            } 
        }
        

        public override void SwitchOff()
        {
            if (Status == DeviceStatus.On)
            {
                Status = DeviceStatus.Off;
                LastModified = DateTime.Now;
            } else
            {
                throw new InvalidOperationException("the lamp is already off");
            }
                
        }


        public override void ChangeBrightness(int newBrightness)
        {
            if (Status == DeviceStatus.On)
            {
                BrightnessPercentage = LampValidator.Britghness(newBrightness);
                LastModified = DateTime.Now;
            } else
            {
                throw new InvalidOperationException("cannot change brightness when the lamp is off");
            }
        } 
    }
}
