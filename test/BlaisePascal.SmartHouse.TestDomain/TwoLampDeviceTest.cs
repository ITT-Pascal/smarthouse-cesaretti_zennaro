using BlaisePascal.SmartHouse.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.TestDomain
{
    public class TwoLampDeviceTest
    {
        [Fact]
        public void Constructor_AfterCreationTheFirstAndTheSecondLampAreSet()
        {
            StandardLamp lamp = new StandardLamp(50);
            EcoLamp ecoLamp = new EcoLamp(30);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            Assert.Equal(lamp, twoLampDevice.Lamps[1]);
            Assert.Equal(ecoLamp, twoLampDevice.Lamps[2]);
        }

        [Fact]
        public void TurnOnLamps_WhenBothLampAreOffAfterTurnOnLampsThemWillTurnOn()
        {
            StandardLamp lamp = new StandardLamp();
            EcoLamp ecoLamp = new EcoLamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            twoLampDevice.TurnLampsOn();
            Assert.True(twoLampDevice.Lamps[1].IsOn);
            Assert.True(twoLampDevice.Lamps[2].IsOn);
        }

        [Fact]
        public void TurnOnLamps_WhenBothLampAreAlreadyOnAfterTurnOnLampsNothingChanges()
        {
            StandardLamp lamp = new StandardLamp(30);
            EcoLamp ecoLamp = new EcoLamp(20);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            twoLampDevice.TurnLampsOn();
            Assert.True(twoLampDevice.Lamps[1].IsOn);
            Assert.True(twoLampDevice.Lamps[2].IsOn);
        }

        [Fact]
        public void TurnOffLamps_WhenBothLampAreOnAfterTurnOnLampsThemWillTurnOff()
        {
            StandardLamp lamp = new StandardLamp(20);
            EcoLamp ecoLamp = new EcoLamp(30);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            twoLampDevice.TurnLampsOff();
            Assert.False(twoLampDevice.Lamps[1].IsOn);
            Assert.False(twoLampDevice.Lamps[2].IsOn);
        }

        [Fact]
        public void TurnOffLamps_WhenBothLampAreAlreadyOffAfterTurnOnLampsNothingChanges()
        {
            StandardLamp lamp = new StandardLamp();
            EcoLamp ecoLamp = new EcoLamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            twoLampDevice.TurnLampsOff();
            Assert.False(twoLampDevice.Lamps[1].IsOn);
            Assert.False(twoLampDevice.Lamps[2].IsOn);
        }

        [Fact]
        public void SwitchLamp_LampNumberCannotBeLowerThan1()
        {
            StandardLamp lamp = new StandardLamp();
            EcoLamp ecoLamp = new EcoLamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            Assert.Throws<ArgumentException>(() => twoLampDevice.SwitchLamp(0));
        }

        [Fact]
        public void SwitchLamp_LampNumberCannotBeGreaterThanTwoLampDeviceLenght()
        {
            StandardLamp lamp = new StandardLamp();
            EcoLamp ecoLamp = new EcoLamp();
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            Assert.Throws<ArgumentException>(() => twoLampDevice.SwitchLamp(9));
        }

        [Fact]
        public void SwitchLamp_WhenLampNumberIs1TheFirstLampWillChangeHisState()
        {
            StandardLamp lamp = new StandardLamp();
            EcoLamp ecoLamp = new EcoLamp(30);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            twoLampDevice.SwitchLamp(1);
            Assert.True(twoLampDevice.Lamps[1].IsOn);
        }

        [Fact]
        public void SwitchLamp_WhenLampNumberIs2TheSecondLampWillChangeHisState()
        {
            StandardLamp lamp = new StandardLamp(10);
            EcoLamp ecoLamp = new EcoLamp(30);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            twoLampDevice.SwitchLamp(2);
            Assert.False(twoLampDevice.Lamps[2].IsOn);
        }

        [Fact]
        public void ChangeLampBrightness_LampNumberCannotBeLowerThan0()
        {
            StandardLamp lamp = new StandardLamp(10);
            EcoLamp ecoLamp = new EcoLamp(20);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            Assert.Throws<ArgumentException>(() => twoLampDevice.ChangeLampBrightness(0, 10));
        }

        [Fact]
        public void ChangeLampBrightness_LampNumberCannotBeGreaterThanTwoLampsDeviceLenght()
        {
            StandardLamp lamp = new StandardLamp(10);
            EcoLamp ecoLamp = new EcoLamp(20);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            Assert.Throws<ArgumentException>(() => twoLampDevice.ChangeLampBrightness(3, 10));
        }

        [Fact]
        public void ChangeLampBrightness_WhenTheFirstLampIsOnTheBrightnessWillBeSetCorrectlyInTheCorrectLamp()
        {
            StandardLamp lamp = new StandardLamp(10);
            EcoLamp ecoLamp = new EcoLamp(30);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            twoLampDevice.ChangeLampBrightness(1, 20);
            Assert.Equal(20, twoLampDevice.Lamps[1].BrightnessPercentage);
            Assert.Equal(30, twoLampDevice.Lamps[2].BrightnessPercentage);
        }

        [Fact]
        public void ChangeLampBrightness_WhenTheSecondLampIsOnTheBrightnessWillBeSetCorrectlyInTheCorrectLamp()
        {
            StandardLamp lamp = new StandardLamp(10);
            EcoLamp ecoLamp = new EcoLamp(30);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            twoLampDevice.ChangeLampBrightness(2, 20);
            Assert.Equal(10, twoLampDevice.Lamps[1].BrightnessPercentage);
            Assert.Equal(20, twoLampDevice.Lamps[2].BrightnessPercentage);
        }

        [Fact]
        public void ChangeBothLampsBrightness_WhenBothLampsAreOnTheBrightnessIsSetCorrectlyInBothLamp()
        {
            StandardLamp lamp = new StandardLamp(10);
            EcoLamp ecoLamp = new EcoLamp(30);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            twoLampDevice.ChangeBothLampsBrightness(20);
            Assert.Equal(20, twoLampDevice.Lamps[1].BrightnessPercentage);
            Assert.Equal(20, twoLampDevice.Lamps[2].BrightnessPercentage);
        }

        [Fact]
        public void IncreaseLampBrightness_LampNumberCannotBeLowerThan0()
        {
            StandardLamp lamp = new StandardLamp(10);
            EcoLamp ecoLamp = new EcoLamp(20);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            Assert.Throws<ArgumentException>(() => twoLampDevice.IncreaseLampBrightness(0, 10));
        }

        [Fact]
        public void IncreaseLampBrightness_LampNumberCannotBeGreaterThanTwoLampsDeviceLenght()
        {
            StandardLamp lamp = new StandardLamp(10);
            EcoLamp ecoLamp = new EcoLamp(20);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            Assert.Throws<ArgumentException>(() => twoLampDevice.IncreaseLampBrightness(3, 10));
        }

        [Fact]
        public void IncreaseLampBrightness_WhenTheFirstLampIsOnItIncreaseCorrectlyTheBrightnessPercentage()
        {
            StandardLamp lamp = new StandardLamp(10);
            EcoLamp ecoLamp = new EcoLamp(20);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            twoLampDevice.IncreaseLampBrightness(1, 10);
            Assert.Equal(20, twoLampDevice.Lamps[1].BrightnessPercentage);
        }

        [Fact]
        public void IncreaseLampBrightness_WhenTheSecondLampIsOnItIncreaseCorrectlyTheBrightnessPercentage()
        {
            StandardLamp lamp = new StandardLamp(10);
            EcoLamp ecoLamp = new EcoLamp(20);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            twoLampDevice.IncreaseLampBrightness(2, 10);
            Assert.Equal(30, twoLampDevice.Lamps[2].BrightnessPercentage);
        }

        [Fact]
        public void DecreaseLampBrightness_LampNumberCannotBeLowerThan0()
        {
            StandardLamp lamp = new StandardLamp(10);
            EcoLamp ecoLamp = new EcoLamp(20);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            Assert.Throws<ArgumentException>(() => twoLampDevice.DecreaseLampBrightness(0, 10));
        }

        [Fact]
        public void DecreaseLampBrightness_LampNumberCannotBeGreaterThanTwoLampsDeviceLenght()
        {
            StandardLamp lamp = new StandardLamp(10);
            EcoLamp ecoLamp = new EcoLamp(20);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            Assert.Throws<ArgumentException>(() => twoLampDevice.DecreaseLampBrightness(3, 10));
        }
        [Fact]
        public void DecreaseLampBrightness_WhenTheFirstLampIsOnItDecreaseCorrectlyTheBrightnessPercentage()
        {
            StandardLamp lamp = new StandardLamp(10);
            EcoLamp ecoLamp = new EcoLamp(20);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            twoLampDevice.DecreaseLampBrightness(1, 10);
            Assert.Equal(0, twoLampDevice.Lamps[1].BrightnessPercentage);
        }

        [Fact]
        public void DecreaseLampBrightness_WhenTheSecondLampIsOnItDecreaseCorrectlyTheBrightnessPercentage()
        {
            StandardLamp lamp = new StandardLamp(10);
            EcoLamp ecoLamp = new EcoLamp(20);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            twoLampDevice.DecreaseLampBrightness(2, 10);
            Assert.Equal(10, twoLampDevice.Lamps[2].BrightnessPercentage);
        }

        [Fact]
        public void IncreaseBothLampsBrightness_WhenBothLampsAreOnThemIncreaseCorretlyTheirBrightnessPercentage()
        {
            StandardLamp lamp = new StandardLamp(10);
            EcoLamp ecoLamp = new EcoLamp(20);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            twoLampDevice.IncreaseBothLampsBrightness(10);
            Assert.Equal(20, twoLampDevice.Lamps[1].BrightnessPercentage);
            Assert.Equal(30, twoLampDevice.Lamps[2].BrightnessPercentage);
        }

        [Fact]
        public void DecreaseBothLampsBrightness_WhenBothLampsAreOnThemIncreaseCorretlyTheirBrightnessPercentage()
        {
            StandardLamp lamp = new StandardLamp(10);
            EcoLamp ecoLamp = new EcoLamp(20);
            TwoLampDevice twoLampDevice = new TwoLampDevice(lamp, ecoLamp);
            twoLampDevice.DecreaseBothLampsBrightness(10);
            Assert.Equal(0, twoLampDevice.Lamps[1].BrightnessPercentage);
            Assert.Equal(10, twoLampDevice.Lamps[2].BrightnessPercentage);
        }






























    }
}
