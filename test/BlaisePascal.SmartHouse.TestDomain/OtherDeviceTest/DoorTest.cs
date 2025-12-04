using BlaisePascal.SmartHouse.Domain;
using BlaisePascal.SmartHouse.Domain.ObjectStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.TestDomain.OtherDeviceTest
{
    public class DoorTest
    {
      
        [Fact]  
        public void OpenDoor_WhenTheDoorIsClosedAndUnlockedItOpenTheDoor()
        {
            Door door = new("porta", "1234");
            door.OpenDoor();
            Assert.Equal(DoorStatus.Open, door.Status);
        }
        [Fact]
        public void OpenDoor_DoorCannotBeAlreadyOpen()
        {
            Door door = new("porta", "1234");
            door.OpenDoor();
            Assert.Throws<InvalidOperationException> (() => door.OpenDoor());
        }

        [Fact]
        public void OpenDoor_DoorCannotBeLocked()
        {
            Door door = new("porta", "1234");
            door.LockDoor("1234");
            Assert.Throws<InvalidOperationException>(() => door.OpenDoor());
        }

        [Fact]
        public void CloseDoor_WhenTheDoorIsOpenItCloseTheDoor()
        {
            Door door = new("porta", "1234");
            door.OpenDoor();
            door.CloseDoor();
            Assert.Equal(DoorStatus.Closed, door.Status);
        }

        [Fact]
        public void CloseDoor_DoorCannotBeALreadyClosed()
        {
            Door door = new("porta", "1234");
            Assert.Throws<InvalidOperationException>(() => door.CloseDoor());
        }

        [Fact]
        public void CLoseDoor_DoorCannotBeLocked()
        {
            Door door = new("porta", "1234");
            door.LockDoor("1234");
            Assert.Throws<InvalidOperationException>(() => door.CloseDoor());
        }

        [Fact]
        public void LockDoor_WhenDoorIsCloseAndUnlockedItLockedTheDoor()
        {
            Door door = new("porta", "1234");
            door.LockDoor("1234");
            Assert.Equal(DoorStatus.Locked, door.Status);
        }

        [Fact]
        public void LockDoor_WhenThePasswordIsWrongTheDoorDoNotLock()
        {
            Door door = new("porta", "1234");
            Assert.Throws<ArgumentException>(() => door.LockDoor("34"));
        }

        [Fact]
        public void LockDoor_TheDoorCannotBeAlreadyLocked()
        {
            Door door = new("porta", "1234");
            door.LockDoor("1234");
            Assert.Throws<InvalidOperationException>(() => door.LockDoor("1234"));
        }

        [Fact]
        public void LockDoor_DoorCannotBeOpen()
        {
            Door door = new("porta", "1234");
            door.OpenDoor();
            Assert.Throws<InvalidOperationException>(() => door.LockDoor("1234"));
        }

        [Fact]
        public void UnlockDoor_WhenThePasswordIsRightUnlockedTheDoor()
        {
            Door door = new("porta", "1234");
            door.LockDoor("1234");
            door.UnlockDoor("1234");
            Assert.Equal(DoorStatus.Closed, door.Status);
        }

        [Fact]
        public void UnlockDoor_WhenThePasswordIsWrongTheDoorDoNotUnlock()
        {
            Door door = new("porta", "1234");
            Assert.Throws<ArgumentException>(() => door.UnlockDoor("34"));
        }


        [Fact]
        public void UnlockDoor_TheDoorCannotBeAlreadyUnlocked()
        {
            Door door = new("porta", "1234");
            door.LockDoor("1234");
            door.UnlockDoor("1234");
            Assert.Throws<InvalidOperationException>(() => door.UnlockDoor("1234"));
        }

        [Fact]
        public void UnlockDoor_DoorCannotBeOpen()
        {
            Door door = new("porta", "1234");
            door.OpenDoor();
            Assert.Throws<InvalidOperationException>(() => door.UnlockDoor("1234"));
        }


    }
}
