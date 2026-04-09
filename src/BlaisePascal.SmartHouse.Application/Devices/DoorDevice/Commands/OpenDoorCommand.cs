using BlaisePascal.SmartHouse.Domain.Devices.Door.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Commands
{
    public class OpenDoorCommand
    {
        private readonly IDoorRepository _repository;
        public OpenDoorCommand(IDoorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            var door = _repository.GetById(id);
            if (door != null)
            {
                door.Open();
                _repository.Update(door);
            }
        }
    }
}
