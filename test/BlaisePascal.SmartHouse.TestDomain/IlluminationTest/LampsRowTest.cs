using BlaisePascal.SmartHouse.Domain;
using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.TestDomain
{
    public class LampsRowTest
    {
        LampsRow lampsRowToTest = new();

        [Fact]
        public void Constructor_IfOneLampIsOnLampsStatusIsOn() 
        {
            List<AbstractLamp> LampsList = new List<AbstractLamp>();
            LampsList.Add(new EcoLamp("led1"));
            LampsList.Add(new EcoLamp(50, "led2"));
            LampsRow lampsRowTest = new(LampsList);
            Assert.Equal(DeviceStatus.On, lampsRowTest.LampsStatus);
        }

        [Fact]
        public void Constructor_IfAllLampAreOfLampsStatusIsOff()
        {
            List<AbstractLamp> LampsList = new List<AbstractLamp>();
            LampsList.Add(new EcoLamp("led1"));
            LampsList.Add(new EcoLamp("led2"));
            LampsRow lampsRowTest = new(LampsList);
            Assert.Equal(DeviceStatus.Off, lampsRowTest.LampsStatus);
        }

        [Fact]
        public void Constructor_IfLampsRowIsEmptyListDeviceStatusIsNull()
        {
            List<AbstractLamp> LampsList = new List<AbstractLamp>();
            LampsRow lampsRowTest = new(LampsList);
            Assert.Null(lampsRowTest.LampsStatus);
        }

        [Fact]
        public void AddLamp_ALampIsAddedCorrectlyToLampsRow()
        {
            Lamp lamp = new Lamp("led1");
            lampsRowToTest.AddLamp(lamp);
            Assert.Equal(lamp, lampsRowToTest.Lamps[0]);
        }

        [Fact]
        public void AddLampInPosition_ALampIsAddedInADeterminatePosition()
        {
            EcoLamp ecoLamp = new("led2");
            lampsRowToTest.AddLampInPosition(ecoLamp, 3);
            Assert.Equal(ecoLamp, lampsRowToTest.Lamps[3]);
        }

        [Fact]
        public void AddLampInPosition_PositionCannotBeNegative()
        {
            EcoLamp ecoLamp = new("led2");
            Assert.Throws<ArgumentException>(() => lampsRowToTest.AddLampInPosition(ecoLamp, -3));
            
        }

        [Fact]
        public void SwitchOn_CannotSwitchOnWhenThemAreAlreadyOn()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<InvalidOperationException> (() => lampsRowToTest.SwitchOn());
        }

        [Fact]
        public void SwitchOn_AfterSwitchOnAllLampsSwitchOn()
        {
            Lamp lamp = new Lamp("led1");
            EcoLamp ecoLamp = new("led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.SwitchOn();
            Assert.Equal(DeviceStatus.On, lampsRowToTest.Lamps[0].Status);
            Assert.Equal(DeviceStatus.On, lampsRowToTest.Lamps[1].Status);
        }

        [Fact]
        public void SwitchOn_TheLampWithTheSelectedIdTurnOn()
        {
            Lamp lamp = new Lamp("led1");
            EcoLamp ecoLamp = new("led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.SwitchOn(lamp.Id);
            Assert.Equal(DeviceStatus.On, lampsRowToTest.Lamps[0].Status);
            Assert.Equal(DeviceStatus.Off, lampsRowToTest.Lamps[1].Status);
        }

        [Fact]
        public void SwitchOn_CannotTurnonTheLampIfTheIdIsWrong()
        {
            Lamp lamp = new Lamp("led1");
            EcoLamp ecoLamp = new("led2");
            Guid id = Guid.NewGuid();
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<ArgumentException>(() => lampsRowToTest.SwitchOn(id));
        }

        [Fact]
        public void SwitchOn_EvenTheIdIsRightCannotTurnOnTheLampIfItIsAlreadyOn()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<InvalidOperationException>(() => lampsRowToTest.SwitchOn(lamp.Id));
        }

        [Fact]
        public void SwitchOn_TheLampWithTheSelectedNameTurnOn()
        {
            Lamp lamp = new Lamp("led1");
            EcoLamp ecoLamp = new("led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.SwitchOn("led1");
            Assert.Equal(DeviceStatus.On, lampsRowToTest.Lamps[0].Status);
            Assert.Equal(DeviceStatus.Off, lampsRowToTest.Lamps[1].Status);
        }

        [Fact]
        public void SwitchOn_CannotTurnOnTheLampIfTheNameIsWrong()
        {
            Lamp lamp = new Lamp("led1");
            EcoLamp ecoLamp = new("led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<ArgumentException>(() => lampsRowToTest.SwitchOn("gino"));
        }

        [Fact]
        public void SwitchOn_EvenTheNameIsRightCannotTurnOnTheLampIfItIsAlreadyOn()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<InvalidOperationException>(() => lampsRowToTest.SwitchOn("led1"));
        }

        [Fact]
        public void SwitchOff_CannotSwitchOffWhenThemAreAlreadyOff()
        {
            Lamp lamp = new Lamp("led1");
            EcoLamp ecoLamp = new("led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<InvalidOperationException>(() => lampsRowToTest.SwitchOff());
        }

        [Fact]
        public void SwitchOff_AfterSwitchOffAllLampsSwitchOff()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.SwitchOff();
            Assert.Equal(DeviceStatus.Off, lampsRowToTest.Lamps[0].Status);
            Assert.Equal(DeviceStatus.Off, lampsRowToTest.Lamps[1].Status);
        }

        [Fact]
        public void SwitchOff_TheLampWithTheSelectedIdTurnOff()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.SwitchOff(lamp.Id);
            Assert.Equal(DeviceStatus.Off, lampsRowToTest.Lamps[0].Status);
            Assert.Equal(DeviceStatus.On, lampsRowToTest.Lamps[1].Status);
        }

        [Fact]
        public void SwitchOff_CannotTurnOffTheLampIfTheIdIsWrong()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            Guid id = Guid.NewGuid();
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<ArgumentException>(() => lampsRowToTest.SwitchOff(id));
        }

        [Fact]
        public void SwitchOff_EvenTheIdIsRightCannotTurnOffTheLampIfItIsAlreadyOff()
        {
            Lamp lamp = new Lamp("led1");
            EcoLamp ecoLamp = new("led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<InvalidOperationException>(() => lampsRowToTest.SwitchOff(lamp.Id));
        }

        [Fact]
        public void SwitchOff_TheLampWithTheSelectedNameTurnOff()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.SwitchOff("led1");
            Assert.Equal(DeviceStatus.Off, lampsRowToTest.Lamps[0].Status);
            Assert.Equal(DeviceStatus.On, lampsRowToTest.Lamps[1].Status);
        }

        [Fact]
        public void SwitchOff_CannotTurnOffTheLampIfTheNameIsWrong()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<ArgumentException>(() => lampsRowToTest.SwitchOff("gino"));
        }

        [Fact]
        public void SwitchOff_EvenTheNameIsRightCannotTurnOffTheLampIfItIsAlreadyOff()
        {
            Lamp lamp = new Lamp("led1");
            EcoLamp ecoLamp = new("led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<InvalidOperationException>(() => lampsRowToTest.SwitchOff("led1"));
        }

        [Fact]
        public void RemoveLamp_WhenTheIdIsRightTheLampIsRemovedCorrectly()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.RemoveLamp(lamp.Id);
            Assert.Equal(ecoLamp, lampsRowToTest.Lamps[0]);
        }

        [Fact]
        public void RemoveLamp_CannotRemoveTheLampWhenTheIdIsWrong()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            Guid id = Guid.NewGuid();
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<ArgumentException>(() => lampsRowToTest.RemoveLamp(id));
        }

        [Fact]
        public void RemoveLamp_WhenTheNameIsRightTheLampIsRemovedCorrectly()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.RemoveLamp("led1");
            Assert.Equal(ecoLamp, lampsRowToTest.Lamps[0]);
        }

        [Fact]
        public void RemoveLamp_CannotRemoveTheLampWhenTheNameIsWrong()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            Assert.Throws<ArgumentException>(() => lampsRowToTest.RemoveLamp("genoveffa"));
        }

        [Fact]
        public void RemoveLamp_WhenThePositionInRightThelampIsRemovedCorrectly()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.RemoveInPosition(1);
            Assert.Equal(lamp, lampsRowToTest.Lamps[0]);
        }

        [Fact]
        public void RemoveLamp_CannotRemoveLampWhenThePositionIsNegative()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<ArgumentException> (() => lampsRowToTest.RemoveInPosition(-1));
        }

        [Fact]
        public void RemoveLamp_CannotRemoveLampWhenThePositionGreaterThanLampsSize()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<ArgumentException>(() => lampsRowToTest.RemoveInPosition(4));
        }

        [Fact]
        public void SetIntensityForAllLamps_WhenNewBrightnessIsSmallerThanMinValueIsSetOnMinValue() 
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.SetIntensityForAllLamps(-1);
            Assert.Equal(0, lamp.Brightness);
            Assert.Equal(0, ecoLamp.Brightness);
        }

        [Fact]
        public void SetIntensityForAllLamps_WhenNewBrightnessIsGreaterThenMaxValueIsSetOnMaxValue()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.SetIntensityForAllLamps(101);
            Assert.Equal(100, lamp.Brightness);
            Assert.Equal(100, ecoLamp.Brightness);
        }

        [Fact]
        public void SetIntensityFroAllLamps_CannotChangeIntensityWhenEvenOneLampIsOff()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new("led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<InvalidOperationException> (() => lampsRowToTest.SetIntensityForAllLamps(50));
        }

        [Fact]
        public void SetIntensityForAllLamps_WhenTheLampsAreOnAndBrightnessIsRightTheBrightnessIsSetCorrectly()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.SetIntensityForAllLamps(10);
            Assert.Equal(10, lamp.Brightness);
            Assert.Equal(10, ecoLamp.Brightness);
        }

        [Fact]
        public void SetIntensityForLamp_CannotSetIntensityWhenLampIsOffAndIdIsRight()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new EcoLamp("led2");            
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<InvalidOperationException>(() => lampsRowToTest.SetIntensityForLamp(ecoLamp.Id, 40));
        }

        [Fact]
        public void SetIntensityForLamp_WHenIntensityIsSmallerThanMinValueIsSetOnMinValue()
        {
            Lamp lamp = new Lamp(50, "led1p_WhenIntensit");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.SetIntensityForLamp(lamp.Id, -1);
            Assert.Equal(0, lamp.Brightness);
        }

        [Fact]
        public void SetIntensityForLamp_WhenIntensityIsGreaterThanMaxValueIsSetOnMaxValue()
        {
            
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.SetIntensityForLamp(ecoLamp.Id, 101);
            Assert.Equal(100, ecoLamp.Brightness);
        }

        [Fact]
        public void SetIntensityForLamp_CannotSetInstensityWhenIdIsWrong()
        {
            Guid id = Guid.NewGuid();
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<ArgumentException>(() => lampsRowToTest.SetIntensityForLamp(id, 40));
        }

        [Fact]
        public void SetIntensityForLamp_WhenLampIsOnAndIdIsRightBrightnessIsSetCorrectly()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.SetIntensityForLamp(ecoLamp.Id, 10);
            Assert.Equal(10, ecoLamp.Brightness);
        }

        [Fact]
        public void SetIntensityForLamp_CannotSetIntensityWhenLampIsOffAndNameIsRight()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new EcoLamp("led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<InvalidOperationException>(() => lampsRowToTest.SetIntensityForLamp("led2", 40));
        }

        [Fact]
        public void SetIntensityForLamp_IfIntensityIsSmallerThanMinValueIsSetOnMinValue()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.SetIntensityForLamp("led1", -1);
            Assert.Equal(0, lamp.Brightness);
        }

        [Fact]
        public void SetIntensityForLamp_IfIntensityIsGreaterThanMaxValueIsSetOnMaxValue()
        {

            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.SetIntensityForLamp("led2", 101);
            Assert.Equal(100, ecoLamp.Brightness);
        }

        [Fact]
        public void SetIntensityForLamp_CannotSetInstensityWhenNameIsWrong()
        {
            Guid id = Guid.NewGuid();
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<ArgumentException>(() => lampsRowToTest.SetIntensityForLamp("paolo", 40));
        }

        [Fact]
        public void SetIntensityForLamp_WhenLampIsOnAndNameIsRightBrightnessIsSetCorrectly()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            lampsRowToTest.SetIntensityForLamp("led2", 10);
            Assert.Equal(10, ecoLamp.Brightness);
        }

        [Fact]
        public void FindLampWithMaxIntensity_WhenLampsRowIsNullTherIsNotAMaxIntensityLamp()
        {
            Assert.Null(lampsRowToTest.FindLampWithMaxIntensity());
        }

        [Fact]
        public void FindLampWithMaxIntensity_FindTheMaxIntesityLampCorrectly()
        {
            Lamp lamp = new Lamp(0, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);            
            Assert.Equal(ecoLamp, lampsRowToTest.FindLampWithMaxIntensity());
        }

        [Fact]
        public void FindLampWithMaxIntesity_WhenTwoLampsHaveSameIntensityReturnTheFirst()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Equal(lamp, lampsRowToTest.FindLampWithMaxIntensity());
        }


        [Fact]
        public void FindLampWithMinIntensity_WhenLampsRowIsNullTherIsNotAMinIntensityLamp()
        {
            
            Assert.Null(lampsRowToTest.FindLampWithMinIntensity());
        }

        [Fact]
        public void FindLampWithMinIntensity_FindTheMinIntesityLampCorrectly()
        {
            Lamp lamp = new Lamp(0, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Equal(lamp, lampsRowToTest.FindLampWithMinIntensity());
        }

        [Fact]
        public void FindLampWithMinIntesity_WhenTwoLampsHaveSameIntensityReturnTheFirst()
        {
            Lamp lamp = new Lamp(50, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Equal(lamp, lampsRowToTest.FindLampWithMinIntensity());
        }

        [Fact]
        public void FindLampById_WhenLampsRowIsEmptyReturnNull()
        {
            Guid id = Guid.NewGuid();   
            Assert.Null(lampsRowToTest.FindLampById(id));
        }

        [Fact] 
        public void FindLampById_CannotReturnLampWhenIdIsWrong()
        {
            Guid id = Guid.NewGuid();
            Lamp lamp = new Lamp(0, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<ArgumentException>(() => lampsRowToTest.FindLampById(id));
        }

        [Fact]
        public void FindLampById_WhenIdIsCorrectTheLampIsReturn()
        {
            Lamp lamp = new Lamp(0, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Equal(lamp, lampsRowToTest.FindLampById(lamp.Id));
        }

        [Fact]
        public void FindLampsByIntensityRange_MinCannotBeNegative()
        {
            Lamp lamp = new Lamp(0, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<ArgumentException>(() => lampsRowToTest.FindLampsByIntensityRange(-2, 5));
        }

        [Fact]
        public void FindLampsByIntensityRange_MaxCannotBeNegative()
        {
            Lamp lamp = new Lamp(0, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<ArgumentException>(() => lampsRowToTest.FindLampsByIntensityRange(2, -5));
        }

        [Fact]
        public void FindLampsByIntensityRange_MinCannotGreaterThanMaxAndMaxCannotBelowerThanMin() 
        {
            Lamp lamp = new Lamp(0, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<ArgumentException>(() => lampsRowToTest.FindLampsByIntensityRange(5, 2));
        }

        [Fact]
        public void FindLampsByIntensityRange_MaxAndMinCannotBeEqual()
        {
            Lamp lamp = new Lamp(0, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            Assert.Throws<ArgumentException>(() => lampsRowToTest.FindLampsByIntensityRange(2, 2));
        }

        [Fact]
        public void FindLampsByIntensityRange_WhenMaxAndMinAreRightTheLampsAreCorrectlyReturn()
        {
            Lamp lamp = new Lamp(0, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            List<AbstractLamp> lamps = new();
            lamps.Add(lamp);
            Assert.Equal(lamps, lampsRowToTest.FindLampsByIntensityRange(0, 20));
        }

       [Fact]
       public void FindAllOn_ReturnTheLampsOn()
       {
            Lamp lamp = new Lamp(0, "led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            List<AbstractLamp> lamps = new();
            lamps.Add(lamp);
            lamps.Add(ecoLamp);
            Assert.Equal(lamps, lampsRowToTest.FindAllOn());
       }

        [Fact]
        public void FindAllOn_ReturnTheLampsOff()
        {
            Lamp lamp = new Lamp("led1");
            EcoLamp ecoLamp = new(50, "led2");
            lampsRowToTest.AddLamp(lamp);
            lampsRowToTest.AddLamp(ecoLamp);
            List<AbstractLamp> lamps = new();
            lamps.Add(lamp);
            Assert.Equal(lamps, lampsRowToTest.FindAllOff());
        }








    }





















    
}
