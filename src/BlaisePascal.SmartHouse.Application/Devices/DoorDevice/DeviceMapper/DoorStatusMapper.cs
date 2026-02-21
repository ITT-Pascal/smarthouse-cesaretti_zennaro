using BlaisePascal.SmartHouse.Domain.Devices.Door;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.DeviceMapper
{
    public class DoorStatusMapper
    {
        public static string ToDto(DoorStatus status)
        {
            return status switch
            {
                DoorStatus.Open => "OPEN",
                DoorStatus.Closed => "CLOSED",
                DoorStatus.Locked => "LOCKED",
                _ => throw new ArgumentException("Invalid status value")
            };
        }

        public static DoorStatus ToDomain(string status)
        {
            return status switch
            {
                "OPEN" => DoorStatus.Open,
                "CLOSED" => DoorStatus.Closed,
                "LOCKED" => DoorStatus.Locked,
                _ => throw new ArgumentException("Invalid status value")
            };
        }
    }
}
