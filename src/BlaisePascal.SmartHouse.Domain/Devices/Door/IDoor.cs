using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Door
{
    public interface IDoor: IDevice
    {
        void Open();
        void Close();
        void Lock();
        void Unlock(string password);
        void ChangePassword(string oldPassword, string newPassword);
    }
}
