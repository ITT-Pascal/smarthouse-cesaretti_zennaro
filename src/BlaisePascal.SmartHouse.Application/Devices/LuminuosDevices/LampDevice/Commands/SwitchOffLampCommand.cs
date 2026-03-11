using BlaisePascal.SmartHouse.Domain.Devices.Illumination;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.LuminuosDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.Lamps.Commands
{
    public class SwitchOffLampCommand
    {
        private readonly ILampRepository _repository;
    
        public SwitchOffLampCommand(ILampRepository lampRepository)
        {
                _repository = lampRepository;
        }

        public void Execute(Guid id)
        {
            Lamp lamp = _repository.GetById(id);
            if(lamp != null)
            {
                lamp.SwitchOff();
                _repository.Update(lamp);
            }
        }
    }
}
