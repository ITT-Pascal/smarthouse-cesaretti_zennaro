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
        public float MinTemperature { get; private set; } = 0;
        public float MaxTemperature { get; private set; } = 40;
        public Thermostat(string name, float initialTemperature) : base(name)
        {
            CurrentTemperature = initialTemperature;
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
