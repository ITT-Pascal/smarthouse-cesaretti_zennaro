using BlaisePascal.SmartHouse.Application.Devices.DeviceStatusMapper;
using BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.Lamps.Dto;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.Lamps.LampMapper
{
    public class LampMapper
    {
        public static LampDto ToDto(Lamp lamp)
        {
            return new LampDto
            {
                Id = lamp.Id,
                Name = lamp.Name.Value,
                Brightness = lamp.Brightness.Value,
                Status = DeviceStatusMapper.ToDto(lamp.Status),
                CreationHour = lamp.CreationHour,
                LastModified = lamp.LastModified
            };
        }

        //public static ToDomain
    }
}
