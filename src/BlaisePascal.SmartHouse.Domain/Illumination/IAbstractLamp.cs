using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    public interface IAbstractLamp
    {
        void Brighten(int step);
        void Dimmer(int step);
        void SetBrightness(int brightness)
    }
}
