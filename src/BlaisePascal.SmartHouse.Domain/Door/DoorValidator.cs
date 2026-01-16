using BlaisePascal.SmartHouse.Domain.Asbtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Door
{
    public static class DoorValidator
    {
        public static void CheckIsOn(DeviceStatus status)
        {
            if (status != DeviceStatus.On)
                throw new InvalidOperationException("Cannot modify the door when device is off");
        }

        public static void CanOpen(DoorStatus doorStatus)
        {
            if (doorStatus != DoorStatus.Closed)
                throw new InvalidOperationException("The door must be closed");
        }

        public static void CanClose(DoorStatus doorStatus)
        {
            if (doorStatus != DoorStatus.Open)
                throw new InvalidOperationException("The door must be open");
        }

        public static void CanLock(DoorStatus doorStatus)
        {
            CanOpen(doorStatus);
        }

        public static void IsPasswordRight(string rightPassword, string password)
        {
            if (!(password.Equals(rightPassword)))
                throw new ArgumentException("the password is wrong");
        }

        public static void CanUnlock(DoorStatus doorStatus)
        {
            if (doorStatus != DoorStatus.Locked)
                throw new InvalidOperationException("The door must be locekd");
        }
    }
}
