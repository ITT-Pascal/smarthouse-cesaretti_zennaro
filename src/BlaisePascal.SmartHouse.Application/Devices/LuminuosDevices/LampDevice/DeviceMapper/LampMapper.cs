using BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.Lamps.Dto;
using BlaisePascal.SmartHouse.Application.Devices.StatusMapper;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.LuminuosDevices;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.LampDevice.DeviceMapper
{
    public class LampMapper
    {
        public static LampDto ToDto(Lamp lamp)
        {
            return new LampDto
            {
                Id = lamp.Id,
                Name = lamp.Name.Value,
                DeviceStatus = DeviceStatusMapper.ToDto(lamp.DeviceStatus),
                Brightness = lamp.Brightness.Value,
                CreationHour = lamp.CreationHour,
                LastModified = lamp.LastModified
            };
        }

        public static Lamp ToDomain(LampDto lampDto)
        {
            return new Lamp(
                lampDto.Id,
                Name.CreateNew(lampDto.Name),
                DeviceStatusMapper.ToDomain(lampDto.DeviceStatus),
                lampDto.CreationHour,
                lampDto.LastModified,
                Brightness.CreateNew(lampDto.Brightness)
            );
        }
    }   
}
