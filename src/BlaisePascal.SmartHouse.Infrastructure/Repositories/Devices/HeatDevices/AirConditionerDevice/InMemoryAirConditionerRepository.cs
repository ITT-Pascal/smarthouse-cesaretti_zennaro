using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.HeatDevices.AirConditionerDevice
{
    public class InMemoryAirConditionerRepository: IAirConditionerRepository
    {
        private readonly List<AirConditioner> _airConditioners;

        public InMemoryAirConditionerRepository()
        {
            _airConditioners = new List<AirConditioner>();
            {
                new AirConditioner(Name.CreateNew("air 1"));
                new AirConditioner(Name.CreateNew("air 2"));
                new AirConditioner(Name.CreateNew("air 3"));
            }
        }

        public List<AirConditioner> GetAll()
        {
            return _airConditioners;
        }

        public AirConditioner GetById(Guid id)
        {
            foreach(var airConditioner in _airConditioners)
            {
                if (airConditioner.Id == id)
                {
                    return airConditioner;
                }
            }

            return null;
        }
        public void Add(AirConditioner airConditioner)
        {
            if(airConditioner == null)
                throw new ArgumentNullException("cannot add a null airConditioner");

            _airConditioners.Add(airConditioner);
        }

        public void Remove(Guid id)
        {
            var airConditioner = GetById(id);   
            if(airConditioner != null)
            {
                _airConditioners.Remove(airConditioner);
            }

            throw new ArgumentException("airConditioner not found");
        }

        public void Update(AirConditioner airConditioner)
        {
            
        }
    }
}
