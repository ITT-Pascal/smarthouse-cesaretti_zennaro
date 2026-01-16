using BlaisePascal.SmartHouse.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Asbtraction
{
    public abstract class AbstractDevice: IDevice
    {
        public string Name { get; protected set; }
        public Guid Id { get; protected set; }
        public DeviceStatus Status { get; protected set; }
        public DateTime CreationHour { get; protected set; }
        public DateTime LastModified { get; protected set; }

        public AbstractDevice(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
            CreationHour = DateTime.Now;
            Status = DeviceStatus.Off;
            LastModified = DateTime.Now;
        }

        public virtual void SwitchOn()
        {
            if (Status == DeviceStatus.On)
                throw new InvalidOperationException($"{Name} is alrady on");

            Status = DeviceStatus.On;
            LastModified = DateTime.Now;
        }

        public virtual void SwitchOff()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException($"{Name} is alrady off");

            Status = DeviceStatus.Off;
            LastModified = DateTime.Now;
        }


    }
}
