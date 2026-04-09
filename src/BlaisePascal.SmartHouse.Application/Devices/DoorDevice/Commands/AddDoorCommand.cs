using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Door;
using BlaisePascal.SmartHouse.Domain.Devices.Door.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.Door.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Commands
{
    public class AddDoorCommand
    {
        private readonly IDoorRepository _repository;

        public AddDoorCommand(IDoorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(string name, string password)
        {
            _repository.Add(new Door(Name.CreateNew(name), Password.CreateNew(password)));
        }
    }
}
