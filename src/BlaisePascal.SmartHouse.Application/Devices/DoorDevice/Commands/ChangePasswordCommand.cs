using BlaisePascal.SmartHouse.Domain.Devices.Door.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.Door.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Commands
{
    public class ChangePasswordCommand
    {
        private readonly IDoorRepository _repository;
        public ChangePasswordCommand(IDoorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, string oldPassword, string newPassword)
        {
            var door = _repository.GetById(id);
            if (door != null)
            {
                door.ChangePassword(Password.CreateNew(oldPassword), Password.CreateNew(newPassword));
                _repository.Update(door);
            }
        }
    }
}
