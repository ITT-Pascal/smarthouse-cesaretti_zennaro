using System.Xml.Linq;
using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.Devices.Illumination
{
    public class Lamp : AbstractLamp
    {
        public Lamp(string name) : base(name) { }
        public Lamp(int brightness, string name) : base(brightness, name) { }
    } 
}

