using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction

{
    public abstract class AbstractLamp: AbstractDevice, IAbstractLamp
    {
        public  Brightness MinBrigthness { get; protected set; } = Brightness.CreateNew(0);
        public abstract Brightness DefaultBrigthness { get; protected set; }
        public abstract Brightness MaxBrightness { get; protected set; }
        public Brightness Brightness { get; protected set; }

        public AbstractLamp(string name) : base(name) 
        {
            Brightness = DefaultBrigthness;
        }
        public AbstractLamp(int brightness, string name) : base(name) 
        {
            Brightness = Brightness.CreateNew(brightness);
        }
        
        public virtual void Brighten(int value)
        {
            AbstractLampValidator.CheckIsOn(Status);
            AbstractLampValidator.IsPositive(value);
            Brightness = Brightness.CreateNew(Brightness + value);
            LastModified = DateTime.UtcNow;
        }

        public virtual void Dimmer(int value)
        {
            AbstractLampValidator.CheckIsOn(Status);
            AbstractLampValidator.IsPositive(value);
            Brightness = Brightness.CreateNew(Brightness - value);
            LastModified = DateTime.UtcNow;
        }

        public virtual void SetBrightness(int brightness)
        {
            AbstractLampValidator.CheckIsOn(Status);
            Brightness = Brightness.CreateNew(brightness);
            LastModified = DateTime.UtcNow;
        }

        











    }
}
