using BlaisePascal.SmartHouse.Application.Devices.HeatDevices.AirConditionerDevice.Commands.DeviceMapper;
using BlaisePascal.SmartHouse.Application.Devices.HeatDevices.AirConditionerDevice.Commands.Dto;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HeatDevices.AirConditionerDevice.Queries
{
    public class GetAirConditionerByIdQuery
    {
        private readonly IAirConditionerRepository _repository;

        public GetAirConditionerByIdQuery(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public AirConditionerDto Execute(Guid id)
        {
            return AirConditionerMapper.ToDto(_repository.GetById(id));
        }

    }
}
