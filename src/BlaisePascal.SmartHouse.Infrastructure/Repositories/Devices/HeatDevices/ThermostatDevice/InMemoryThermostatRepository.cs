using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.HeatDevices.ThermostatDevice
{
    public class InMemoryThermostatRepository: IThermostatRepositories
    {
        private readonly List<Thermostat> _thermostats;

        public InMemoryThermostatRepository()
        {
            _thermostats = new List<Thermostat>();
            {
                new Thermostat(Name.CreateNew("Thermostat 1"));
                new Thermostat(Name.CreateNew("Thermostat 2"));
                new Thermostat(Name.CreateNew("Thermostat 3"));
            }
        }

        public List<Thermostat> GetAll()
        {
            return _thermostats;
        }

        public Thermostat GetById(Guid id)
        {
            foreach (var thermostat in _thermostats)
            {
                if (thermostat.Id == id)
                {
                    return thermostat;
                }
            }

            return null;
        }

        public void Add(Thermostat thermostat)
        {
            if (thermostat == null)
            {
                throw new ArgumentNullException("cannot add a null thermostat");
            }
            _thermostats.Add(thermostat);
        }

        public void Remove(Guid id)
        {
            var thermostat = GetById(id);
            if (thermostat != null)
            {
                _thermostats.Remove(thermostat);

            }

            throw new ArgumentNullException("thermostat not found");
        }

        public void Update(Thermostat thermostat)
        {

        }
    }
}
