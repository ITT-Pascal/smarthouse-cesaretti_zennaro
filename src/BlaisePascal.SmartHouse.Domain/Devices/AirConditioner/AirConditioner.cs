using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.AirConditioner.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.AirConditioner
{
    public sealed class AirConditioner: AbstractDevice
    {
        public Temperature Temperature { get; private set; }
        public Temperature MaxTemperature { get; private set; } = Temperature.CreateNew(AirConditionerValidator.MaxTemperature);
        public Temperature DefaultTemperature { get; private set; } = Temperature.CreateNew(AirConditionerValidator.DefaultTemperature);
        public Temperature MinTemperature{ get; private set; } = Temperature.CreateNew(AirConditionerValidator.MinTemperature);
        public int DefaultStep { get; private set; }= 5;

        public AirConditioner(string name, int temperature) : base(name)
        {
            Temperature = Temperature.CreateNew(temperature);
        }

        public AirConditioner(string name) : base(name)
        {
            Temperature = DefaultTemperature;
        }

        public void SetTemperature(int temperatureValue)
        {
            AirConditionerValidator.CheckIsOn(Status);
            temperatureValue = AirConditionerValidator.TemperatureValueValidator(temperatureValue);
            Temperature = Temperature.CreateNew(temperatureValue);
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
            Temperature = Temperature.CreateNew(Temperature + DefaultStep);
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseTemperature(int value)
        {
            AirConditionerValidator.CheckIsOn(Status);
            AirConditionerValidator.CheckIsPositive(value);
            Temperature = Temperature.CreateNew(Temperature + value);
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature()
        {
            AirConditionerValidator.CheckIsOn(Status);
            Temperature = Temperature.CreateNew(Temperature - DefaultStep);
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature(int value)
        {
            AirConditionerValidator.CheckIsOn(Status);
            AirConditionerValidator.CheckIsPositive(value);
            Temperature = Temperature.CreateNew(Temperature - value);
            LastModified = DateTime.UtcNow;
        }

    }
}
