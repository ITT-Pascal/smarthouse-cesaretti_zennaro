using BlaisePascal.SmartHouse.Domain.Asbtraction;

namespace BlaisePascal.SmartHouse.Domain.Illumination.Abstraction

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
        
        public void Brighten(int value)
        {
            AbstractLampValidator.CheckIsOn(Status);
            AbstractLampValidator.IsPositive(value);
            Brightness = Brightness.CreateNew(Brightness + value);
            LastModified = DateTime.UtcNow;
        }

        public void Dimmer(int value)
        {
            AbstractLampValidator.CheckIsOn(Status);
            AbstractLampValidator.IsPositive(value);
            Brightness = Brightness.CreateNew(Brightness - value);
            LastModified = DateTime.UtcNow;
        }

        public void SetBrightness(int brightness)
        {
            AbstractLampValidator.CheckIsOn(Status);
            Brightness = Brightness.CreateNew(brightness);
            LastModified = DateTime.UtcNow;
        }

        











    }
}
