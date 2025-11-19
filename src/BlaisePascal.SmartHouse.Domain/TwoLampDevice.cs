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
            } else
            {

            }
        }



        public void TurnLampsOff()
        {
            FirstLamp.SwitchOff();
            SecondLamp.SwitchOff();
        }


     
        public void ChangeLampBrightness(int lampNumber, int newBrightness)
        {
            if(LampValidator.LampNumberValidator(lampNumber) == 1)
            {
                FirstLamp.ChangeBrightness(newBrightness);
            }
            else
            {
                SecondLamp.ChangeBrightness(newBrightness);
            }
        }


        public void ChangeBothLampsBrightness(int newBrightness)
        {
            FirstLamp.ChangeBrightness(newBrightness);
            SecondLamp.ChangeBrightness(newBrightness);
        }


        public void IncreaseLampBrightness(int lampNumber, int value)
        {
            if(LampValidator.LampNumberValidator(lampNumber) == 1)
            {
                FirstLamp.IncreaseBy(value);
            } else
            {
                SecondLamp.IncreaseBy(value);
            }
        }


        public void DecreaseLampBrightness(int lampNumber, int value)
        {

            if (LampValidator.LampNumberValidator(lampNumber) == 1)
            {
                FirstLamp.DecreaseBy(value);
            }
            else
            {
                SecondLamp.DecreaseBy(value);
            }
        }


        public void IncreaseBothLampsBrightness(int value)
        {
            FirstLamp.IncreaseBy(value);
            SecondLamp.IncreaseBy(value);
        }


        public void DecreaseBothLampsBrightness(int decreaseBy)
        {
            FirstLamp.DecreaseBy(decreaseBy);
            SecondLamp.DecreaseBy(decreaseBy);
        }


       
    }
}
