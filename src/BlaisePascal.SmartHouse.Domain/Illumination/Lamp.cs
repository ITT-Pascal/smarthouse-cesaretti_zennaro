using System.Xml.Linq;
using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain.DevicesStatus;
using BlaisePascal.SmartHouse.Domain.Validator;

namespace BlaisePascal.SmartHouse.Domain.Lamps
{
    public class Lamp : AbstractLamp
    {
        public override int MinBrigthness { get; protected set; } = 0;
        public override int MaxBrightness { get; protected set; } = 100;

        public Lamp(string name) : base(name) { }
        public Lamp(string name, int brightness) : base(name, brightness) { }
    }
}
