using BlaisePascal.SmartHouse.Domain.Devices.Door.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Door.Commands
{
    public class AddDoorCommand
    {
        private readonly IDoorRepository _repository;

        public AddDoorCommand(IDoorRepository doorRepository)
        {
            _repository = doorRepository;
        }

        public void Execute(string doorName)
        {
            _repository.Add(new Door(doorName));
        }
    }
}
