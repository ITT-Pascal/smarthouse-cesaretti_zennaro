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
        public void SetRotationDegrees_WhenValueIsUnderMinIsSetAtMin()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            CCTV.SetRotationDegrees(-100);
            Assert.Equal(CCTV.GetMinRotationDegrees(), CCTV.RotationDegrees);
        }

        [Fact]
        public void SetRotationDeegrees_WhenValueIsOverTheMaxIsSetAtMax()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            CCTV.SetRotationDegrees(-100);
            Assert.Equal(CCTV.GetMinRotationDegrees(), CCTV.RotationDegrees);
        }

        [Fact]
        public void SetRotationDegrees_WhenDegreesValueIsRightRotationIsSetCorrectly()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            CCTV.SetRotationDegrees(50);
            Assert.Equal(50, CCTV.RotationDegrees);
        }

        [Fact]
        public void IncreaseRotationDegrees_ValueCannotGoOverTheMax()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => CCTV.IncreaseRotationDegrees(200));
        }

        [Fact]
        public void IncreaseRotationDegrees_ValueCannotBeNegative()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            Assert.Throws<ArgumentException>(() => CCTV.IncreaseRotationDegrees(-1));
        }

        [Fact]
        public void IncreaseRotationDegrees_WhenValueIsPositiveAndDoNotOverflowTheRangeIsSetCorrectly()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            CCTV.SetRotationDegrees(10);
            CCTV.IncreaseRotationDegrees(50);
            Assert.Equal(60, CCTV.RotationDegrees);
        }

        [Fact]
        public void DecreaseRotationDegrees_ValueCannotGoOverTheMin()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => CCTV.DecreaseRotationDegrees(200));
        }

        [Fact]
        public void DecreaseValue_ValueCannotBeNegative()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            Assert.Throws<ArgumentException>(() => CCTV.DecreaseRotationDegrees(-1));
        }

        [Fact]
        public void DecreaseRotationDegrees_WhenValueIsPositiveAndDoNotOverflowTheRangeIsSetCorrectly()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            CCTV.SetRotationDegrees(60);
            CCTV.DecreaseRotationDegrees(50);
            Assert.Equal(60, CCTV.RotationDegrees);
        }

        [Fact]
        public void SetZoom_CannotGoUnderMinZoom()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => CCTV.SetZoom(-100));
        }

        [Fact]
        public void SetZoom_CannotGoBeyondMaxZoom() 
        { 
            CCTV CCTV = new("telecamera");
            CCTV.SwitchOn();
            Assert.Throws<ArgumentOutOfRangeException>(() => CCTV.SetZoom(100));
        }

        [Fact]
        public void SetZoom_WhenZoomIsRightTheZoomIsSetCorrectly()
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
