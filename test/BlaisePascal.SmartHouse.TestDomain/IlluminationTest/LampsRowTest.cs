using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.LuminuosDevices;


namespace BlaisePascal.SmartHouse.TestDomain.IlluminationTest
{
    public class LampsRowTest
    {
        [Fact]
        public void LampsStatus_WhenListIsEmptyReturnsNull()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(Name.CreateNew("row1"));
            Assert.Null(row.LampsStatus);
        }

        [Fact]
        public void LampsStatus_WhenAtLeastOneLampIsOnReturnsOn()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            firstLamp.SwitchOff();
            secondLamp.SwitchOff();
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            Assert.Equal(DeviceStatus.On, row.LampsStatus);
        }

        [Fact]
        public void SwitchOn_SwitchOnAllLamps()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            firstLamp.SwitchOff();
            secondLamp.SwitchOff();
            thirdLamp.SwitchOff();
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            row.SwitchOn();
            Assert.Equal(DeviceStatus.On, firstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.On, secondLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.On, thirdLamp.DeviceStatus);
        }

        [Fact]
        public void SwitchOn_Id_ThrowsExceptionIfIdIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            Assert.Throws<ArgumentException>(() => row.SwitchOn(Guid.NewGuid()));
        }

        [Fact]
        public void SwitchOn_Id_SwitchOnLampWithThatId()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            secondLamp.SwitchOff();
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            row.SwitchOn(secondLamp.Id);
            Assert.Equal(DeviceStatus.On, secondLamp.DeviceStatus);
        }

        [Fact]
        public void SwitchOn_Name_ThrowsExceptionIfNameIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            Assert.Throws<ArgumentException>(() => row.SwitchOn("ciao"));
        }

        [Fact]
        public void SwitchOn_Name_SwitchOnLampWithThatName()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            secondLamp.SwitchOff();
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            row.SwitchOn("lamp2");
            Assert.Equal(DeviceStatus.On, secondLamp.DeviceStatus);
        }

        [Fact]
        public void SwitchOff_SwitchOffAllLamps()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            row.SwitchOff();
            Assert.Equal(DeviceStatus.Off, firstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, secondLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, thirdLamp.DeviceStatus);
        }

        [Fact]
        public void SwitchOff_Id_ThrowsExceptionIfIdIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            Assert.Throws<ArgumentException>(() => row.SwitchOff(Guid.NewGuid()));
        }

        [Fact]
        public void SwitchOff_Id_SwitchOffLampWithThatId()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            row.SwitchOff(secondLamp.Id);
            Assert.Equal(DeviceStatus.Off, secondLamp.DeviceStatus);
        }

        [Fact]
        public void SwitchOff_Name_ThrowsExceptionIfNameIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            Assert.Throws<ArgumentException>(() => row.SwitchOff("ciao"));
        }

        [Fact]
        public void SwitchOff_Name_SwitchOffLampWithThatName()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            row.SwitchOff("lamp2");
            Assert.Equal(DeviceStatus.Off, secondLamp.DeviceStatus);
        }

        [Fact]
        public void AddLamp_AddsLampToList()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            row.AddLamp(fourthLamp);
            Assert.Equal(4, row.Lamps.Count);
            Assert.Equal(fourthLamp.Id, row.Lamps[3].Id);
        }

        [Fact]
        public void AddLampInPosition_InsertsLampAtGivenPosition()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            row.AddLampInPosition(fourthLamp, 1);
            Assert.Equal(4, row.Lamps.Count);
            Assert.Equal(fourthLamp.Id, row.Lamps[1].Id);
        }

        [Fact]
        public void RemoveLamp_Id_ThrowsExceptionIfIdIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            Assert.Throws<ArgumentException>(() => row.RemoveLamp(Guid.NewGuid()));
        }

        [Fact]
        public void RemoveLamp_Id_RemovesLampWithThatId()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            row.RemoveLamp(secondLamp.Id);
            Assert.Equal(2, row.Lamps.Count);
            Assert.DoesNotContain(secondLamp, row.Lamps);
        }

        [Fact]
        public void RemoveLamp_Name_ThrowsExceptionIfNameIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            Assert.Throws<ArgumentException>(() => row.RemoveLamp("ciao"));
        }

        [Fact]
        public void RemoveLamp_Name_RemovesLampWithThatName()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            row.RemoveLamp("lamp2");
            Assert.Equal(2, row.Lamps.Count);
            Assert.DoesNotContain(secondLamp, row.Lamps);
        }

        [Fact]
        public void RemoveInPosition_RemovesLampAtGivenPosition()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            row.RemoveInPosition(1);
            Assert.Equal(2, row.Lamps.Count);
            Assert.Equal(firstLamp.Id, row.Lamps[0].Id);
            Assert.Equal(thirdLamp.Id, row.Lamps[1].Id);
        }

        [Fact]
        public void SetIntensityForAllLamps_SetsBrightnessForEveryLamp()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            row.SetIntensityForAllLamps(Brightness.CreateNew(50));
            Assert.Equal(Brightness.CreateNew(50), firstLamp.Brightness);
            Assert.Equal(Brightness.CreateNew(50), secondLamp.Brightness);
            Assert.Equal(Brightness.CreateNew(50), thirdLamp.Brightness);
        }

        [Fact]
        public void SetIntensityForLamp_Id_ThrowsExceptionIfIdIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            Assert.Throws<ArgumentException>(() => row.SetIntensityForLamp(Guid.NewGuid(), Brightness.CreateNew(50)));
        }

        [Fact]
        public void SetIntensityForLamp_Id_SetsBrightnessOfTheLampWithThatId()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            row.SetIntensityForLamp(secondLamp.Id, Brightness.CreateNew(50));
            Assert.Equal(firstLamp.DefaultBrigthness, firstLamp.Brightness);
            Assert.Equal(Brightness.CreateNew(50), secondLamp.Brightness);
            Assert.Equal(thirdLamp.DefaultBrigthness, thirdLamp.Brightness);
        }

        [Fact]
        public void SetIntensityForLamp_Name_ThrowsExceptionIfNameIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            Assert.Throws<ArgumentException>(() => row.SetIntensityForLamp("ciao", Brightness.CreateNew(50)));
        }

        [Fact]
        public void SetIntensityForLamp_Name_SetsBrightnessOfTheLampWithThatName()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            row.SetIntensityForLamp("lamp2", Brightness.CreateNew(50));
            Assert.Equal(firstLamp.DefaultBrigthness, firstLamp.Brightness);
            Assert.Equal(Brightness.CreateNew(50), secondLamp.Brightness);
            Assert.Equal(thirdLamp.DefaultBrigthness, thirdLamp.Brightness);
        }

        [Fact]
        public void FindLampWithMaxIntensity_ReturnsNullIfListIsEmpty()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(Name.CreateNew("row1"));
            Assert.Null(row.FindLampWithMaxIntensity());
        }

        [Fact]
        public void FindLampWithMaxIntensity_ReturnsLampWithHighestBrightness()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            firstLamp.SetBrightness(Brightness.CreateNew(10));
            secondLamp.SetBrightness(Brightness.CreateNew(80));
            thirdLamp.SetBrightness(Brightness.CreateNew(50));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            var result = row.FindLampWithMaxIntensity();
            Assert.Equal(secondLamp, result);
        }

        [Fact]
        public void FindLampWithMinIntensity_ReturnsNullIfListIsEmpty()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(Name.CreateNew("row1"));
            Assert.Null(row.FindLampWithMinIntensity());
        }

        [Fact]
        public void FindLampWithMinIntensity_ReturnsLampWithLowestBrightness()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            firstLamp.SetBrightness(Brightness.CreateNew(90));
            secondLamp.SetBrightness(Brightness.CreateNew(20));
            thirdLamp.SetBrightness(Brightness.CreateNew(50));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            var result = row.FindLampWithMinIntensity();
            Assert.Equal(secondLamp, result);
        }

        [Fact]
        public void FindLampById_ThrowsExceptionIfIdIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            Assert.Throws<ArgumentException>(() => row.FindLampById(Guid.NewGuid()));
        }

        [Fact]
        public void FindLampById_ReturnsLampWithThatId()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            var result = row.FindLampById(secondLamp.Id);
            Assert.Equal(secondLamp, result);
        }

        [Fact]
        public void FindLampsByIntensityRange_ThrowsExceptionIfMinIsGreaterThanMax()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            Assert.Throws<ArgumentException>(() => row.FindLampsByIntensityRange(80, 20));
        }

        [Fact]
        public void FindLampsByIntensityRange_ReturnsLampsWithinRange()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            firstLamp.SetBrightness(Brightness.CreateNew(20));
            secondLamp.SetBrightness(Brightness.CreateNew(50));
            thirdLamp.SetBrightness(Brightness.CreateNew(90));
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            List<AbstractLamp> result = row.FindLampsByIntensityRange(40, 60);
            Assert.Equal(secondLamp, result[0]);
        }

        [Fact]
        public void FindAllOn_ReturnsOnlyLampsThatAreOn()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            firstLamp.SwitchOff();
            thirdLamp.SwitchOff();
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            List<AbstractLamp> result = row.FindAllOn();
            Assert.Equal(secondLamp, result[0]);
        }

        [Fact]
        public void FindAllOff_ReturnsOnlyLampsThatAreOff()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            secondLamp.SwitchOff();
            LampsRow row = new LampsRow(new List<AbstractLamp> { firstLamp, secondLamp, thirdLamp }, Name.CreateNew("row1"));
            List<AbstractLamp> result = row.FindAllOff();
            Assert.Equal(secondLamp, result[0]);
        }
    }
    
}
