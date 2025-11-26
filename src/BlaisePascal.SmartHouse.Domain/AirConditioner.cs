using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class AirConditioner
    {
        public string Name { get; protected set; }
        public Guid Id { get; protected set; }
        public DeviceStatus Status { get; protected set; }
        public int Temperature { get; protected set; }
        protected const int MaxTemperature = 50;
        protected const int MinTemperature = 0;
        public AirConditioner(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
            Status = DeviceStatus.Off;
            Temperature = 18;
        }
        // TODO: clean
        public void SetTemperature(int temperature)
        {
            Temperature = Math.Max(temperature, MinTemperature);
            Temperature = Math.Min(temperature, MaxTemperature);
        }
        public void IncreaseTemperature()
        {
            int value = 10;
            SetTemperature(Temperature + value);
        }
        public void DecreaseTemperature()
        {
            int value = 10;
            SetTemperature(Temperature - value);
        }
    }
}
