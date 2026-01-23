using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Asbtraction;

namespace BlaisePascal.SmartHouse.Domain.AirConditioner
{
    //FINISHED
    public class AirConditioner: AbstractDevice
    {
        public AirStatus AirStatus { get; private set; }
        public int Temperature { get; private set; }
        public int MaxTemperature { get; private set; } = AirConditionerValidator.MaxTemperature;
        public int DefaultTemperature { get; private set; } = AirConditionerValidator.DefaultTemperature;
        public int MinTemperature{ get; protected set; } = AirConditionerValidator.MinTemperature;
        public int DefaultIncreaseValue { get; private set; }= 10;

        public AirConditioner(string name, int temperature) : base(name)
        {
            SetTemperature(temperature);
        }

        public AirConditioner(string name) : base(name)
        {
            SetTemperature();
        }

        public void SetTemperature(int temperature)
        {
            AirConditionerValidator.CheckIsOn(Status);
            Temperature = AirConditionerValidator.SetTemperatureValueValidator(temperature);
            LastModified = DateTime.UtcNow;
        }

        public void SetTemperature()
        {
            AirConditionerValidator.CheckIsOn(Status);
            Temperature = DefaultTemperature;
        }

        public void IncreaseTemperature()
        {
            AirConditionerValidator.CheckIsOn(Status);
            SetTemperature(Temperature + DefaultIncreaseValue);
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseTemperature(int value)
        {
            AirConditionerValidator.CheckIsOn(Status);
            AirConditionerValidator.CheckIsPositive(value);
            SetTemperature(Temperature + value);
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature()
        {
            AirConditionerValidator.CheckIsOn(Status);
            SetTemperature(Temperature - DefaultIncreaseValue);
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature(int value)
        {
            AirConditionerValidator.CheckIsOn(Status);
            AirConditionerValidator.CheckIsPositive(value);
            SetTemperature(Temperature - value);
            LastModified = DateTime.UtcNow;
        }

    }
}
