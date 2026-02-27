using BlaisePascal.SmartHouse.Domain.Devices.CCTV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevice.Commands
{
    public class RemoveCCTVCommand
    {
        private readonly ICCTVRepository _repository;

        public RemoveCCTVCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
