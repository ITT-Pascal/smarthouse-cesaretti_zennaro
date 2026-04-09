using BlaisePascal.SmartHouse.Application.Devices.DoorDevice.DeviceMapper;
using BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Dto;
using BlaisePascal.SmartHouse.Domain.Devices.Door;
using BlaisePascal.SmartHouse.Domain.Devices.Door.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Queries
{
    public class GetAllDoorQueries
    {
        private readonly IDoorRepository _repository;
    
        public GetAllDoorQueries(IDoorRepository repository)
        {
            _repository = repository;
        }

        public List<DoorDto> Execute()
        {
            var result = new List<DoorDto>();

            foreach (var door in _repository.GetAll())
            {
                result.Add(DoorMapper.ToDto(door));
            }

            return result;
        }
    }
}
