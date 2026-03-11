using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.LampDevice.Commands
{
    public class RenameLampCommand
    {
        private readonly ILampRepository _repository;

        public RenameLampCommand(ILampRepository repository)
        {
            _repository = repository;
        }

        public void Execute(string name, Guid id) 
        {
            var lamp = _repository.GetById(id);
            if(lamp != null)
            {
                lamp.Rename(Name.CreateNew(name));
                _repository.Update(lamp);
            }
        }
    }
}
