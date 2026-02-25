using BlaisePascal.SmartHouse.Application.Devices.HeatDevices.AirConditionerDevice.Commands.Dto;
using BlaisePascal.SmartHouse.Application.Devices.StatusMapper;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HeatDevices.AirConditionerDevice.Commands.DeviceMapper
{
    public class AirConditionerMapper
    {
        public static AirConditionerDto ToDto(AirConditioner airConditioner)
        {
            return new AirConditionerDto
            {
                Id = airConditioner.Id,
                Name = airConditioner.Name.Value,
                DeviceStatus = DeviceStatusMapper.ToDto(airConditioner.DeviceStatus),
                Temperature = airConditioner.Temperature.Value,
                CreationHour = airConditioner.CreationHour,
                LastModified = airConditioner.LastModified
            };
        }

        public static AirConditioner ToDomain(AirConditionerDto airConditionerDto)
        {
            return new AirConditioner(
                airConditionerDto.Id,
                Name.CreateNew(airConditionerDto.Name),
                DeviceStatusMapper.ToDomain(airConditionerDto.DeviceStatus),
                airConditionerDto.CreationHour,
                airConditionerDto.LastModified,
                Temperature.CreateNew(airConditionerDto.Temperature)
            );
        }
}
