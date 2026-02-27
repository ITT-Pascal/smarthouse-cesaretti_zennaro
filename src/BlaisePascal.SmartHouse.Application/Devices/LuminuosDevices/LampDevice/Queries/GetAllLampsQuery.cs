using BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.LampDevice.DeviceMapper;
using BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.Lamps.Dto;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.Luminuos.Lamps.Queries
{
    public class GetAllLampsQuery
    {
        private readonly ILampRepository _repository;

        public GetAllLampsQuery(ILampRepository lampRepository)
        {
            _repository = lampRepository;
        }

        public List<LampDto> Execute()
        {
            var result = new List<LampDto>();

            foreach (var lamp in _repository.GetAll())
            {
                result.Add(LampMapper.ToDto(lamp));
            }
            return result;
        }

    }
}
