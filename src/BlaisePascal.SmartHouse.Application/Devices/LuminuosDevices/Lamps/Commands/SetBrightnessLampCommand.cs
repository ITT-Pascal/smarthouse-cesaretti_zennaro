using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.LuminuosDevices.Lamps.Commands
{
    public class SetBrightnessLampCommand
    {
        private readonly ILampRepository _repository;

        public SetBrightnessLampCommand(ILampRepository lampRepository)
        {
            _repository = lampRepository;
        }

        public void Execute(Guid id, int brightness)
        {
            var lamp = _repository.GetById(id);
            if (lamp != null)
            {
                lamp.SetBrightness(Brightness.CreateNew(brightness));
                _repository.Update(lamp);
            }
        } 
    }
}
