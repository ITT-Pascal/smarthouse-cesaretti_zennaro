using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{

    public class LampsRow
    {
        public List<AbstractLamp> _LampsRow { get; private set; }

        public LampsRow()
        {
            _LampsRow = new List<AbstractLamp>();
        }

        public void SwitchOn()
        {
            foreach (AbstractLamp lamp in _LampsRow)
            {
                lamp.SwitchOn();
                
            }
        }

        public void SwitchOn(Guid id)
        {
            foreach (AbstractLamp lamp in _LampsRow)
            {
                if(lamp.Id == id && lamp.Status == DeviceStatus.Off)
                {
                    lamp.SwitchOn();
                }
            }
        }

        public void SwitchOff()
        {
            foreach (AbstractLamp lamp in _LampsRow)
            {
                lamp.SwitchOn();

            }
        }




    } 

}

      

