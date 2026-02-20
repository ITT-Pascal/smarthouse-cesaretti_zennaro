using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DeviceStatusMapper
{
    public class DeviceStatusMapper
    {
        public static string ToDto(DeviceStatus status)
        {
            return status switch
            {
                DeviceStatus.On => "ON",
                DeviceStatus.Off => "OFF",
                _ => throw new ArgumentException("error")
            };
        }

        public static DeviceStatus ToDomain(string status)
        {
            return status switch
            {
                "ON" => DeviceStatus.On,
                "OFF" => DeviceStatus.Off,
                _ => throw new ArgumentException("non valid status")
            };
        }

    }
}
