using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.Interfaces
{
    public interface IAirConditioner: IHeatDevices
    {
        void SetTemperature(AirConditionerTemperature temperature);
    }
}
