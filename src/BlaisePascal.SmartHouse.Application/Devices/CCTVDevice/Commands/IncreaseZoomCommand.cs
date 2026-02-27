using BlaisePascal.SmartHouse.Domain.Devices.CCTV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevice.Commands
{
    public class IncreaseZoomCommand
    {
        private readonly ICCTVRepository _repository;
        public IncreaseZoomCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }
        public void Execute(Guid id, float value)
        {
            var cctv = _repository.GetById(id);
            if (cctv != null)
            {
                cctv.IncreaseZoom(value);
                _repository.Update(cctv);
            }
        }
        public void Execute(Guid id)
        {
            var cctv = _repository.GetById(id);
            if (cctv != null)
            {
                cctv.IncreaseZoom();
                _repository.Update(cctv);
            }
        }
    }
}
