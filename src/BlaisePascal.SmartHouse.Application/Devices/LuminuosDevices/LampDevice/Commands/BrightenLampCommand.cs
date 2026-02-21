using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.Lamps.Commands
{
    public class BrightenLampCommand
    {
        private readonly ILampRepository _repository;

        public BrightenLampCommand(ILampRepository lampRepository)
        {
            _repository = lampRepository;
        }

        public void Execute(Guid id, int brightness)
        {
            var lamp = _repository.GetById(id);
            if (lamp != null)
            {
                lamp.Brighten(brightness);
                _repository.Update(lamp);
            }
        }
    }
}
