using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat
{
    public static class ThermostatValidator
    {
        public static void CheckIsOn(DeviceStatus deviceStatus)
        {
            if (deviceStatus != DeviceStatus.On)
                throw new InvalidOperationException("cannot modify thermostat when it is off");
        }
        
        public static void CheckIsPositive(int value)
        {
            if (value <= 0)
                throw new ArgumentException("value must be greater than 0");
        } 
        
    }
}
