using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain
{
    public abstract class AbstractLamp
    {
        protected const int MaxValue = 100;
        protected const int MinValue = 0;

        public string Name { get; protected set; }
        public Guid Id { get; protected set; }
        public DeviceStatus Status { get; protected set; }
        public int BrightnessPercentage { get; protected set; }
        public DateTime CreationHour { get; protected set; }
        public DateTime LastModified { get; protected set; }

        public AbstractLamp (string name)
        {
            Name = name;
            Id = Guid.NewGuid ();
            Status = DeviceStatus.Off;
            BrightnessPercentage = 0;
            CreationHour = DateTime.Now;
            LastModified = DateTime.Now;
        }


        public AbstractLamp(int brightness, string name)
        {
            Name = name;
            Id = Guid.NewGuid();
            Status = DeviceStatus.On;
            BrightnessPercentage = brightness;
            CreationHour = DateTime.Now;
            LastModified = DateTime.Now;
            
        }

        public abstract void SwitchOn();
        public abstract void SwitchOff();
        public abstract void ChangeBrightness(int brightness);


        public void IncreaseBy(int value)
        {
            if(Status == DeviceStatus.On)
            {
                if(BrightnessPercentage + Validator.Value(value) > MaxValue)
                {
                    BrightnessPercentage = MaxValue;
                } else
                {
                    BrightnessPercentage += value;
                }

                LastModified = DateTime.Now;
            } else
            {
                throw new InvalidOperationException("cannot increase brightness when the lamp is off");
            }
        }

        public void DecreaseBy(int value)
        {
            if (Status == DeviceStatus.On)
            {
                if (BrightnessPercentage - Validator.Value(value) < MinValue)
                {
                    BrightnessPercentage = MinValue;
                }
                else
                {
                    BrightnessPercentage -= value;
                }

                LastModified = DateTime.Now;
            }
            else
            {
                throw new InvalidOperationException("cannot decrease brightness when the lamp is off");
            }
        }
    }
}
