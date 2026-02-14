using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Interfaces
{
    public interface IHeatDevices
    {
        void SetTemperature();
        void IncreaseTemperature();
        void IncreaseTemperature(int value);
        void DecreaseTemperature();
        void DecreaseTemperature(int value);
    }
}
