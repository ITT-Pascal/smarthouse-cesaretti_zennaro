using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HeatDevices.ThermostatDevice.Commands
{
    public class DecreaseDefaultTemperatureThermostatCommand
    {
        private readonly IThermostatRepositories _repository;

        public DecreaseDefaultTemperatureThermostatCommand(IThermostatRepositories repository)
        {
            _repository = repository;
        }

        public void Execute(Thermostat thermostat)
        {
            var result = _repository.GetById(thermostat.Id);
            if (result != null)
            {
                result.DecreaseTemperature();
                _repository.Update(result);
            }
        }
    }
}
