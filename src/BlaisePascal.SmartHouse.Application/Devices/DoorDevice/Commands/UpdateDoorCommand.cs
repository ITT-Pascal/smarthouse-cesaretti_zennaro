using BlaisePascal.SmartHouse.Domain.Devices.Door;
using BlaisePascal.SmartHouse.Domain.Devices.Door.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Commands
{
    public class UpdateDoorCommand
    {
        private readonly IDoorRepository _repository;

        public UpdateDoorCommand(IDoorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Door door)
        {
            _repository.Update(door);
        }

    }       
}
