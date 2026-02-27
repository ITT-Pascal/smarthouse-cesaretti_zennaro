using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.HeatDevices.AirConditionerDevice.Commands
{
    public class AddAirConditionerCommand
    {
        private readonly IAirConditionerRepository _repository;

        public AddAirConditionerCommand(IAirConditionerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(string name)
        {
            _repository.Add(new AirConditioner(Name.CreateNew(name)));
        }
    }
}
