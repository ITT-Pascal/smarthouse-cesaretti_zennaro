using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner
{
    public sealed class AirConditioner: AbstractDevice, IHeatDevices
    {
        public Temperature Temperature { get; private set; }
        public Temperature MinTemperature { get; private set; } = Temperature.CreateNew(10);
        public Temperature MaxTemperature { get; private set; } = Temperature.CreateNew(50);
        public Temperature DefaultTemperature { get; private set; } = Temperature.CreateNew(18);
        public int DefaultStep { get; private set; }= 5;

        public AirConditioner(Name name, Temperature initialTemperature) : base(name)
        {
            Temperature = Temperature.AirConditionerCreateNew(initialTemperature.Value);
        }

        public AirConditioner(Name name) : base(name)
        {
            Temperature = DefaultTemperature;
        }

        public void SetTemperature(Temperature temperature)
        {
            AirConditionerValidator.CheckIsOn(DeviceStatus);   
            Temperature = Temperature.AirConditionerCreateNew(temperature.Value);
            LastModified = DateTime.UtcNow;
        }

        public void SetTemperature()
        {
            AirConditionerValidator.CheckIsOn(DeviceStatus);
            Temperature = DefaultTemperature;
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseTemperature()
        {
            AirConditionerValidator.CheckIsOn(DeviceStatus);
            Temperature = Temperature.AirConditionerCreateNew(Temperature + DefaultStep);
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseTemperature(int value)
        {
            AirConditionerValidator.CheckIsOn(DeviceStatus);
            AirConditionerValidator.CheckIsPositive(value);
            Temperature = Temperature.AirConditionerCreateNew(Temperature + value);
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature()
        {
            AirConditionerValidator.CheckIsOn(DeviceStatus);
            Temperature = Temperature.AirConditionerCreateNew(Temperature - DefaultStep);
            LastModified = DateTime.UtcNow;
        }
        public void DecreaseTemperature(int value)
        {
            AirConditionerValidator.CheckIsOn(DeviceStatus);
            AirConditionerValidator.CheckIsPositive(value);
            Temperature = Temperature.AirConditionerCreateNew(Temperature - value);
            LastModified = DateTime.UtcNow;
        }

    }
}
