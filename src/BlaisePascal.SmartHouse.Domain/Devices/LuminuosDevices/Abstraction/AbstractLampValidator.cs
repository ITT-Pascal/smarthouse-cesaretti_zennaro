using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction
{
    public static class AbstractLampValidator
    {
        public static void CheckIsOn(DeviceStatus status)
        {
            if (status != DeviceStatus.On)
                throw new InvalidOperationException("Cannot modify lamp when device is off");
        }

        public static int IsPositive(int value)
        {
            if (value <= 0)
                throw new ArgumentException("value must be greater than 0");

            return value;
        }

     
    }
}
