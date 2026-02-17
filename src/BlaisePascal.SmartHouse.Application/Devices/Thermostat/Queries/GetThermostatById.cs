using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat.Repositories;

namespace BlaisePascal.SmartHouse.Application.Devices.Thermostat.Queries
{
    public class GetThermostatById
    {
        private readonly IThermostatRepositories _repository;
        public GetThermostatById(IThermostatRepositories thermostatRepository)
        {
            _repository = thermostatRepository;
        }   

        public Thermostat Execute(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}
