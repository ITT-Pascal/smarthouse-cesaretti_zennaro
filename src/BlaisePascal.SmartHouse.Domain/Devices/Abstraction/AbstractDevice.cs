using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.Abstraction
{
    public abstract class AbstractDevice: IDevice
    {
        public Name Name { get; protected set; }
        public Guid Id { get; protected set; }
        public DeviceStatus DeviceStatus { get; protected set; }
        public DateTime CreationHour { get; protected set; }
        public DateTime LastModified { get; protected set; }

        public AbstractDevice(Name name)
        {            
            Name = name;
            Id = Guid.NewGuid();
            CreationHour = DateTime.Now;
            DeviceStatus = DeviceStatus.On;
            LastModified = DateTime.Now;
        }

        public AbstractDevice(Guid id, Name name, DeviceStatus status, DateTime creationHour, DateTime lastModified)
        {
            Id = id;
            Name = name;
            DeviceStatus = status;
            CreationHour = creationHour;
            LastModified = lastModified;
        }

        public AbstractDevice() { }

        public virtual void SwitchOn()
        {
            AbstractDeviceValidator.CheckIsOn(DeviceStatus);
            DeviceStatus = DeviceStatus.On;
            LastModified = DateTime.Now;
        }

        public virtual void SwitchOff()
        {
            AbstractDeviceValidator.CheckIsOff(DeviceStatus);
            DeviceStatus = DeviceStatus.Off;
            LastModified = DateTime.Now;
        }
    }
}
