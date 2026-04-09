using BlaisePascal.SmartHouse.Domain.Devices.CCTV;
using BlaisePascal.SmartHouse.Domain.Devices.CCTV.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevice.Commands
{
    public class UpdateCCTVCommand
    {
        private readonly ICCTVRepository _repository;

        public UpdateCCTVCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public void Execute(CCTV cctv)
        {
            _repository.Update(cctv);
        }
    }
}
