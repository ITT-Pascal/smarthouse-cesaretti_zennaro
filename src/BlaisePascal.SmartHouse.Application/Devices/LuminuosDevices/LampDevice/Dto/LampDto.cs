using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.Lamps.Dto
{
    public class LampDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DeviceStatus { get; set; }
        public int Brightness { get; set; }
        public DateTime CreationHour { get; set; }
        public DateTime LastModified { get; set; }

        public override string ToString()
        {
            return $"Lamp Id: {Id}\n"+
                $"Lamp name: {Name}\n" +
                $"Status: {DeviceStatus}\n" +
                $"Brightness: {Brightness}\n" +
                $"Creation hour: {CreationHour}\n" +
                $"Last modified: {LastModified}"           ;
        }
    }
}
