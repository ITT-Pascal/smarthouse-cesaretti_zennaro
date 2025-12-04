using BlaisePascal.SmartHouse.Domain.Asbtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    // TODO: finish.
    public class Thermostat : AbstractDevice
    {
        public float CurrentTemperature { get; private set; }
        public float TargetTemperature { get; private set; }
        public Thermostat(string name, float initialTemperature) : base(name)
        {
            CurrentTemperature = initialTemperature;
            TargetTemperature = initialTemperature;
            Status = DevicesStatus.DeviceStatus.On;
        }
        public void SetTargetTemperature(float temperature)
        {
            TargetTemperature = temperature;
            LastModified = DateTime.Now;
        }
        public void UpdateCurrentTemperature(float temperature)
        {
            CurrentTemperature = temperature;
            LastModified = DateTime.Now;
        }
    }
}
