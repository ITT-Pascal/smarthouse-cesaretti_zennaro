using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HeatDevice.ThermostatDevice.Commands
{
    public class AddThermostatCommand
    {
        private readonly IThermostatRepositories _repository;

        public AddThermostatCommand(IThermostatRepositories repository)
        {
            _repository = repository;
        }

        public void Execute(string name)
        {
             _repository.Add(new Thermostat(Name.CreateNew(name)));
        }
    }
}
