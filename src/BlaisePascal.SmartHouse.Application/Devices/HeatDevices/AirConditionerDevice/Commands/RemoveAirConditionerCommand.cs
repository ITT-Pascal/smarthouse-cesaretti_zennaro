using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HeatDevices.AirConditionerDevice.Commands
{
    public class RemoveAirConditionerCommand
    {
        private readonly IAirConditionerRepository _repository;
        public RemoveAirConditionerCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }
        public void Execute(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
