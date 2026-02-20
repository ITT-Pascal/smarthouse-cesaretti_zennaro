using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner
{
    public static class AirConditionerValidator
    {
        public static void CheckIsOn(DeviceStatus status)
        {
            if (status != DeviceStatus.On)
                throw new InvalidOperationException("cannot modify air conditioner when it is off");
        }

        public static int CheckIsPositive(int value)
        {
            if (value <= 0)
                throw new ArgumentException("value must be greater than 0");
            return value;
        }
    }
}
