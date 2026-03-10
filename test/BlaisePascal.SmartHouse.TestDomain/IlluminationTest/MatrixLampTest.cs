using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.LuminuosDevices;
using System;
using Xunit;

namespace BlaisePascal.SmartHouse.TestDomain.IlluminationTest
{
    public class MatrixLampTest
    {
        [Fact]
        public void Constructor_WithDimensions_CreatesMatrixWithCorrectDimensionsAndLamps()
        {
            MatrixLamp matrixLamp = new MatrixLamp(2, 2, Name.CreateNew("matrix1"));

            Assert.Equal(4, matrixLamp.Matrix.Length);
            Assert.Equal(DeviceStatus.On, matrixLamp.Matrix[0, 0].DeviceStatus);
            Assert.Equal(DeviceStatus.On, matrixLamp.Matrix[1, 1].DeviceStatus);
        }

        [Fact]
        public void SwitchOn_SwitchOnAllLamps()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            firstLamp.SwitchOff();
            secondLamp.SwitchOff();
            thirdLamp.SwitchOff();
            fourthLamp.SwitchOff();
            AbstractLamp[,] matrix = new AbstractLamp[,] { { firstLamp, secondLamp }, { thirdLamp, fourthLamp } };
            MatrixLamp matrixLamp = new MatrixLamp(matrix, Name.CreateNew("matrix1"));

            matrixLamp.SwitchOn();

            Assert.Equal(DeviceStatus.On, firstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.On, secondLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.On, thirdLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.On, fourthLamp.DeviceStatus);
        }

        [Fact]
        public void SwitchOff_SwitchOffAllLamps()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            AbstractLamp[,] matrix = new AbstractLamp[,] { { firstLamp, secondLamp }, { thirdLamp, fourthLamp } };
            MatrixLamp matrixLamp = new MatrixLamp(matrix, Name.CreateNew("matrix1"));

            matrixLamp.SwitchOff();

            Assert.Equal(DeviceStatus.Off, firstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, secondLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, thirdLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, fourthLamp.DeviceStatus);
        }

        [Fact]
        public void SwitchOffInPosition_ValidPosition_SwitchesOffSpecificLamp()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            AbstractLamp[,] matrix = new AbstractLamp[,] { { firstLamp, secondLamp }, { thirdLamp, fourthLamp } };
            MatrixLamp matrixLamp = new MatrixLamp(matrix, Name.CreateNew("matrix1"));

            matrixLamp.SwitchOffInPosition(0, 1);

            Assert.Equal(DeviceStatus.Off, secondLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.On, firstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.On, thirdLamp.DeviceStatus);
        }

        [Fact]
        public void SwitchOffInPosition_InvalidRow_ThrowsException()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            AbstractLamp[,] matrix = new AbstractLamp[,] { { firstLamp, secondLamp }, { thirdLamp, fourthLamp } };
            MatrixLamp matrixLamp = new MatrixLamp(matrix, Name.CreateNew("matrix1"));

            Assert.Throws<IndexOutOfRangeException>(() => matrixLamp.SwitchOffInPosition(-1, 0));
        }

        [Fact]
        public void SwitchOffInPosition_InvalidColumn_ThrowsException()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            AbstractLamp[,] matrix = new AbstractLamp[,] { { firstLamp, secondLamp }, { thirdLamp, fourthLamp } };
            MatrixLamp matrixLamp = new MatrixLamp(matrix, Name.CreateNew("matrix1"));

            Assert.Throws<IndexOutOfRangeException>(() => matrixLamp.SwitchOffInPosition(0, -5));
        }

        [Fact]
        public void SwitchOnInPosition_ValidPosition_SwitchesOnSpecificLamp()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            secondLamp.SwitchOff();
            firstLamp.SwitchOff();
            AbstractLamp[,] matrix = new AbstractLamp[,] { { firstLamp, secondLamp }, { thirdLamp, fourthLamp } };
            MatrixLamp matrixLamp = new MatrixLamp(matrix, Name.CreateNew("matrix1"));

            matrixLamp.SwitchOnInPosition(0, 1);

            Assert.Equal(DeviceStatus.On, secondLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, firstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.On, thirdLamp.DeviceStatus);
        }

        [Fact]
        public void SwitchOnInPosition_InvalidRow_ThrowsException()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            AbstractLamp[,] matrix = new AbstractLamp[,] { { firstLamp, secondLamp }, { thirdLamp, fourthLamp } };
            MatrixLamp matrixLamp = new MatrixLamp(matrix, Name.CreateNew("matrix1"));

            Assert.Throws<IndexOutOfRangeException>(() => matrixLamp.SwitchOnInPosition(-2, 0));
        }
           

        [Fact]

        public void SwitchOnInPosition_InvalidColumn_ThrowsException()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            AbstractLamp[,] matrix = new AbstractLamp[,] { { firstLamp, secondLamp }, { thirdLamp, fourthLamp } };
            MatrixLamp matrixLamp = new MatrixLamp(matrix, Name.CreateNew("matrix1"));

            Assert.Throws<IndexOutOfRangeException>(() => matrixLamp.SwitchOnInPosition(0, -8));

        }

        [Fact]
        public void AddLampInPosition_ValidPosition_SetsLampInMatrix()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            AbstractLamp[,] matrix = new AbstractLamp[,] { { firstLamp, secondLamp }, { thirdLamp, fourthLamp } };
            MatrixLamp matrixLamp = new MatrixLamp(matrix, Name.CreateNew("matrix1"));
            Lamp newLamp = new(Name.CreateNew("newLamp"));

            matrixLamp.AddLampInPosition(1, 1, newLamp);

            Assert.Equal(newLamp, matrixLamp.Matrix[1, 1]);
            Assert.Equal(firstLamp, matrixLamp.Matrix[0, 0]);
            Assert.Equal(thirdLamp, matrixLamp.Matrix[1, 0]);
        }

        [Fact]
        public void AddLampInPosition_InvalidRow_ThrowsException()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            AbstractLamp[,] matrix = new AbstractLamp[,] { { firstLamp, secondLamp }, { thirdLamp, fourthLamp } };
            MatrixLamp matrixLamp = new MatrixLamp(matrix, Name.CreateNew("matrix1"));
            Lamp newLamp = new(Name.CreateNew("newLamp"));

            Assert.Throws<IndexOutOfRangeException>(() => matrixLamp.SwitchOnInPosition(-10,0));
        }

        [Fact]
        public void AddLampInPosition_InvalidColumn_ThrowsException()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            AbstractLamp[,] matrix = new AbstractLamp[,] { { firstLamp, secondLamp }, { thirdLamp, fourthLamp } };
            MatrixLamp matrixLamp = new MatrixLamp(matrix, Name.CreateNew("matrix1"));
            Lamp newLamp = new(Name.CreateNew("newLamp"));

            Assert.Throws<IndexOutOfRangeException>(() => matrixLamp.SwitchOnInPosition(0, -8));
        }

        [Fact]
        public void RemoveLampInPosition_ValidPosition_SetsPositionToNull()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            AbstractLamp[,] matrix = new AbstractLamp[,] { { firstLamp, secondLamp }, { thirdLamp, fourthLamp } };
            MatrixLamp matrixLamp = new MatrixLamp(matrix, Name.CreateNew("matrix1"));

            matrixLamp.RemoveLampInPosition(0, 1, secondLamp);

            Assert.Equal(null, matrixLamp.Matrix[0, 1]);
            Assert.Equal(firstLamp, matrixLamp.Matrix[0, 0]);
            Assert.Equal(fourthLamp, matrixLamp.Matrix[1, 1]);
        }

        [Fact]
        public void RemoveLampInPosition_InvalidRow_ThrowsException()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            AbstractLamp[,] matrix = new AbstractLamp[,] { { firstLamp, secondLamp }, { thirdLamp, fourthLamp } };
            MatrixLamp matrixLamp = new MatrixLamp(matrix, Name.CreateNew("matrix1"));

            Assert.Throws<IndexOutOfRangeException>(() => matrixLamp.SwitchOnInPosition(10, 0));
        }

        [Fact]
        public void RemoveLampInPosition_InvalidColumn_ThrowsException()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            AbstractLamp[,] matrix = new AbstractLamp[,] { { firstLamp, secondLamp }, { thirdLamp, fourthLamp } };
            MatrixLamp matrixLamp = new MatrixLamp(matrix, Name.CreateNew("matrix1"));

            Assert.Throws<IndexOutOfRangeException>(() => matrixLamp.SwitchOnInPosition(0, -8));
        }

        [Fact]
        public void FindMinBrightnessLed_ReturnsLampWithLowestBrightness()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            firstLamp.SetBrightness(Brightness.CreateNew(60));
            secondLamp.SetBrightness(Brightness.CreateNew(20));
            thirdLamp.SetBrightness(Brightness.CreateNew(50));
            fourthLamp.SetBrightness(Brightness.CreateNew(90));
            AbstractLamp[,] matrix = new AbstractLamp[,] { { firstLamp, secondLamp }, { thirdLamp, fourthLamp } };
            MatrixLamp matrixLamp = new MatrixLamp(matrix, Name.CreateNew("matrix1"));

            AbstractLamp result = matrixLamp.FindMinBrightnessLed();

            Assert.Equal(secondLamp, result);
        }

        [Fact]
        public void FindMaxBrightnessLed_ReturnsLampWithHighestBrightness()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            Lamp thirdLamp = new(Name.CreateNew("lamp3"));
            Lamp fourthLamp = new(Name.CreateNew("lamp4"));
            firstLamp.SetBrightness(Brightness.CreateNew(60));
            secondLamp.SetBrightness(Brightness.CreateNew(20));
            thirdLamp.SetBrightness(Brightness.CreateNew(50));
            fourthLamp.SetBrightness(Brightness.CreateNew(90));
            AbstractLamp[,] matrix = new AbstractLamp[,] { { firstLamp, secondLamp }, { thirdLamp, fourthLamp } };
            MatrixLamp matrixLamp = new MatrixLamp(matrix, Name.CreateNew("matrix1"));

            AbstractLamp result = matrixLamp.FindMaxBrightnessLed();

            Assert.Equal(fourthLamp, result);
        }
    }
}