using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Abstraction
{
    public static class AbstractDeviceValidator
    {
        public static void CheckIsOn(DeviceStatus status)
        {
            if (status != DeviceStatus.On)
                throw new InvalidOperationException("device is already on");
        }

        public static void CheckIsOff(DeviceStatus status)
        {
            if (status != DeviceStatus.Off)
                throw new InvalidOperationException("device is already off");
        }
    }
}
