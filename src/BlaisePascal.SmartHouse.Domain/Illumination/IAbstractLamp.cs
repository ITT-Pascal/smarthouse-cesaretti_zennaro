using BlaisePascal.SmartHouse.Domain.DeviceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    public interface IAbstractLamp: IDevice
    {
        void Brighten(int step);
        void Dimmer(int step);
        void SetBrightness(int brightness);
    }
}
