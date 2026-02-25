using BlaisePascal.SmartHouse.Application.Devices.HeatDevices.ThermostatDevice.DeviceMapper;
using BlaisePascal.SmartHouse.Application.Devices.HeatDevices.ThermostatDevice.Dto;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HeatDevices.ThermostatDevice.Queries
{
    internal class GetAllThermostatByIdQuery
    {
        private readonly IThermostatRepositories _repository;

        public GetAllThermostatByIdQuery(IThermostatRepositories repository)
        {
            _repository = repository;
        }

        public List<ThermostatDto> Execute()
        {
            var result = new List<ThermostatDto>();

            foreach (var thermostat in _repository.GetAll())
            {
                result.Add(ThermostatMapper.ToDto(thermostat));
            }

            return result;
        }
    }
}
