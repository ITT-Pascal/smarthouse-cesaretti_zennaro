using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner
{
    public sealed class AirConditioner: AbstractDevice, IHeatDevices
    {
        public ValueObjects.AirConditionerTemperature Temperature { get; private set; }
        public ValueObjects.AirConditionerTemperature MaxTemperature { get; private set; } = ValueObjects.AirConditionerTemperature.CreateNew(AirConditionerValidator.MaxTemperature);
        public ValueObjects.AirConditionerTemperature DefaultTemperature { get; private set; } = ValueObjects.AirConditionerTemperature.CreateNew(AirConditionerValidator.DefaultTemperature);
        public ValueObjects.AirConditionerTemperature MinTemperature { get; private set; } = ValueObjects.AirConditionerTemperature.CreateNew(AirConditionerValidator.MinTemperature);
        public int DefaultStep { get; private set; }= 5;

        public AirConditioner(string name, int temperature) : base(name)
        {
            Temperature = ValueObjects.AirConditionerTemperature.CreateNew(temperature);
        }

        public AirConditioner(string name) : base(name)
        {
            Temperature = DefaultTemperature;
        }

        public void SetTemperature(int temperature)
        {
            AirConditionerValidator.CheckIsOn(Status);
            temperature = AirConditionerValidator.TemperatureValueValidator(temperature);
            Temperature = ValueObjects.AirConditionerTemperature.CreateNew(temperature);
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
            Temperature = ValueObjects.AirConditionerTemperature.CreateNew(Temperature + DefaultStep);
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseTemperature(int value)
        {
            AirConditionerValidator.CheckIsOn(Status);
            AirConditionerValidator.CheckIsPositive(value);
            Temperature = ValueObjects.AirConditionerTemperature.CreateNew(Temperature + value);
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature()
        {
            AirConditionerValidator.CheckIsOn(Status);
            Temperature = ValueObjects.AirConditionerTemperature.CreateNew(Temperature - DefaultStep);
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature(int value)
        {
            AirConditionerValidator.CheckIsOn(Status);
            AirConditionerValidator.CheckIsPositive(value);
            Temperature = ValueObjects.AirConditionerTemperature.CreateNew(Temperature - value);
            LastModified = DateTime.UtcNow;
        }

    }
}
