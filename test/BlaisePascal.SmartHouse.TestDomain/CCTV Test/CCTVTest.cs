using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.CCTV;
using BlaisePascal.SmartHouse.Domain.Devices.CCTV.ValueObjects;

namespace BlaisePascal.SmartHouse.TestDomain.CCTVTest
{
    public class CCTVTest
    {
        [Fact]
        public void SetRotationDegrees_CannotSetRotationDegreesByDefaultWhenDeviceIsOff()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => CCTV.SetRotationDegrees());
        }

        [Fact]
        public void SetRotationDegrees_WithoutParameterRotationIsSetAtDefaultValue()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetRotationDegrees();
            Assert.Equal(CCTV.DefaultRotationDegrees, CCTV.RotationDegrees);
        }

        [Fact]
        public void SetRotationDegrees_CCTVCannotBeOff()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => CCTV.SetRotationDegrees(Rotation.CreateNew(2)));
        }

        [Fact]
        public void SetRotationDegrees_WhenValueIsUnderMinRotationIsSetAtMin()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetRotationDegrees(Rotation.CreateNew(-100));
            Assert.Equal(CCTV.MinRotationDegrees, CCTV.RotationDegrees);
        }

        [Fact]
        public void SetRotationDeegrees_WhenValueIsOverTheMaxRotationIsSetAtMax()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetRotationDegrees(Rotation.CreateNew(100));
            Assert.Equal(CCTV.MaxRotationDegrees, CCTV.RotationDegrees);
        }

        [Fact]
        public void SetRotationDegrees_WhenDegreesValueIsRightRotationIsSetCorrectly()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetRotationDegrees(Rotation.CreateNew(50));
            Rotation expected = Rotation.CreateNew(50);
            Assert.Equal(expected, CCTV.RotationDegrees);
        }

        [Fact]
        public void IncreaseRotationDegrees_CannotIncreaseByDefaultValueWhenDeviceIsOff()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => CCTV.IncreaseRotationDegrees());
        }

        [Fact]
        public void IncreaseRotationDegrees_WithoutParametresWhenValueGoesOverTheMaxRotationIsSetAtMax()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetRotationDegrees(Rotation.CreateNew(90));
            CCTV.IncreaseRotationDegrees();
            Assert.Equal(CCTV.MaxRotationDegrees, CCTV.RotationDegrees);
        }

        [Fact]
        public void IncreaseRotationDegrees_WithoutParameterRotationIsIncreasedByDefaultValue()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.IncreaseRotationDegrees();
            Rotation expected = Rotation.CreateNew(10);
            Assert.Equal(expected, CCTV.RotationDegrees);
        }

        [Fact]
        public void IncreaseRotationDegrees_CCTVCannotBeOff()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => CCTV.IncreaseRotationDegrees(10));
        }

        [Fact]
        public void IncreaseRotationDegrees_WhenValueGoesOverTheMaxRotationIsSetAtMax()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetRotationDegrees(Rotation.CreateNew(50));
            CCTV.IncreaseRotationDegrees(100);
            Assert.Equal(CCTV.MaxRotationDegrees, CCTV.RotationDegrees);
        }

        [Fact]
        public void IncreaseRotationDegrees_ValueCannotBeNegative()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            Assert.Throws<ArgumentException>(() => CCTV.IncreaseRotationDegrees(-1));
        }

        [Fact]
        public void IncreaseRotationDegrees_WhenValueIsPositiveAndDoesNotOverflowTheRangeRotationRotationIsSetCorrectly()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetRotationDegrees(Rotation.CreateNew(10));
            CCTV.IncreaseRotationDegrees(50);
            Rotation expected = Rotation.CreateNew(60);
            Assert.Equal(expected, CCTV.RotationDegrees);
        }

        [Fact]
        public void DecreaseRotationDegrees_CannotDecreaseByDefaultValueWhenDeviceIsOff()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => CCTV.DecreaseRotationDegrees());
        }

        [Fact]
        public void DecreaseRotationDegrees_WithoutParametresWhenValueGoesUnderTheMinRotationIsSetAtMin()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetRotationDegrees(Rotation.CreateNew(-90));
            CCTV.DecreaseRotationDegrees();
            Assert.Equal(CCTV.MinRotationDegrees, CCTV.RotationDegrees);
        }

        [Fact]
        public void DecreaseRotationDegrees_WithoutParameterRotationIsDecreasedByDefaultValue()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.DecreaseRotationDegrees();
            Rotation expected = Rotation.CreateNew(-10);
            Assert.Equal(expected, CCTV.RotationDegrees);
        }

        [Fact]
        public void DecreaseValue_CCTVCannotBeOff()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => CCTV.DecreaseRotationDegrees(10));
        }

        [Fact]
        public void DecreaseRotationDegrees_WhenValueGoesUnderMinValueRotationIsSetAtMin()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetRotationDegrees(Rotation.CreateNew(-50));
            CCTV.DecreaseRotationDegrees(100);
            Assert.Equal(CCTV.MinRotationDegrees, CCTV.RotationDegrees);
        }

        [Fact]
        public void DecreaseValue_ValueCannotBeNegative()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            Assert.Throws<ArgumentException>(() => CCTV.DecreaseRotationDegrees(-1));
        }

        [Fact]
        public void DecreaseRotationDegrees_WhenValueIsPositiveAndDoesNotOverflowTheRangeRotationIsSetCorrectly()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetRotationDegrees(Rotation.CreateNew(60));
            CCTV.DecreaseRotationDegrees(50);
            Rotation expected = Rotation.CreateNew(10);
            Assert.Equal(expected, CCTV.RotationDegrees);
        }

        [Fact]
        public void SetZoom_CannotSetZoomByDefaultWhenDeviceIsOff()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => CCTV.SetZoom(Zoom.CreateNew(10)));
        }

        [Fact]
        public void SetZoom_WithoutParameterZoomIsSetAtDefaultValue()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetZoom();
            Assert.Equal(CCTV.DefaultZoomValue, CCTV.ZoomValue);
        }

        [Fact]
        public void SetZoom_CCTVCannotbeOff()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => CCTV.SetZoom(Zoom.CreateNew(10)));
        }

        [Fact]
        public void SetZoom_WhenValueGoesUnderTheMinZoomIsSetAtMin()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetZoom(Zoom.CreateNew(-200));
            Assert.Equal(CCTV.MinZoomValue, CCTV.ZoomValue);
        }

        [Fact]
        public void SetZoom_WhenValueGoesOverTheMaxZoomIsSetAtMax()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetZoom(Zoom.CreateNew(200));
            Assert.Equal(CCTV.MaxZoomValue, CCTV.ZoomValue);
        }

        [Fact]
        public void SetZoom_WhenZoomIsRightTheZoomIsSetCorrectly()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetZoom(Zoom.CreateNew(3));
            Zoom expected = Zoom.CreateNew(3);
            Assert.Equal(expected, CCTV.ZoomValue);
        }

        [Fact]
        public void IncreaseZoom_CannotIncreaseZoomByDefaultValueWhenDeviceIsOff()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => CCTV.IncreaseZoom());
        }

        [Fact]
        public void IncreaseZoom_WithoutParameterWhenValueGoesOverTheMaxZoomIsSetAtMax()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetZoom(Zoom.CreateNew(10));
            CCTV.IncreaseZoom();
            Assert.Equal(CCTV.MaxZoomValue, CCTV.ZoomValue);
        }

        [Fact]
        public void IncreaseZoom_WithoutParameterZoomIsIncreasedByDefaultValue()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.IncreaseZoom();
            Zoom expected = Zoom.CreateNew(6);
            Assert.Equal(expected, CCTV.ZoomValue);
        }

        [Fact]
        public void IncreaseZoom_CCTVCannotBeOff()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => CCTV.IncreaseZoom(10));
        }

        [Fact]
        public void IncreaseZoom_WhenValueGoesOverTheMaxZoomIsSetAtMax()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.IncreaseZoom(10);
            Assert.Equal(CCTV.MaxZoomValue, CCTV.ZoomValue);
        }

        [Fact]
        public void IncreaseZoom_ValueCannotBeNegative()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            Assert.Throws<ArgumentException>(() => CCTV.IncreaseZoom(-1));
        }

        [Fact]
        public void IncreaseZoom_WhenValueIsPositiveAndDoesNotOverflowTheRangeZoomIsSetCorrectly()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.IncreaseZoom(5);
            Zoom expected = Zoom.CreateNew(10);
            Assert.Equal(expected, CCTV.ZoomValue);
        }

        [Fact]
        public void DecreaseZoom_CannotDecreaseZoomByDefaultValueWhenDeviceIsOff()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => CCTV.DecreaseZoom());
        }

        [Fact]
        public void DecreaseZoom_WithoutParameterWhenValueGoesUnderTheMinZoomIsSetAtMin()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetZoom(Zoom.CreateNew(1));
            CCTV.DecreaseZoom();
            Assert.Equal(CCTV.MinZoomValue, CCTV.ZoomValue);
        }

        [Fact]
        public void DecreaseZoom_WithoutParameterZoomIsDecreasedByDefaultValue()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.DecreaseZoom();    
            Zoom expected = Zoom.CreateNew(4);
            Assert.Equal(expected, CCTV.ZoomValue);
        }

        [Fact]
        public void DecreaseZoom_CCTVCannotBeOff()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => CCTV.DecreaseZoom(10));
        }

        [Fact]
        public void DecreaseZoom_WhenValueGoesUnderTheMinZoomIsSetAtMin()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetZoom(Zoom.CreateNew(1));
            CCTV.DecreaseZoom(10);
            Assert.Equal(CCTV.MinZoomValue, CCTV.ZoomValue);
        }

        [Fact]
        public void DecreaseZoom_ValueCannotBeNegative()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            Assert.Throws<ArgumentException>(() => CCTV.DecreaseZoom(-1));
        }

        [Fact]
        public void DecreaseZoom_WhenValueIsPositiveAndDoesNotOverflowTheRangeZoomIsSetCorrectly()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SetZoom(Zoom.CreateNew(10));
            CCTV.DecreaseZoom(5);
            Zoom expected = Zoom.CreateNew(5);
            Assert.Equal(expected, CCTV.ZoomValue);
        }

        [Fact]
        public void StartRecording_CCTVCannotBeOff()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => CCTV.StartRecording());
        }

        [Fact]
        public void StartRecording_WhenCCTVIsAlreadyRecordingCannotStartRecording()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            Assert.Throws<InvalidOperationException>(() => CCTV.StartRecording());
        }
        [Fact]
        public void StartRecordind_WhenCCTVIsNotRecordingSetIsRecordingAtTrue()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            Assert.True(CCTV.IsRecording);
        }

        [Fact]
        public void StopRecording_CCTVCannotBeOff()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => CCTV.StartRecording());
        }

        [Fact]
        public void StopRecording_WhenCCTVIsAlreadyNotRecordingCannotStopRecording()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.StopRecording();
            Assert.Throws<InvalidOperationException>(() => CCTV.StopRecording());
        }

        [Fact]
        public void StopRecordind_SetIsRecordingAtFalse()
        {
            CCTV CCTV = new(Name.CreateNew("telecamera"));
            CCTV.StopRecording();
            Assert.False(CCTV.IsRecording);
        }
    }
}
