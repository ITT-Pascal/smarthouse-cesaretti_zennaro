using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Door;
using BlaisePascal.SmartHouse.Domain.Devices.Door.ValueObjects;

namespace BlaisePascal.SmartHouse.TestDomain.DoorTest
{
    public class DoorTest
    {
        [Fact]
        public void OpenDoor_CannotOpenTheDoorWhenDeviceIsOff()
        {
            Door door = new(Name.CreateNew("pietro"), Password.CreateNew("gozzi"));
            door.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => door.Open());
        }

        [Fact]
        public void OpenDoor_WhenDoorIsClosedCanOpenTheDoor()
        {
            Door door = new(Name.CreateNew("pietro"), Password.CreateNew("gozzi"));
            door.Open();
            Assert.Equal(DoorStatus.Open, door.DoorStatus);
        }

        [Fact]
        public void OpenDoor_CannotOpenTheDoorIfItIsLocked()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            door.Lock();
            Assert.Throws<InvalidOperationException>(() => door.Open());
        }

        [Fact]
        public void OpenDoor_CannotOpenTheDoorIfItIsAlreadyOpened()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            door.Open();
            Assert.Throws<InvalidOperationException>(() => door.Open());
        }

        [Fact]
        public void CloseDoor_CannotCloseWhenDeviceIsOff()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            Assert.Throws<InvalidOperationException>(() => door.Close());
        }

        [Fact]
        public void CloseDoor_WhenTheDoorIsOpenCanCloseTheDoor()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            door.Open();
            door.Close();
            Assert.Equal(DoorStatus.Closed, door.DoorStatus);
        }

        [Fact]
        public void CloseDoor_DoorCannotBeALreadyClosed()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            Assert.Throws<InvalidOperationException>(() => door.Close());
        }

        [Fact]
        public void CLoseDoor_CannotCloseTheDoorWhenItIsLocked()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            door.Lock();
            Assert.Throws<InvalidOperationException>(() => door.Close());
        }

        [Fact]
        public void LockDoor_CannotLockWhenDeviceIsOff()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            door.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => door.Lock());
        }
        [Fact]
        public void LockDoor_WhenDoorIsClosedCanLockDoor()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            door.Lock();
            Assert.Equal(DoorStatus.Locked, door.DoorStatus);
        }

        [Fact]
        public void LockDoor_CannotLockDoorIfItIsAlreadyLocked()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            door.Lock();
            Assert.Throws<InvalidOperationException>(() => door.Lock());
        }

        [Fact]
        public void LockDoor_CannotLockWhenDoorIsOpen()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            door.Open();
            Assert.Throws<InvalidOperationException>(() => door.Lock());
        }

        [Fact]
        public void UnlockDoor_CannotUnlockDoorWhenDeviceIsOff()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            Assert.Throws<InvalidOperationException>(() => door.Unlock(Password.CreateNew("1234")));
        }

        [Fact]
        public void UnlockDoor_CannotUnlockDoorWhenPasswordIsWrong()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            door.Lock();
            Assert.Throws<ArgumentException>(() => door.Unlock(Password.CreateNew("564")));
        }
        [Fact]
        public void UnlockDoor_WhenThePasswordIsRightCanUnlockTheDoor()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            door.Lock();
            door.Unlock(Password.CreateNew("1234"));
            Assert.Equal(DoorStatus.Closed, door.DoorStatus);
        }

        [Fact]
        public void UnlockDoor_CannotUnlockDoorIfItIsAlreadyUnlocked()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            door.Lock();
            door.Unlock(Password.CreateNew("1234"));
            Assert.Throws<InvalidOperationException>(() => door.Unlock(Password.CreateNew("1234")));
        }

        [Fact]
        public void UnlockDoor_CannotUnlockWhenDoorIsOpen()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            door.Open();
            Assert.Throws<InvalidOperationException>(() => door.Unlock(Password.CreateNew("1234")));
        }

        [Fact]
        public void ChangePassword_CannotChangePasswordWhenDeviceIsOff()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            door.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => door.ChangePassword(Password.CreateNew("1234"), Password.CreateNew("5678")));
        }

        [Fact]
        public void ChangePassword_CannotChangePasswordWhenOldPasswordIsWrong()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            Assert.Throws<ArgumentException>(() => door.ChangePassword(Password.CreateNew("564"), Password.CreateNew("5678")));
        }

        [Fact]
        public void ChangePassword_WhenOldPasswordIsRightPasswordIsChangedCorrectly()
        {
            Door door = new(Name.CreateNew("porta"), Password.CreateNew("1234"));
            door.ChangePassword(Password.CreateNew("1234"), Password.CreateNew("5678"));
            Assert.Equal(Password.CreateNew("5678"), door.Password);
        }
    }
}
