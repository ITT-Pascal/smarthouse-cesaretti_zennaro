using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.Devices.Illumination
{
    public class TwoLampDevice
    {
        public AbstractLamp FirstLamp { get; private set; }
        public AbstractLamp SecondLamp { get; private set; }
        public DeviceStatus DeviceStatus
        {
            get
            {
                DeviceStatus Status = DeviceStatus.Off;
                
                if (FirstLamp.Status == DeviceStatus.On || SecondLamp.Status == DeviceStatus.Off)
                    return DeviceStatus.On;

                return Status;
            }

            private set { }
        }


        public TwoLampDevice(AbstractLamp firstLamp, AbstractLamp secondLamp)
        {
            FirstLamp = firstLamp;
            SecondLamp = secondLamp;
        }


        public void TurnLampsOn()
        {
            FirstLamp.SwitchOn();
            SecondLamp.SwitchOn();  
        }

        public void TurnLampsOn(Guid id)
        {
            if (FirstLamp.Id == id) 
            {
                FirstLamp.SwitchOn();
            }
            else if(SecondLamp.Id == id)
            {
                SecondLamp.SwitchOn();
            }
            else
            {
                throw new ArgumentException("non valid id");
            }
        }

        public void TurnLampsOn(string name)
        {
            if (FirstLamp.Name == name)
            {
                FirstLamp.SwitchOn();
            }
            else if (SecondLamp.Name == name)
            {
                SecondLamp.SwitchOn();
            } else
            {
                throw new ArgumentException("non valid name");
            }
        }

        public void EcoTurnLampsOn(Guid id)
        {
            if (FirstLamp.Id == id && FirstLamp is EcoLamp firstLamp)
            {
                firstLamp.EcoSwitchOn();
            } else if(SecondLamp.Id == id && SecondLamp is EcoLamp secondLamp)
            {
                secondLamp.EcoSwitchOn();
            } else
            {
                throw new ArgumentException("not valid id");
            }
        }

        public void EcoTurnLampsOn(string name)
        {
            if (FirstLamp.Name == name && FirstLamp is EcoLamp firstLamp)
            {
                firstLamp.EcoSwitchOn();
            }
            else if (SecondLamp.Name == name && SecondLamp is EcoLamp secondLamp)
            {
                secondLamp.EcoSwitchOn();
            }
            else
            {
                throw new ArgumentException("not valid name");
            }
        }

        public void EcoTurnLampsOn(Guid id, TimeSpan timer)
        {
            if (FirstLamp.Id == id && FirstLamp is EcoLamp firstLamp)
            {
                firstLamp.EcoSwitchOn(timer);
            }
            else if (SecondLamp.Id == id && SecondLamp is EcoLamp secondLamp)
            {
                secondLamp.EcoSwitchOn(timer);
            }
            else
            {
                throw new ArgumentException("not valid id");
            }
        }

        public void EcoTurnLampsOn(string name, TimeSpan timer)
        {
            if (FirstLamp.Name == name && FirstLamp is EcoLamp firstLamp)
            {
                firstLamp.EcoSwitchOn(timer);
            }
            else if (SecondLamp.Name == name && SecondLamp is EcoLamp secondLamp)
            {
                secondLamp.EcoSwitchOn(timer);
            }
            else
            {
                throw new ArgumentException("not valid name");
            }
        }
        public void TurnLampsOff()
        {
            FirstLamp.SwitchOff();
            SecondLamp.SwitchOff();
        }

        public void TurnLampsOff(Guid id)
        {
            if (FirstLamp.Id == id)
            {
                FirstLamp.SwitchOff();
            }
            else if (SecondLamp.Id == id)
            {
                SecondLamp.SwitchOff();
            }
            else
            {
                throw new ArgumentException("non valid id");
            }
        }

        public void TurnLampsOff(string name)
        {
            if (FirstLamp.Name == name)
            {
                FirstLamp.SwitchOff();
            }
            else if (SecondLamp.Name == name)
            {
                SecondLamp.SwitchOff();
            } else
            {
                throw new ArgumentException("non valid name");
                
            }
        }

        public void ChangeBothLampsBrightness(int newBrightness)
        {
            FirstLamp.SetBrightness(newBrightness);
            SecondLamp.SetBrightness(newBrightness);
        }

        public void ChangeLampBrightness(Guid id, int newBrightness)
        {
            if(FirstLamp.Id == id)
            {
                FirstLamp.SetBrightness(newBrightness);
            }
            else if(SecondLamp.Id == id)
            {
                SecondLamp.SetBrightness(newBrightness);
            } else
            {
                throw new ArgumentException("non valid id");
            }
        }

        public void ChangeLampBrightness(string name, int newBrightness)
        {
            if (FirstLamp.Name == name)
            {
                FirstLamp.SetBrightness(newBrightness);
            }
            else if (SecondLamp.Name == name)
            {
                SecondLamp.SetBrightness(newBrightness);
            }
            else
            {
                throw new ArgumentException("non valid name");
            }
        }

        public void IncreaseLampBrightness(int step)
        {
            FirstLamp.Brighten(step);
            SecondLamp.Brighten(step);
        }

        public void IncreaseLampBrightness(Guid id, int step)
        {

            if (FirstLamp.Id == id)
            {
                FirstLamp.Brighten(step);
            }
            else if (SecondLamp.Id == id)
            {
                SecondLamp.Brighten(step);
            }
            else
            {
                throw new ArgumentException("not valid id");
            }
        }


        public void IncreaseLampBrightness(string name, int step)
        {

            if (FirstLamp.Name == name)
            {
                FirstLamp.Brighten(step);
            }
            else if (SecondLamp.Name == name)
            {
                SecondLamp.Brighten(step);
            } else
            {
                throw new ArgumentException("not valid name");
            }
        }


        public void DecreaseBothLampsBrightness(int step)
        {
            FirstLamp.Dimmer(step);
            SecondLamp.Dimmer(step);
        }

        public void DecreaseLampBrightness(Guid id, int step)
        {

            if (FirstLamp.Id == id)
            {
                FirstLamp.Dimmer(step);
            }
            else if (SecondLamp.Id == id)
            {
                SecondLamp.Dimmer(step);
            }
            else
            {
                throw new ArgumentException("not valid id");
            }
        }


        public void DecreaseLampBrightness(string name, int step)
        {

            if (FirstLamp.Name == name)
            {
                FirstLamp.Dimmer(step);
            }
            else if (SecondLamp.Name == name)
            {
                SecondLamp.Dimmer(step);
            }
            else
            {
                throw new ArgumentException("not valid name");
            }
        }

      




    }
}
