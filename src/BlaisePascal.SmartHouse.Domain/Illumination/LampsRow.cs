using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain.DevicesStatus;
using BlaisePascal.SmartHouse.Domain.Validator;

namespace BlaisePascal.SmartHouse.Domain.Illumination
{

    public class LampsRow
    {
        public List<AbstractLamp> Lamps { get; private set; }
        public DeviceStatus? LampsStatus
        {
            get
            {
                DeviceStatus? lampsStatus = DeviceStatus.Off;

                if (Lamps.Count == 0)
                {
                    lampsStatus = null;
                } else
                {
                    foreach (AbstractLamp lamp in Lamps)
                    {
                        if (lamp.Status == DeviceStatus.On)
                        {
                            lampsStatus = DeviceStatus.On;
                        }
                    }
                }
                return lampsStatus;
            }
            private set { }
        }



        public LampsRow()
        {
            Lamps = new List<AbstractLamp>();
        }

        public LampsRow(List<AbstractLamp> lamps)
        {
            Lamps = lamps;
        }



        public void SwitchOn()
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                lamp.SwitchOn();

            }
        }

        public void SwitchOn(Guid id)
        {
            bool foundLamp = false;
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Id == id)
                {
                    lamp.SwitchOn();
                    foundLamp = true;
                }
            }
            if (foundLamp == false)
            {
                throw new ArgumentException("not valid id");
            }
        }

        public void SwitchOn(string name)
        {
            bool foundLamp = false;
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Name == name)
                {
                    lamp.SwitchOn();
                    foundLamp = true;
                }
            }
            if (foundLamp == false)
            {
                throw new ArgumentException("not valid name");
            }
        }

        public void SwitchOff()
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                lamp.SwitchOff();
            }
        }
        public void SwitchOff(Guid id)
        {
            bool foundLamp = false;
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Id == id)
                {
                    lamp.SwitchOff();
                    foundLamp = true;
                }
            }
            if (foundLamp == false)
            {
                throw new ArgumentException("not valid id");
            }
        }

        public void SwitchOff(string name)
        {
            bool foundLamp = false;
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Name == name)
                {
                    lamp.SwitchOff();
                    foundLamp = true;
                }
            }
            if (foundLamp == false)
            {
                throw new ArgumentException("not valid name");
            }
        }

        public void AddLamp(AbstractLamp lamp)
        {
            Lamps.Add(lamp);
        }

        public void AddLampInPosition(AbstractLamp lamp, int position)
        {

            while (Lamps.Count < LampValidator.IsPositionValid(position))
            {
                Lamps.Add(null);
            }

            Lamps.Insert(position, lamp);
            
        }

        public void RemoveLamp(Guid id)
        {
            bool foundLamp = false; 
            for (int i = 0; i < Lamps.Count; i++)
            {
                if(Lamps[i].Id == id)
                {
                    Lamps.RemoveAt(i);
                    foundLamp = true;
                }
            }

            if (foundLamp == false)
            {
                throw new ArgumentException("not valid id");
            }
        }

        public void RemoveLamp(string name)
        {
            bool foundLamp = false;
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i].Name == name)
                {
                    Lamps.RemoveAt(i);
                    foundLamp = true;
                }
            }

            if (foundLamp == false)
            {
                throw new ArgumentException("not valid name");
            }
        }

        public void RemoveInPosition(int position)
        {
            Lamps.RemoveAt(LampValidator.IsValueInMinMax(position, 0, Lamps.Count - 1));
        }

        public void SetIntensityForAllLamps(int newBrightness)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                lamp.SetBrightness(newBrightness);
            }
        }

        public void SetIntensityForLamp(Guid id, int intensity)
        {
            bool foundLamp = false;
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Id == id)
                {
                    lamp.SetBrightness(intensity);
                    foundLamp = true;
                }
            }

            if (foundLamp == false)
                throw new ArgumentException("not valid id");
        }

        public void SetIntensityForLamp(string name, int intensity)
        {
            bool foundLamp = false;
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Name == name)
                {
                    lamp.SetBrightness(intensity);
                    foundLamp = true;
                }
            }

            if (foundLamp == false)
                throw new ArgumentException("not valid id");
        }

        public AbstractLamp? FindLampWithMaxIntensity()
        {
            AbstractLamp? maxLamp;
            if (Lamps.Count == 0)
            {
                maxLamp = null;
            } else
            {
                maxLamp = Lamps[0];
                foreach (AbstractLamp lamp in Lamps)
                {
                    if (lamp.Brightness > maxLamp.Brightness)
                    {
                        maxLamp = lamp;
                    }
                }

            }
            return maxLamp;
        }

        

        public AbstractLamp? FindLampWithMinIntensity()
        {
            AbstractLamp? minLamp;
            if (Lamps.Count == 0)
            {
                minLamp = null;
            } else
            {
                minLamp = Lamps[0];
                foreach (AbstractLamp lamp in Lamps)
                {
                    if (lamp.Brightness < minLamp.Brightness)
                    {
                        minLamp = lamp;
                    }
                }
            }

            return minLamp;
        }

        public AbstractLamp? FindLampById(Guid id)
        {
            AbstractLamp? lampToFind = null;
            bool haveFoundedLamp = false;
            if (Lamps.Count == 0)
            {
                lampToFind = null;
                haveFoundedLamp = true;
            } else
            {
                foreach (AbstractLamp lamp in Lamps)
                {
                    if (lamp.Id == id)
                    {
                        lampToFind = lamp;
                        haveFoundedLamp = true; 
                    }
                }
            }
            if(haveFoundedLamp == false)
            {
                throw new ArgumentException("not valid id");
            }

            return lampToFind;
        }

        public List<AbstractLamp> FindLampsByIntensityRange(int min, int max)
        {
            List<AbstractLamp> lampsInIntensityRange = new List<AbstractLamp>();

            LampValidator.IsValueInMinMax(min, 0, 100);
            LampValidator.IsValueInMinMax(max, 0, 100);

            if(min >=  max || max <= min)            
                throw new ArgumentException("value cannot be equal, min cannot be greater than max and max cannot be smaller than min");
            

            foreach (AbstractLamp lamp in Lamps)
            {
                if(lamp.Brightness >= min &&  lamp.Brightness <= max)
                {
                    lampsInIntensityRange.Add(lamp);
                }
            }

            return lampsInIntensityRange;
        }

        public List<AbstractLamp> FindAllOn()
        {
            List<AbstractLamp> lampsOn = new List<AbstractLamp>();
            {
                foreach(AbstractLamp lamp in Lamps)
                {
                    if(lamp.Status == DeviceStatus.On)
                    {
                        lampsOn.Add(lamp);
                    }
                }
            }

            return lampsOn;
        }

        public List<AbstractLamp> FindAllOff()
        {
            List<AbstractLamp> lampsOff = new List<AbstractLamp>();
            {
                foreach (AbstractLamp lamp in Lamps)
                {
                    if (lamp.Status == DeviceStatus.Off)
                    {
                        lampsOff.Add(lamp);
                    }
                }
            }

            return lampsOff;
        }
    }
}

      

