using BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.LampDevice.DeviceMapper;
using BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.Lamps.Dto;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.Luminuos.Lamps.Queries
{
    internal class GetLampByIdQuery
    {
        private readonly ILampRepository _repository;

        public GetLampByIdQuery(ILampRepository lampRepository)
        {
            _repository = lampRepository;
        }

        public LampDto Execute(Guid id)
        {
            return LampMapper.ToDto(_repository.GetById(id));
        }
    }
}
