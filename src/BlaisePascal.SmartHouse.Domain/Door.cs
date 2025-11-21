using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Door
    {
        public string Name { get; protected set; }
        public Guid Id { get; protected set; }
        public DoorStatus Status { get; protected set; }
        public string Password { get; protected set; }
        public Door(string name, string password)
        {
            Name = name;
            Password = password.Trim();
            Id = Guid.NewGuid();
            Status = DoorStatus.Closed;
        }
        public void OpenDoor()
        {
            if (Status != DoorStatus.Closed)
                throw new InvalidOperationException("Door must be closed and unlocked");
            Status = DoorStatus.Open;
        }
        public void CloseDoor()
        {
            if (Status != DoorStatus.Open)
                throw new InvalidOperationException("Door must be open");
            Status = DoorStatus.Closed;
        }
        public void LockDoor(string password)
        {
            if (!Password.Equals(password))
                throw new InvalidOperationException("Wrong Password");
            if (Status != DoorStatus.Closed)
                throw new InvalidOperationException("Door must be closed and unlocked");
            Status = DoorStatus.Locked;
        }
        public void UnlockDoor(string password)
        {
            if (!Password.Equals(password))
                throw new InvalidOperationException("Wrong Password");
            if (Status != DoorStatus.Locked)
                throw new InvalidOperationException("Door must be locked");
            Status = DoorStatus.Closed;
        }
    }
}
