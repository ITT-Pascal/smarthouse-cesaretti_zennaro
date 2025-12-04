using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain.DevicesStatus;
using BlaisePascal.SmartHouse.Domain.Validator;

namespace BlaisePascal.SmartHouse.Domain
{
    public class AirConditioner: AbstractDevice
    {
        public int Temperature { get; protected set; }
        private const int MaxTemperature = 50;
        private const int MinTemperature = 0;
        public const int DefaultIncreaseValue = 10;

        public AirConditioner(string name): base(name) { Temperature = 18; }
        public AirConditioner(string name, int temperature): base(name) { Temperature = temperature; }

        public void SetTemperature(int temperature)
        {
            Temperature = AirConditionerValidator.SetTemperatureValueValidator(temperature);
        }
        public void IncreaseTemperature()
        {
            SetTemperature(Temperature + DefaultIncreaseValue);
        }

        public void IncreaseTemperature(int value)
        {
            SetTemperature(Temperature + AirConditionerValidator.IncreaseValueValidator(value));
        }
        public void DecreaseTemperature()
        {
            SetTemperature(Temperature - DefaultIncreaseValue);
        }
        public void DecreaseTemperature(int value)
        {
            SetTemperature(Temperature - AirConditionerValidator.IncreaseValueValidator(value));
        }

        public int GetMaxTemperature() => MaxTemperature;
        public int GetMinTemperature() => MinTemperature;
        public int GetDefaultIncreaseValue() => DefaultIncreaseValue;

    }
}
