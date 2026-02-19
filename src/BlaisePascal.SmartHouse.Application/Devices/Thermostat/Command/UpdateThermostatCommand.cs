using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat;

namespace BlaisePascal.SmartHouse.Application.Devices.Thermostat.Command
{
    public class UpdateThermostatCommand
    {
        private readonly IThermostatRepositories _repository;

        public UpdateThermostatCommand(IThermostatRepositories repository)
        {
            _repository = repository;
        }

        public void Execute(Thermostat thermostat)
        {
            _repository.Update(thermostat);
        }
    }
}
