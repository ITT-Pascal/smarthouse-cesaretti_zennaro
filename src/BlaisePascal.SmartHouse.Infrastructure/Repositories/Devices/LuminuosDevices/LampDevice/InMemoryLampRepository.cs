using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Repositories;
using System.Security.Cryptography.X509Certificates;


namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.InMemory.Devices.LuminousDevices
{
    public class InMemoryLampRepository: ILampRepository
    {
        private readonly List<Lamp> _lamps = new List<Lamp>();

        public InMemoryLampRepository()
        {
            
            //_lamps.Add(new Lamp(Name.CreateNew("Lamp 1")));
            //_lamps.Add(new Lamp(Name.CreateNew("Lamp 2")));
            //_lamps.Add(new Lamp(Name.CreateNew("Lamp 3")));

        }

        public List<Lamp> GetAll()
        {
            return _lamps;
        }

        public Lamp GetById(Guid id)
        {
            foreach(Lamp lamp in _lamps)
            {
                if (lamp.Id == id)
                    return lamp;
            }

            return null;
        }

        public void Add(Lamp lamp)
        {
            if(lamp == null)
                throw new ArgumentNullException("cannot add a null lamp");

            _lamps.Add(lamp);
        }

        public void Remove(Guid id)
        {
            var lamp = GetById(id);
            if(lamp != null)
            {
                _lamps.Remove(lamp);
                return;
            }

            throw new ArgumentException("Lamp not found");
        }

        public void Update(Lamp lamp)
        {

        }

    }
}
