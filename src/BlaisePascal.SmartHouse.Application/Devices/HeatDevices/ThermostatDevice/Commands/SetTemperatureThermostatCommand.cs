using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HeatDevices.ThermostatDevice.Commands
{
    public class SetTemperatureThermostatCommand
    {
        private readonly IThermostatRepositories _repository;

        public SetTemperatureThermostatCommand(IThermostatRepositories repository)
        {
            _repository = repository;
        }

        public void Execute(Thermostat thermostat, int temperature)
        {
            var result = _repository.GetById(thermostat.Id);
            if (result != null)
            {
                result.SetTemperature(Temperature.ThermostatCreateNew(temperature));
                _repository.Update(result);
            }
        }
    }
}
