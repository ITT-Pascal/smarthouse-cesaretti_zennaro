using BlaisePascal.SmartHouse.Application.Devices.HeatDevices.ThermostatDevice.Dto;
using BlaisePascal.SmartHouse.Application.Devices.StatusMapper;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HeatDevices.ThermostatDevice.DeviceMapper
{
    public class ThermostatMapper
    {
        public static ThermostatDto ToDto(Thermostat thermostat)
        {
            return new ThermostatDto
            {
                Id = thermostat.Id,
                Name = thermostat.Name.Value,
                DeviceStatus = DeviceStatusMapper.ToDto(thermostat.DeviceStatus),
                Temperature = thermostat.Temperature.Value,
                CreationHour = thermostat.CreationHour,
                LastModified = thermostat.LastModified
            };
        }

        public static Thermostat ToDomain(ThermostatDto thermostatDto)
        {
            return new Thermostat(
                thermostatDto.Id,
                Name.CreateNew(thermostatDto.Name),
                DeviceStatusMapper.ToDomain(thermostatDto.DeviceStatus),
                thermostatDto.CreationHour,
                thermostatDto.LastModified,
                Temperature.CreateNew(thermostatDto.Temperature)
            );
        }
    }
}
