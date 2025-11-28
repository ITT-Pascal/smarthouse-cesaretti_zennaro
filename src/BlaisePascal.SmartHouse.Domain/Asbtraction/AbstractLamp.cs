using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using BlaisePascal.SmartHouse.Domain.DevicesStatus;
using BlaisePascal.SmartHouse.Domain.Validator;

namespace BlaisePascal.SmartHouse.Domain.Asbtraction
{
    public abstract class AbstractLamp: AbstractDevice
    {
        public abstract int MinBrigthness { get; protected set; }
        public abstract int MaxBrightness { get; protected set; }
        public int Brightness { get; protected set; }

        public AbstractLamp(string name) : base(name) { }
        public AbstractLamp(string name, int brightness) : base(name) 
        {
            Status = DeviceStatus.On;
            SetBrightness(brightness);
        }
        
        public void Brighten(int step)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot change brightness when lamp is off");
            
            Brightness = Math.Min(MaxBrightness, Brightness + LampValidator.IsPositive(step));
            LastModified = DateTime.UtcNow; 
        }

        public void Dimmer(int step)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot change brightness when lamp is off");

            Brightness = Math.Max(MinBrigthness, Brightness - LampValidator.IsPositive(step));
            LastModified = DateTime.UtcNow;
        }

        public void SetBrightness(int brightness)
        {
            if(Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot change brightness when lamp is off");

            Brightness = LampValidator.BrightnessValidator(brightness);
        }


       
        

        






    }
}
