using BlaisePascal.SmartHouse.Domain.Devices.Illumination;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Luminuos.Lamps.Queries
{
    internal class GetLampByIdQuery
    {
        private readonly ILampRepository _repository;

        public GetLampByIdQuery(ILampRepository lampRepository)
        {
            _repository = lampRepository;
        }

        public Lamp Execute(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}
