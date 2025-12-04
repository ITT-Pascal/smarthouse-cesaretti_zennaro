using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.DevicesStatus;
using BlaisePascal.SmartHouse.Domain.Validator;

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
        private int DefaultIncreaseValue = 10;
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
            SetTemperature(Temperature + DefaultIncreaseValue);
        }

        public void IncreaseTemperature(int value)
        {
            SetTemperature(Temperature + AirConditionerValidator.TemperatureValidator(value));
        }
        public void DecreaseTemperature()
        {
            SetTemperature(Temperature - DefaultIncreaseValue);
        }
        public void DecreaseTemperature(int value)
        {
            SetTemperature(Temperature - AirConditionerValidator.TemperatureValidator(value));
        }

    }
}
