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

        //TODO: refactor with DTO
        public Lamp Execute(Guid id)
        {
            var l = _repository.GetById(id);
            return l;
        }
    }
}
