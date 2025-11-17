using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp : Lamp
    {
        DateTime EndHour { get; set; }
        TimeSpan Timer { get; set; }
       
       
        public EcoLamp(string name, TimeSpan timer) : base(name) 
        {
            EndHour = new DateTime();
            Timer = timer;
        }

        public void SetTimer(TimeSpan timer)
        {
            Timer = timer;
        }

        public override void SwitchOn()
        {
            if (Status == DeviceStatus.Off)
            {
                Status = DeviceStatus.On;
                EndHour = DateTime.Now.Add(Timer);
                LastModified = DateTime.Now;
            }
            else
            {
                throw new InvalidOperationException("the lamp is already on");
            }
            while (DateTime.UtcNow <= EndHour)
            {
                if (DateTime.UtcNow == EndHour)
                {
                    Status = DeviceStatus.Off;
                    LastModified = DateTime.Now;
                }
                    

            }
        }

        public override void SwitchOff()
        {
            if (Status == DeviceStatus.On)
            {
                Status = DeviceStatus.Off;
                LastModified = DateTime.Now;

            } else
            {
                throw new InvalidOperationException("the lamp is already off");
            }
        }

        public override void ChangeBrightness(int newBrightness)
        {
            if (Status == DeviceStatus.On)
            {
                BrightnessPercentage = Validator.BritghnessValue(newBrightness);
                LastModified = DateTime.Now;
            }
            else
            {
                throw new InvalidOperationException("cannot change brightness when the lamp is off");
            }
        }
       
        
    

        


    }
}
