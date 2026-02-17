using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.Thermostat.Commands
{
    public class AddThermostatCommand
    {
        private readonly IThermostatRepositories _repository;

        public AddThermostatCommand(IThermostatRepositories thermostatRepository)
        {
            _repository = thermostatRepository;
        }

        public void Execute(string name)
        {
            _repository.Add(new Thermostat(Name.CreateNew(name)));
        }
    }
}
