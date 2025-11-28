using System.Xml.Linq;
using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain.DevicesStatus;
using BlaisePascal.SmartHouse.Domain.Validator;

namespace BlaisePascal.SmartHouse.Domain.Lamps
{
    public class Lamp : AbstractLamp
    {
        public Lamp(string name) : base(name) { }
        public Lamp(int brightness, string name) : base(brightness, name) { }
    }
}
