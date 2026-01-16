using BlaisePascal.SmartHouse.Domain.Asbtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Door
{
    public class Door: AbstractDevice, IDoor
    {

        public DoorStatus DoorStatus { get; private set; }
        public string Password { get; private set; }
        public Door(string name, string password): base(name) 
        {
            Password = password;
            DoorStatus = DoorStatus.Closed;
        }
        public void OpenDoor()
        {
            DoorValidator.CheckIsOn(Status);
            DoorValidator.CanOpen(DoorStatus);
            DoorStatus = DoorStatus.Open;
            LastModified = DateTime.Now;
        }
        public void CloseDoor()
        {
            DoorValidator.CheckIsOn(Status);
            DoorValidator.CanClose(DoorStatus);
            DoorStatus = DoorStatus.Closed;
            LastModified = DateTime.Now;
        }
        public void LockDoor()
        {
            DoorValidator.CheckIsOn(Status);
            DoorValidator.CanLock(DoorStatus);
            DoorStatus = DoorStatus.Locked;
            LastModified = DateTime.Now;
        }
        public void UnlockDoor(string password)
        {
            DoorValidator.CheckIsOn(Status);
            DoorValidator.CanUnlock(DoorStatus);
            DoorValidator.IsPasswordRight(Password, password);
            DoorStatus = DoorStatus.Closed;
            LastModified = DateTime.Now;
        }
    }
}
