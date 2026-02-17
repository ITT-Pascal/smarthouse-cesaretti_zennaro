using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Luminuos.Lamps.Commands
{
    internal class RemoveLampCommand
    {
        private readonly ILampRepository _repository;

        public RemoveLampCommand(ILampRepository lampRepository)
        {
            _repository = lampRepository;
        }

        public void Execute(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
