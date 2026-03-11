using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Abstraction.Interfaces
{
    public interface ISwitchable
    {
        void SwitchOn();
        void SwitchOff();
    }
}
