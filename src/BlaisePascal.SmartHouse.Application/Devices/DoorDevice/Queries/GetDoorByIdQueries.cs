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
    public class GetDoorByIdQueries
    {
        private readonly IDoorRepository _repository;

        public GetDoorByIdQueries(IDoorRepository repository)
        {
            _repository = repository;
        }

        public DoorDto Execute(Guid id)
        {
            return DoorMapper.ToDto(_repository.GetById(id));
        }
    }
}
