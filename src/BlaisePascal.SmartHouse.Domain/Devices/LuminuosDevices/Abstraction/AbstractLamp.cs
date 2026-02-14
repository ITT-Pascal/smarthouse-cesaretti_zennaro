using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction

{
    public abstract class AbstractLamp: AbstractDevice, IAbstractLamp
    {
        public  Brightness MinBrigthness { get; protected set; } = Brightness.CreateNew(0);
        public abstract Brightness DefaultBrigthness { get; protected set; }
        public abstract Brightness MaxBrightness { get; protected set; }
        public Brightness Brightness { get; protected set; }

        public AbstractLamp(Name name) : base(name) 
        {
            Brightness = DefaultBrigthness;
        }
        public AbstractLamp(Brightness brightness, Name name) : base(name) 
        {
            Brightness = brightness;
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
