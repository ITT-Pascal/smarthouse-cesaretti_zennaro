using BlaisePascal.SmartHouse.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Door
{
    public interface IDoor: IDevice
    {
        void OpenDoor();
        void CloseDoor();
        void LockDoor();
        void UnlockDoor(string password);
    }
}
