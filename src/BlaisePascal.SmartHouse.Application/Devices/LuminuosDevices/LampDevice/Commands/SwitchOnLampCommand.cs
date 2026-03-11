using BlaisePascal.SmartHouse.Domain.Devices.Illumination;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.LuminuosDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Luminuos.Lamps.Commands
{
    public class SwitchOnLampCommand
    {
        private readonly ILampRepository _repository;

        public SwitchOnLampCommand(ILampRepository lampRepository)
        {
            _repository = lampRepository;
        }


        public void Execute(Guid id)
        {
            Lamp lamp = _repository.GetById(id);
            if(lamp != null)
            {
                lamp.SwitchOn();
                _repository.Update(lamp);
            }
        }
    }
}
