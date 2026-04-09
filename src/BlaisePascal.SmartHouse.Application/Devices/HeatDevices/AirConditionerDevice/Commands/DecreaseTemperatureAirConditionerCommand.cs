using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HeatDevices.AirConditionerDevice.Commands
{
    public class DecreaseTemperatureAirConditionerCommand
    {
        private readonly IAirConditionerRepository _repository;

        public DecreaseTemperatureAirConditionerCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id, int value)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                result.DecreaseTemperature(value);
                _repository.Update(result);
            }
        }
    }
}
