using BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Dto;
using BlaisePascal.SmartHouse.Application.Devices.StatusMapper;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Door;
using BlaisePascal.SmartHouse.Domain.Devices.Door.ValueObjects;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.DeviceMapper
{
    public class DoorMapper
    {
        public static DoorDto ToDto(Door door)
        {
            return new DoorDto
            {
                Id = door.Id,
                Name = door.Name.Value,
                DeviceStatus = DeviceStatusMapper.ToDto(door.DeviceStatus),
                DoorStatus = DoorStatusMapper.ToDto(door.DoorStatus),
                Password = door.Password.Value,
                CreationHour = door.CreationHour,
                LastModified = door.LastModified
            };
        }

        public static Door ToDomain(DoorDto doorDto)
        {
            return new Door(
                doorDto.Id, 
                Name.CreateNew(doorDto.Name),
                DeviceStatusMapper.ToDomain(doorDto.DeviceStatus),
                doorDto.CreationHour,
                doorDto.LastModified,
                DoorStatusMapper.ToDomain(doorDto.DoorStatus),
                Password.CreateNew(doorDto.Password)
                );
        }
    }
}
