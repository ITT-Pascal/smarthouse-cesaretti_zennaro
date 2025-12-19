using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Asbtraction;

namespace BlaisePascal.SmartHouse.Domain.AirConditioner
{
    public class AirConditioner: AbstractDevice
    {
        public int Temperature { get; protected set; }
        public int MaxTemperature { get; private set; } = 50;
        public int DefaultTemperature { get; private set; } = 18;
        public int MinTemperature{ get; protected set; } = 0;
        public int DefaultIncreaseValue { get; protected set; }= 10;

        public AirConditioner(string name, int temperature): base(name)
        { 
            Temperature = temperature;
            Status = DeviceStatus.On;
        }
        public AirConditioner(string name) : base(name) 
        {
            Temperature = DefaultTemperature; 
            Status = DeviceStatus.On;
        }

        public void SetTemperature(int temperature)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot modify air conditioner when it is off");

            Temperature = AirConditionerValidator.SetTemperatureValueValidator(temperature);
            LastModified = DateTime.UtcNow;
        }
        public void IncreaseTemperature()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot modify air conditioner when it is off");

            SetTemperature(Temperature + DefaultIncreaseValue);
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseTemperature(int value)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot modify air conditioner when it is off");

            SetTemperature(Temperature + AirConditionerValidator.IncreaseValueValidator(value));
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot modify air conditioner when it is off");

            SetTemperature(Temperature - DefaultIncreaseValue);
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature(int value)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot modify air conditioner when it is off");

            SetTemperature(Temperature - AirConditionerValidator.IncreaseValueValidator(value));
            LastModified = DateTime.UtcNow;
        }
    }
}
