using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.CCTV;
using BlaisePascal.SmartHouse.Domain.Devices.CCTV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevice.Commands
{
    public class AddCCTVCommand
    {
        private readonly ICCTVRepository _repository;

        public AddCCTVCommand(ICCTVRepository repository)
        {
            _repository = repository;
        }

        public void Excute(string name)
        {
            _repository.Add(new CCTV(Name.CreateNew(name)));
        }
    }
}
