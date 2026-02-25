using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Door;
using BlaisePascal.SmartHouse.Domain.Devices.Door.Repositories;
using BlaisePascal.SmartHouse.Domain.Devices.Door.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.DoorDevice
{
    public class InMemoryDoorRepository: IDoorRepository
    {
        private readonly List<Door> _doors;
        
        public InMemoryDoorRepository()
        {
            _doors = new List<Door>();
            {
                new Door(Name.CreateNew("Door 1"), Password.CreateNew("1234"));
                new Door(Name.CreateNew("Door 2"), Password.CreateNew("1234"));
                new Door(Name.CreateNew("Door 3"), Password.CreateNew("1234"));
            }
        }

        public List<Door> GetAll()
        {
            return _doors;
        }

        public Door GetById(Guid id)
        {
            foreach (var door in _doors)
            {
                if (door.Id == id)
                {
                    return door;
                }
            }

            throw new ArgumentException("door not found");
        }

        public void Add(Door door)
        {
            if(door == null)
            {
                throw new ArgumentNullException("cannot add a null door");
            }

            _doors.Add(door);
        }

        public void Remove(Guid id)
        {
            var door = GetById(id);
            if(door != null)
            {
                _doors.Remove(door);
            }

            throw new ArgumentException("door not found");
        }

        public void Update(Door door)
        {
            
        }
    }
}
