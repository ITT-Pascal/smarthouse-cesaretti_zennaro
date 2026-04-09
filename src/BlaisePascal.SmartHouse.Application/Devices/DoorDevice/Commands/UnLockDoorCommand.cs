using BlaisePascal.SmartHouse.Domain.Devices.Door.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.Door.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Commands
{
    public class UnLockDoorCommand
    {
        private readonly IDoorRepository _repository;
        public UnLockDoorCommand(IDoorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, string password)
        {
            var door = _repository.GetById(id);
            if (door != null)
            {
                door.Unlock(Password.CreateNew(password));
                _repository.Update(door);
            }
        }
    }
}
