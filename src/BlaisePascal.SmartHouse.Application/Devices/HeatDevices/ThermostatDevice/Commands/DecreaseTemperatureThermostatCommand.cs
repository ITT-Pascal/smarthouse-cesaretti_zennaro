using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HeatDevices.ThermostatDevice.Commands
{
    public class DecreaseTemperatureThermostatCommand
    {
        private readonly IThermostatRepositories _repository;
    
        public DecreaseTemperatureThermostatCommand(IThermostatRepositories repository)
        {
            _repository = repository;
        }
    
        public void Execute(Thermostat thermostat, int value)
        {
            var result = _repository.GetById(thermostat.Id);
            if (result != null)
            {
                result.DecreaseTemperature(value);
                _repository.Update(result);
            }
        }
    }
}
