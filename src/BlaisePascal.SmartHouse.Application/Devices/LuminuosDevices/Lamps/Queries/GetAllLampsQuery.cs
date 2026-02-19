using BlaisePascal.SmartHouse.Domain.Devices.Illumination;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Luminuos.Lamps.Queries
{
    public class GetAllLampsQuery
    {
        private readonly ILampRepository _repository;

        public GetAllLampsQuery(ILampRepository lampRepository)
        {
            _repository = lampRepository;
        }

        public List<Lamp> Execute()
        {
            return _repository.GetAll();
        }

    }
}
