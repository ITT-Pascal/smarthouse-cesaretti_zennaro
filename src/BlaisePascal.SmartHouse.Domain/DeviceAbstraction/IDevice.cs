using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.DeviceAbstraction
{
    public interface IDevice
    {
        void SwitchOn();
        void SwitchOff();
    }
}
