using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HeatDevices.AirConditionerDevice.Commands
{
    public class DecreaseDefaultTemperatureAirConditionerCommand
    {
        private readonly IAirConditionerRepository _repository;
        public DecreaseDefaultTemperatureAirConditionerCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }
        public void Execute(Guid id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                result.DecreaseTemperature();
                _repository.Update(result);
            }
        }
    }
}
