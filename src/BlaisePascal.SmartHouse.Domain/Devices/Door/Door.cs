using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Door.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.Door
{
    public class Door : AbstractDevice
    {

        public DoorStatus DoorStatus { get; private set; }
        public Password Password { get; private set; }

        public Door(Name name, Password password) : base(name)
        {
            Password = password;
            DoorStatus = DoorStatus.Closed;
        }

        public Door(Guid id, Name name, DeviceStatus deviceStatus, DateTime creationHour, DateTime lastModified, DoorStatus doorStatus, Password password) : base(id, name, deviceStatus, creationHour, lastModified)
        {
            DoorStatus = doorStatus;
            Password = password;
        }

        public void Open()
        {
            DoorValidator.CheckIsOn(DeviceStatus);
            DoorValidator.CanOpen(DoorStatus);
            DoorStatus = DoorStatus.Open;
            LastModified = DateTime.Now;
        }
        public void Close()
        {
            DoorValidator.CheckIsOn(DeviceStatus);
            DoorValidator.CanClose(DoorStatus);
            DoorStatus = DoorStatus.Closed;
            LastModified = DateTime.Now;
        }
        public void Lock()
        {
            DoorValidator.CheckIsOn(DeviceStatus);
            DoorValidator.CanLock(DoorStatus);
            DoorStatus = DoorStatus.Locked;
            LastModified = DateTime.Now;
        }
        public void Unlock(Password password)
        {
            DoorValidator.CheckIsOn(DeviceStatus);
            DoorValidator.CanUnlock(DoorStatus);
            DoorValidator.IsPasswordRight(Password, password);
            DoorStatus = DoorStatus.Closed;
            LastModified = DateTime.Now;
        }

        public void ChangePassword(Password oldPassword, Password newPassword)
        {
            DoorValidator.CheckIsOn(DeviceStatus);
            DoorValidator.IsPasswordRight(Password, oldPassword);
            Password = newPassword;
            LastModified = DateTime.Now;
        }
    }
}
