using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain.ObjectStatus;
using BlaisePascal.SmartHouse.Domain.Validator;

namespace BlaisePascal.SmartHouse.Domain
{
    public class AirConditioner: AbstractDevice
    {
        public int Temperature { get; protected set; }
        public int MaxTemperature { get; private set; } = 50;
        public int MinTemperature{ get; protected set; } = 0;
        public int DefaultIncreaseValue { get; protected set; }= 10;

        public AirConditioner(string name): base(name) { Temperature = 18; }
        public AirConditioner(string name, int temperature): base(name) { Temperature = temperature; }

        public void SetTemperature(int temperature)
        {
            Temperature = AirConditionerValidator.SetTemperatureValueValidator(temperature);
            LastModified = DateTime.UtcNow;
        }
        public void IncreaseTemperature()
        {
            SetTemperature(Temperature + DefaultIncreaseValue);
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseTemperature(int value)
        {
            SetTemperature(Temperature + AirConditionerValidator.IncreaseValueValidator(value));
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature()
        {
            SetTemperature(Temperature - DefaultIncreaseValue);
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature(int value)
        {
            SetTemperature(Temperature - AirConditionerValidator.IncreaseValueValidator(value));
            LastModified = DateTime.UtcNow;
        }
    }
}
