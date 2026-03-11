using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.LuminuosDevices;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.Lamps.Commands
{
    public class UpdateLampCommand
    {
        private readonly ILampRepository _repository;

        public UpdateLampCommand(ILampRepository lampRepository)
        {
            _repository = lampRepository;
        }

        public void Execute(Lamp lamp)
        {
            _repository.Update(lamp);
        }
    }
}
