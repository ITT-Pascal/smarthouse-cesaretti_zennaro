using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Dto
{
    public class DoorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DeviceStatus { get; set; }
        public string DoorStatus { get; set; }
        public string Password { get; set; }
        public DateTime CreationHour { get; set; }
        public DateTime LastModified { get; set; }

    }
}
