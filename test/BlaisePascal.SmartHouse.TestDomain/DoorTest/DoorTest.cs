using BlaisePascal.SmartHouse.Domain;
using BlaisePascal.SmartHouse.Domain.Door;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.TestDomain.DoorTest
{
    public class DoorTest
    {
        [Fact]
        public void OpenDoor_CannotOpenTheDoorWhenDeviceIsOff()
        {
            Door door = new("pietro", "gozzi");
            Assert.Throws<InvalidOperationException>(() => door.OpenDoor());
        }

        [Fact]
        public void OpenDoor_WhenDoorIsClosedCanOpenTheDoor()
        {
            Door door = new("pietro", "gozzi");
            door.SwitchOn();
            door.OpenDoor();
            Assert.Equal(DoorStatus.Open, door.DoorStatus);
        }

        [Fact]
        public void OpenDoor_CannotOpenTheDoorIfItIsLocked()
        {
            Door door = new("porta", "1234");
            door.SwitchOn();
            door.LockDoor();
            Assert.Throws<InvalidOperationException>(() => door.OpenDoor());
        }

        [Fact]
        public void OpenDoor_CannotOpenTheDoorIfItIsAlreadyOpened()
        {
            Door door = new("porta", "1234");
            door.SwitchOn();
            door.OpenDoor();
            Assert.Throws<InvalidOperationException>(() => door.OpenDoor());
        }

        [Fact]
        public void CloseDoor_CannotCloseWhenDeviceIsOff()
        {
            Door door = new("porta", "1234");
            Assert.Throws<InvalidOperationException>(() => door.CloseDoor());
        }

        [Fact]
        public void CloseDoor_WhenTheDoorIsOpenCanCloseTheDoor()
        {
            Door door = new("porta", "1234");
            door.SwitchOn();
            door.OpenDoor();
            door.CloseDoor();
            Assert.Equal(DoorStatus.Closed, door.DoorStatus);
        }

        [Fact]
        public void CloseDoor_DoorCannotBeALreadyClosed()
        {
            Door door = new("porta", "1234");
            Assert.Throws<InvalidOperationException>(() => door.CloseDoor());
        }

        [Fact]
        public void CLoseDoor_CannotCloseTheDoorWhenItIsLocked()
        {
            Door door = new("porta", "1234");
            door.SwitchOn();
            door.LockDoor();
            Assert.Throws<InvalidOperationException>(() => door.CloseDoor());
        }

        [Fact]
        public void LockDoor_CannotLockWhenDeviceIsOff()
        {
            Door door = new("porta", "1234");
            Assert.Throws<InvalidOperationException>(() => door.LockDoor());
        }
        [Fact]
        public void LockDoor_WhenDoorIsClosedCanLockDoor() 
        {
            Door door = new("porta", "1234");
            door.SwitchOn();
            door.LockDoor();
            Assert.Equal(DoorStatus.Locked, door.DoorStatus);
        }

        [Fact]
        public void LockDoor_CannotLockDoorIfItIsAlreadyLocked()
        {
            Door door = new("porta", "1234");
            door.SwitchOn();
            door.LockDoor();
            Assert.Throws<InvalidOperationException>(() => door.LockDoor());
        }

        [Fact]
        public void LockDoor_DoorCannotBeOpened()
        {
            Door door = new("porta", "1234");
            door.SwitchOn();
            door.OpenDoor();
            Assert.Throws<InvalidOperationException>(() => door.LockDoor());
        }

        [Fact]
        public void UnlockDoor_CannotUnlockDoorWhenDeviceIsOff()
        {
            Door door = new("porta", "1234");
            Assert.Throws<InvalidOperationException>(() => door.UnlockDoor("1234"));
        }

        [Fact]
        public void UnlockDoor_CannotUnlockDoorWhenPasswordIsWrong()
        {
            Door door = new("porta", "1234");
            door.SwitchOn();
            door.LockDoor();
            Assert.Throws<ArgumentException>(() => door.UnlockDoor("564"));
        }
        [Fact]
        public void UnlockDoor_WhenThePasswordIsRightCanUnlockeTheDoor()
        {
            Door door = new("porta", "1234");
            door.SwitchOn();
            door.LockDoor();
            door.UnlockDoor("1234");
            Assert.Equal(DoorStatus.Closed, door.DoorStatus);
        }

        [Fact]
        public void UnlockDoor_CannotUnlockDoorIfItIsAlreadyUnlocked()
        {
            Door door = new("porta", "1234");
            door.SwitchOn();
            door.LockDoor();
            door.UnlockDoor("1234");
            Assert.Throws<InvalidOperationException>(() => door.UnlockDoor("1234"));
        }

        [Fact]
        public void UnlockDoor_DoorCannotBeOpened()
        {
            Door door = new("porta", "1234");
            door.SwitchOn();
            door.OpenDoor();
            Assert.Throws<InvalidOperationException>(() => door.UnlockDoor("1234"));
        }
    }
}
