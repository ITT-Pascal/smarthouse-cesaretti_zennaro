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
    public class GetThermostatByIdQuery
    {
        private readonly IThermostatRepositories _repository;

        public GetThermostatByIdQuery(IThermostatRepositories repository)
        {
            _repository = repository;
        }

        public ThermostatDto Execute(Guid id)
        {
            return ThermostatMapper.ToDto(_repository.GetById(id));
        }
    }
}
