using BlaisePascal.SmartHouse.Domain.Devices.CCTV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevice.Commands
{
    public class DecreaseRotationDegreesCommand
    {
        private readonly ICCTVRepository _repository;
        public DecreaseRotationDegreesCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }
        public void Execute(Guid id, float value)
        {
            var cctv = _repository.GetById(id);
            if (cctv != null)
            {
                cctv.DecreaseRotationDegrees(value);
                _repository.Update(cctv);
            }
        }
        public void Execute(Guid id)
        {
            var cctv = _repository.GetById(id);
            if (cctv != null)
            {
                cctv.DecreaseRotationDegrees();
                _repository.Update(cctv);
            }
        }
    }
}
