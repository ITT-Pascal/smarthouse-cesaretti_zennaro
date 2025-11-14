using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class TwoLampDevice
    {
        public Lamp FirstLamp { get; private set; }
        public Lamp SecondLamp { get; private set; }

        public TwoLampDevice(Lamp firstLamp, Lamp secondLamp)
        {
            if(firstLamp is EcoLamp)
            {
                FirstLamp = (EcoLamp)firstLamp;
            } else
            {
                FirstLamp = firstLamp; 
            }

            if(secondLamp is EcoLamp)
            {
                SecondLamp = (EcoLamp)secondLamp;
            } else
            {
                SecondLamp = secondLamp;
            }
        }


        public void TurnLampsOn()
        {
            if(FirstLamp is EcoLamp)
            {
                FirstLamp.EcoSwitchOn();
            }
            FirstLamp.SwitchOn();
            SecondLamp.SwitchOn();  
        }

        public void TurnLampsOff()
        {
            FirstLamp.SwitchOff();
            SecondLamp.SwitchOff();
        }


     
        public void ChangeLampBrightness(int lampNumber, int newBrightness)
        {
            if(Validator.LampNumberValidator(lampNumber) == 1)
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
        public void IncreaseLampBrightness(int lampNumber, int increaseBy)
        {
            if(Validator.LampNumberValidator(lampNumber) == 1)
            {
                FirstLamp.IncreaseBrightness(increaseBy);
            } else
            {
                SecondLamp.IncreaseBrightness(increaseBy);
            }
        }


        public void DecreaseLampBrightness(int lampNumber, int decreaseBy)
        {

            if (Validator.LampNumberValidator(lampNumber) == 1)
            {
                FirstLamp.DecreaseBrightness(decreaseBy);
            }
            else
            {
                SecondLamp.DecreaseBrightness(decreaseBy);
            }
        }


        public void IncreaseBothLampsBrightness(int increaseBy)
        {
            FirstLamp.IncreaseBrightness(increaseBy);
            SecondLamp.IncreaseBrightness(increaseBy);
        }


        public void DecreaseBothLampsBrightness(int decreaseBy)
        {
            FirstLamp.DecreaseBrightness(decreaseBy);
            SecondLamp.DecreaseBrightness(decreaseBy);
        }


       
    }
}
