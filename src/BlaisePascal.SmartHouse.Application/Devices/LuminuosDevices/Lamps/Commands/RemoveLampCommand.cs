using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.Luminuos.Lamps.Commands
{
    internal class RemoveLampCommand
    {
        private readonly ILampRepository _repository;

        public RemoveLampCommand(ILampRepository lampRepository)
        {
            _repository = lampRepository;
        }

        public void Execute(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
