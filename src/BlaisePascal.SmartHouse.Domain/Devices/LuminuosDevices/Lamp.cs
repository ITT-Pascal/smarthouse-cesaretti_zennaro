using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.Devices.Illumination
{
    public class Lamp : AbstractLamp
    {
        public override Brightness MaxBrightness { get; protected set; } = Brightness.CreateNew(LampValidator.MaxBrightness);
        public override Brightness DefaultBrigthness { get; protected set; } = Brightness.CreateNew(50);
        public Lamp(Name name) : base(name) 
        {

        }
        public Lamp(Brightness brightness, Name name) : base(brightness, name) 
        {

        }
    } 
}

