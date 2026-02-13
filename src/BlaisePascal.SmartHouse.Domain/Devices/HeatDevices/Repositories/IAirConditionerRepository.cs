using BlaisePascal.SmartHouse.Domain.Devices.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Repositories
{
    public interface IAirConditionerRepository
    {
        void Add(AirConditioner airConditioner);
        void Update(AirConditioner airConditioner);
        void Remove(Guid id);
        AirConditioner GetById(Guid id);
        List<AirConditioner> GetAll();
    }
}
