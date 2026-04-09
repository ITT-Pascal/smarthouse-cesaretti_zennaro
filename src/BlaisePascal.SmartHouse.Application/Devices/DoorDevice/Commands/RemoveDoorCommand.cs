using BlaisePascal.SmartHouse.Domain.Devices.Door.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Commands
{
    public class RemoveDoorCommand
    {
        private readonly IDoorRepository _repository;

        public RemoveDoorCommand(IDoorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
