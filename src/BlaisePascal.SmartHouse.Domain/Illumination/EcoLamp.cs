using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain.Illumination;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{
    public class EcoLamp: AbstractLamp
    {

        public DateTime EndHour { get; private set; }
        public TimeSpan DefaultTimer { get; private set; } = TimeSpan.FromMinutes(15);


        public EcoLamp(string name) : base(name)
        {
            EndHour = new DateTime();

        }

        public EcoLamp(int brightness, string name) : base(brightness, name)
        {
            EndHour = new DateTime();
        }

        public void EcoSwitchOn()
        {
            SwitchOn();
            EndHour = DateTime.Now.Add(DefaultTimer);

            if (DateTime.Now >= EndHour)
            {
                SwitchOff();
            }
            LastModified = DateTime.UtcNow;
        }

        public void EcoSwitchOn(TimeSpan timer)
        {
            SwitchOn();
            EndHour = DateTime.Now.Add(timer);

            if (DateTime.Now >= EndHour)
            {
                SwitchOff();
            }
            LastModified = DateTime.UtcNow;
        }

    }
}
