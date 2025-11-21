using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class TwoLampDevice
    {
        public AbstractLamp FirstLamp { get; private set; }
        public AbstractLamp SecondLamp { get; private set; }
        public DeviceStatus DeviceStatus
        {
            get
            {
                if (FirstLamp.Status == DeviceStatus.On || SecondLamp.Status == DeviceStatus.Off)
                {
                    return DeviceStatus.On;
                }
                else
                {
                    return DeviceStatus.Off;
                }
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
            FirstLamp.ChangeBrightness(newBrightness);
            SecondLamp.ChangeBrightness(newBrightness);
        }

        public void ChangeLampBrightness(Guid id, int newBrightness)
        {
            if(FirstLamp.Id == id)
            {
                FirstLamp.ChangeBrightness(newBrightness);
            }
            else if(SecondLamp.Id == id)
            {
                SecondLamp.ChangeBrightness(newBrightness);
            } else
            {
                throw new ArgumentException("non valid id");
            }
        }

        public void ChangeLampBrightness(string name, int newBrightness)
        {
            if (FirstLamp.Name == name)
            {
                FirstLamp.ChangeBrightness(newBrightness);
            }
            else if (SecondLamp.Name == name)
            {
                SecondLamp.ChangeBrightness(newBrightness);
            }
            else
            {
                throw new ArgumentException("non valid name");
            }
        }

        public void IncreaseLampBrightness(int value)
        {
            FirstLamp.IncreaseBy(value);
            SecondLamp.IncreaseBy(value);
        }

        public void IncreaseLampBrightness(Guid id, int value)
        {

            if (FirstLamp.Id == id)
            {
                FirstLamp.IncreaseBy(value);
            }
            else if (SecondLamp.Id == id)
            {
                SecondLamp.IncreaseBy(value);
            }
            else
            {
                throw new ArgumentException("not valid id");
            }
        }


        public void IncreaseLampBrightness(string name, int value)
        {

            if (FirstLamp.Name == name)
            {
                FirstLamp.IncreaseBy(value);
            }
            else if (SecondLamp.Name == name)
            {
                SecondLamp.IncreaseBy(value);
            } else
            {
                throw new ArgumentException("not valid name");
            }
        }


        public void DecreaseBothLampsBrightness(int value)
        {
            FirstLamp.DecreaseBy(value);
            SecondLamp.DecreaseBy(value);
        }

        public void DecreaseLampBrightness(Guid id, int value)
        {

            if (FirstLamp.Id == id)
            {
                FirstLamp.DecreaseBy(value);
            }
            else if (SecondLamp.Id == id)
            {
                SecondLamp.DecreaseBy(value);
            }
            else
            {
                throw new ArgumentException("not valid id");
            }
        }


        public void DecreaseLampBrightness(string name, int value)
        {

            if (FirstLamp.Name == name)
            {
                FirstLamp.DecreaseBy(value);
            }
            else if (SecondLamp.Name == name)
            {
                SecondLamp.DecreaseBy(value);
            }
            else
            {
                throw new ArgumentException("not valid name");
            }
        }




    }
}
