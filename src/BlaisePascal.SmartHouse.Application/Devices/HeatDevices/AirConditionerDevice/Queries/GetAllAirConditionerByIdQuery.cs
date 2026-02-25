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
    public class GetAllAirConditionerByIdQuery
    {
        private readonly IAirConditionerRepository _repository;

        public GetAllAirConditionerByIdQuery(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public List<AirConditionerDto> Execute()
        {
            var result = new List<AirConditionerDto>();

            foreach(var airConditioner in _repository.GetAll())
            {
                result.Add(AirConditionerMapper.ToDto(airConditioner));
            }

            return result;
        }
    }
}
