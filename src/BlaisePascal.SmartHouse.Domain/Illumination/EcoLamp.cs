using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain.DevicesStatus;
using BlaisePascal.SmartHouse.Domain.Validator;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp : AbstractLamp
    {
        public DateTime EndHour { get; private set; }
       
       
        public EcoLamp(string name) : base(name) 
        {
            EndHour = new DateTime();
            
        }

        public EcoLamp(string name, int brightness) : base(name, brightness)
        {
            EndHour = new DateTime();
        }

        public void EcoSwitchOn()
        {
            base.SwitchOn();
            EndHour = DateTime.Now.Add(DefaultTimer);

            if (DateTime.Now >= EndHour)
            {
                base.SwitchOff();
            }
        }
    
}
