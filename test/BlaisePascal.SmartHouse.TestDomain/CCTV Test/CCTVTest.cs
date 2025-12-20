using BlaisePascal.SmartHouse.Domain.CCTV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.TestDomain
{
    public class CCTVTest
    {
        [Fact]
        public void SetRotationDegrees_CannotGoBeyondMinRotation()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => CCTV.SetRotationDegrees(-100));
        }

        [Fact]
        public void SetRotationDeegrees_CannotGoBeyondMaxRotation()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => CCTV.SetRotationDegrees(200));
        }

        [Fact]
        public void SetRotationDegrees_WhenDegreesValueIsRightRotationIsSetCorrectly()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            CCTV.SetRotationDegrees(50);
            Assert.Equal(50, CCTV.RotationValue);
        }

        [Fact]
        public void IncreaseRotationDegrees_ValueCannotBeOverTheMax()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => CCTV.IncreaseRotationDegrees(200));
        }

        [Fact]
        public void IncreaseRotationDegrees_ValueCannotBeUnderTheMin()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => CCTV.DecreaseRotationDegrees(200));
        }

        [Fact]
        public void DecreaseRotationDegrees_ValueCannotBeUnderTheMin()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => CCTV.DecreaseRotationDegrees(200));
        }

        [Fact]
        public void DecreaseRotationDegrees_WhenValueIsRightIsSetCorrectly()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            CCTV.SetRotationDegrees(60);
            CCTV.DecreaseRotationDegrees(50);
        }
        [Fact]
        public void SetZoom_CannotGoBeyondMinZoom()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => CCTV.SetZoom(-1));
        }

        [Fact]
        public void SetZoom_CannotGoBeyondMaxZoom() 
        { 
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => CCTV.SetZoom(101));
        }

        [Fact]
        public void SetZoom_WhenNewZoomIsRightTheZoomIsSetCOrrectly()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            CCTV.SetZoom(3);
            Assert.Equal(3, CCTV.ZoomValue);
        }

        [Fact]
        public void StartRecordind_SetIsRecordingAtTrue()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            CCTV.StartRecording();
            Assert.True(CCTV.IsRecording);
        }

        [Fact]
        public void StopRecordind_SetIsRecordingAtFalse()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            CCTV.StartRecording();
            CCTV.StopRecording();
            Assert.False(CCTV.IsRecording);
        }
    }
}
