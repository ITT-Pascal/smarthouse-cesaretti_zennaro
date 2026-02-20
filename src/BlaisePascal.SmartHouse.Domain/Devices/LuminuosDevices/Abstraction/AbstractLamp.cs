using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.LuminuosDevices.Abstraction.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction

{
    public abstract class AbstractLamp: AbstractDevice, IAbstractLamp
    {
        public Brightness MinBrigthness { get; protected set; } = Brightness.CreateNew(0);
        
        public Brightness Brightness { get; protected set; }

        public abstract Brightness DefaultBrigthness { get; protected set; }
        public abstract Brightness MaxBrightness { get; protected set; }

        public AbstractLamp(Name name) : base(name) 
        {
            Brightness = DefaultBrigthness;
        }

        public AbstractLamp(Brightness brightness, Name name) : base(name)
        {
            Brightness = CheckRange(brightness);
        }

        public virtual void Brighten(int value)
        {
            AbstractLampValidator.CheckIsOn(Status);
            AbstractLampValidator.IsPositive(value);
            Brightness = Brightness.CreateNewNormal(Brightness + value);
            LastModified = DateTime.UtcNow;
        }

        public virtual void Dimmer(int value)
        {
            AbstractLampValidator.CheckIsOn(Status);
            AbstractLampValidator.IsPositive(value);
            Brightness = Brightness.CreateNewNormal(Brightness - value);
            LastModified = DateTime.UtcNow;
        }

        public virtual void SetBrightness(Brightness brightness)
        {
            AbstractLampValidator.CheckIsOn(Status);
            Brightness = Brightness.CreateNewNormal(brightness.Value);
            LastModified = DateTime.UtcNow;
        }

        private Brightness CheckRange(Brightness brightness)
        {
            if(brightness > MaxBrightness)
                return MaxBrightness;

            return brightness;
        }
            
    }
}
