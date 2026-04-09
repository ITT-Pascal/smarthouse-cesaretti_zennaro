using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HeatDevices.AirConditionerDevice.Commands
{
    public class UpdateAirConditionerCommand
    {
        private readonly IAirConditionerRepository _repository;
    
        public UpdateAirConditionerCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }
    
        public void Execute(AirConditioner airConditioner)
        {
            _repository.Update(airConditioner);
        }
    }
}
