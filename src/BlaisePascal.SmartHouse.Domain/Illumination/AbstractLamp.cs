using BlaisePascal.SmartHouse.Domain.Asbtraction;

namespace BlaisePascal.SmartHouse.Domain.Illumination

{
    public abstract class AbstractLamp: AbstractDevice, IAbstractLamp
    {
        public Brightness MinBrigthness { get; protected set; } = Brightness.CreateNew(0);
        public Brightness MaxBrightness { get; protected set; } = Brightness.CreateNew(100);
        public Brightness Brightness { get; protected set; }

        public AbstractLamp(string name) : base(name) 
        {
            Brightness = Brightness.CreateNew(50);
        }
        public AbstractLamp(int brightness, string name) : base(name) 
        {
            Brightness = Brightness.CreateNew(brightness);
        }
        
        public void Brighten(int step)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot change brightness when lamp is off");
            
            Brightness = Math.Min(MaxBrightness, Brightness + LampValidator.IsStepValid(step));
            LastModified = DateTime.UtcNow; 
        }

        public void Dimmer(int step)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot change brightness when lamp is off");

            Brightness = Math.Max(MinBrigthness, Brightness - LampValidator.IsStepValid(step));
            LastModified = DateTime.UtcNow;
        }

        public void SetBrightness(int brightness)
        {
            if(Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot change brightness when lamp is off");

            Brightness = LampValidator.BrightnessValidator(brightness);
            LastModified = DateTime.UtcNow;
        }


       
        

        






    }
}
