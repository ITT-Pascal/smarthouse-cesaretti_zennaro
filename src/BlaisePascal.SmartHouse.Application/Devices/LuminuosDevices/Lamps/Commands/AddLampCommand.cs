using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Luminuos.Lamps.Commands
{
    public class AddLampCommand
    {
        private readonly ILampRepository _repository;

        public AddLampCommand(ILampRepository lampRepository)
        {
            _repository = lampRepository;
        }


        public void Execute(string lampName)
        {
            _repository.Add(new Lamp(Name.CreateNew(lampName)));
        }
    }
}
