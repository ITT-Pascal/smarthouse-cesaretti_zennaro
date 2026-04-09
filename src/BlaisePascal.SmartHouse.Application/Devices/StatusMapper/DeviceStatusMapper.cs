using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;

namespace BlaisePascal.SmartHouse.Application.Devices.StatusMapper
{
    public class DeviceStatusMapper
    {
        public static string ToDto(DeviceStatus status)
        {
            return status switch
            {
                DeviceStatus.On => "On",
                DeviceStatus.Off => "Off",
                _ => throw new ArgumentException("Invalid status value")
            };
        }

        public static DeviceStatus ToDomain(string status)
        {
            return status switch
            {
                "On" => DeviceStatus.On,
                "Off" => DeviceStatus.Off,
                _ => throw new ArgumentException("Invalid status value")
            };
        }
    }
}
