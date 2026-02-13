using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.Devices.Illumination
{
    public class Lamp : AbstractLamp
    {
        public override Brightness MaxBrightness { get; protected set; } = Brightness.CreateNew(100);
        public override Brightness DefaultBrigthness { get; protected set; } = Brightness.CreateNew(50);
        public Lamp(string name) : base(name) 
        {

        }
        public Lamp(int brightness, string name) : base(brightness, name) 
        {

        }
    } 
}

