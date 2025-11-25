using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp : AbstractLamp
    {
        DateTime EndHour { get; set; }
       
       
        public EcoLamp(string name) : base(name) 
        {
            EndHour = new DateTime();
        }

        public EcoLamp(int brightness, string name) : base(brightness, name)
        {
            EndHour = new DateTime();
        }



        public override void SwitchOn()
        {
            if (Status == DeviceStatus.Off)
            {
                Status = DeviceStatus.On;
                LastModified = DateTime.Now;
            }
            else
            {
                throw new InvalidOperationException("the lamp is already on");
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
                BrightnessPercentage = LampValidator.Britghness(newBrightness);
                LastModified = DateTime.Now;
            }
            else
            {
                throw new InvalidOperationException("cannot change brightness when the lamp is off");
            }
        }

       
       
        
    

        


    }
}
