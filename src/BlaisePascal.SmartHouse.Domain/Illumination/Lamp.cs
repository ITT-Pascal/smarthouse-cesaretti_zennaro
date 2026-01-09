using System.Xml.Linq;
using BlaisePascal.SmartHouse.Domain.Asbtraction;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    public class Lamp : AbstractLamp
    {
        public Lamp(string name) : base(name) { }
        public Lamp(int brightness, string name) : base(brightness, name) { }
        //- namespaces: sistemare ->
        //- struttura: sistemare in components
        //- UML: ripensare door
        //- EcoLampTest TODO
    } 
}

