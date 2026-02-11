using BlaisePascal.SmartHouse.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.Thermostat
{
    public interface IThermostat: IDevice
    {
        void IncreaseTemperature();
        void DecreaseTemperature();
        void SetTemperature(int temperature);
        void IncreaseTemperature(int step);
        void DecreaseTemperature(int step);
    }
}
