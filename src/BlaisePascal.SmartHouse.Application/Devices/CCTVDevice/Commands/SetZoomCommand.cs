using BlaisePascal.SmartHouse.Domain.Devices.CCTV.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.CCTV.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevice.Commands
{
    public class SetZoomCommand
    {
        private readonly ICCTVRepository _repository;
        public SetZoomCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }
        public void Execute(Guid id, Zoom zoom)
        {
            var cctv = _repository.GetById(id);
            if (cctv != null)
            {
                cctv.SetZoom(zoom);
                _repository.Update(cctv);
            }
        }
        public void Execute(Guid id)
        {
            var cctv = _repository.GetById(id);
            if (cctv != null)
            {
                cctv.SetZoom();
                _repository.Update(cctv);
            }
        }
    }
}
