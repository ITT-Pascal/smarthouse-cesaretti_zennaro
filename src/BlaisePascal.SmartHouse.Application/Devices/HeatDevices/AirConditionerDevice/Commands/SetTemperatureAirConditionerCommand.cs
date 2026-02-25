using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HeatDevices.AirConditionerDevice.Commands
{
    public class SetTemperatureAirConditionerCommand
    {
        private readonly IAirConditionerRepository _repository;
        public SetTemperatureAirConditionerCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }
        public void Execute(Guid id, int temperature)
        {
            var result = _repository.GetById(id);
            if(result != null)
            {
                result.SetTemperature(Temperature.AirConditionerCreateNew(temperature));
                _repository.Update(result);
            }
        }
    }
}
