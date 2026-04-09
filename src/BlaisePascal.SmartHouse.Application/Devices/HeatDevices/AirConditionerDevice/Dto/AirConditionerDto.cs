using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HeatDevices.AirConditionerDevice.Commands.Dto
{
    public class AirConditionerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DeviceStatus { get; set; }
        public int Temperature { get; set; }
        public DateTime CreationHour { get; set; }
        public DateTime LastModified { get; set; }
    }
}
