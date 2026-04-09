using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HeatDevice.ThermostatDevice.Commands
{
    public class RemoveThermostatCommand
    {
        private readonly IThermostatRepositories _repository;
        public RemoveThermostatCommand(IThermostatRepositories repository)
        {
            _repository = repository;
        }
        public void Execute(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
