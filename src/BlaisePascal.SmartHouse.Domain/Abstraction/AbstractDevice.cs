using BlaisePascal.SmartHouse.Domain.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.Asbtraction
{
    public abstract class AbstractDevice: IDevice
    {
        public Name Name { get; protected set; }
        public Guid Id { get; protected set; }
        public DeviceStatus Status { get; protected set; }
        public DateTime CreationHour { get; protected set; }
        public DateTime LastModified { get; protected set; }

        public AbstractDevice(string name)
        {
            Name = Name.CreateNew(name);
            Id = Guid.NewGuid();
            CreationHour = DateTime.Now;
            Status = DeviceStatus.On;
            LastModified = DateTime.Now;
        }

        public virtual void SwitchOn()
        {
            AbstractDeviceValidator.CheckIsOn(Status);
            Status = DeviceStatus.On;
            LastModified = DateTime.Now;
        }

        public virtual void SwitchOff()
        {
            AbstractDeviceValidator.CheckIsOff(Status);
            Status = DeviceStatus.Off;
            LastModified = DateTime.Now;
        }


    }
}
