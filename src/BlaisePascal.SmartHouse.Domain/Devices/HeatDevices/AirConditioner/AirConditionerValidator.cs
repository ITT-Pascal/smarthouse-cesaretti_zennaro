using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner
{
    public static class AirConditionerValidator
    {
        public static AirConditionerTemperature MaxTemperature = AirConditionerTemperature.CreateNew(50);
        public static AirConditionerTemperature MinTemperature = 0;
        public const int DefaultTemperature = 18;

        public static void CheckIsOn(DeviceStatus status)
        {
            if (status != DeviceStatus.On)
                throw new InvalidOperationException("cannot modify air conditioner when it is off");
        }
        public static AirConditionerTemperature TemperatureValueValidator(AirConditionerTemperature temperature)
        {
            if (value < MinTemperature)
                return MinTemperature;

            if (value > MaxTemperature)
                return MaxTemperature;

            return value;
        }

        public static int CheckIsPositive(int value)
        {
            if (value <= 0)
                throw new ArgumentException("value must be greater than 0");
            return value;
        }
    }
}
