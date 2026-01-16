using BlaisePascal.SmartHouse.Domain.DeviceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.AirConditioner
{
    public interface IAirConditioner: IDevice
    {
        void SetTemperature(int temperature);
        void SetTemperature();
        void IncreaseTemperature();
        void IncreaseTemperature(int value);
        void DecreaseTemperature();
        void DecreaseTemperature(int value);
    }
}
