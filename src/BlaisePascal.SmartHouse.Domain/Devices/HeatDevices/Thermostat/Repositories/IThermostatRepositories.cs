namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat.Repositories
{
    public interface IThermostatRepositories
    {
        void Add(Thermostat thermostat);
        void Remove(Guid id);
        void Update(Thermostat thermostat);
        Thermostat GetById(Guid id);
        List<Thermostat> GetAll();
    }
}
