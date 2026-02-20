using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner
{
    public sealed class AirConditioner: AbstractDevice, IHeatDevices
    {
        public AirConditionerTemperature Temperature { get; private set; }
        public AirConditionerTemperature MaxTemperature { get; private set; } = AirConditionerTemperature.CreateNew(AirConditionerValidator.MaxTemperature);
        public AirConditionerTemperature DefaultTemperature { get; private set; } = AirConditionerTemperature.CreateNew(AirConditionerValidator.DefaultTemperature);
        public AirConditionerTemperature MinTemperature { get; private set; } = AirConditionerTemperature.CreateNew(AirConditionerValidator.MinTemperature);
        public int DefaultStep { get; private set; }= 5;

        public AirConditioner(Name name, AirConditionerTemperature temperature) : base(name)
        {
            Temperature = temperature;
        }

        public AirConditioner(Name name) : base(name)
        {
            Temperature = DefaultTemperature;
        }

        public void SetTemperature(AirConditionerTemperature temperature)
        {
            AirConditionerValidator.CheckIsOn(Status);   
            Temperature = temperature;
            LastModified = DateTime.UtcNow;
        }

        public void SetTemperature()
        {
            AirConditionerValidator.CheckIsOn(Status);
            Temperature = DefaultTemperature;
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseTemperature()
        {
            AirConditionerValidator.CheckIsOn(Status);
            Temperature = AirConditionerTemperature.CreateNew(Temperature + DefaultStep);
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseTemperature(int value)
        {
            AirConditionerValidator.CheckIsOn(Status);
            AirConditionerValidator.CheckIsPositive(value);
            Temperature = AirConditionerTemperature.CreateNew(Temperature + value);
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature()
        {
            AirConditionerValidator.CheckIsOn(Status);
            Temperature = AirConditionerTemperature.CreateNew(Temperature - DefaultStep);
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature(int value)
        {
            AirConditionerValidator.CheckIsOn(Status);
            AirConditionerValidator.CheckIsPositive(value);
            Temperature = AirConditionerTemperature.CreateNew(Temperature - value);
            LastModified = DateTime.UtcNow;
        }

    }
}
