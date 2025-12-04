using BlaisePascal.SmartHouse.Domain;
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
        public void SetRotationDegrees_WhenDegreesAreUnderTheMinRotationIsSetAtMin()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SetRotationDegrees(-100);
            Assert.Equal(CCTV.MinRotationDegrees, CCTV.Rotation);
        }

        [Fact]
        public void SetRotationDeegrees_WhenDegreesAreOverTheMaxROtationIsSetAtMax()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SetRotationDegrees(100);
            Assert.Equal(CCTV.MaxRotationDegrees, CCTV.Rotation);
        }

        [Fact]
        public void SetRotationDegrees_WhenDegreesValueIsRightRotationIsSetCorrectly()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SetRotationDegrees(50);
            Assert.Equal(50, CCTV.Rotation);
        }

        [Fact]
        public void SetZoom_WhenNewZoomIsUnderTheMinZoomIsSetAtMin()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SetZoom(-100);
            Assert.Equal(CCTV.MinZoom, CCTV.ZoomValue);
        }

        [Fact]
        public void SetZoom_WhenNewZoomIsOverTheMaxTheZoomIsSetAtMax() 
        { 
            CCTV CCTV = new("telecamera");
            CCTV.SetZoom(100);
            Assert.Equal(CCTV.MaxZoom, CCTV.ZoomValue);
        }

        [Fact]
        public void SetZoom_WhenNewZoomIsRightTheZoomIsSetCOrrectly()
        {
            CCTV CCTV = new("telecamera");
            CCTV.SetZoom(3);
            Assert.Equal(3, CCTV.ZoomValue);
        }

        [Fact]
        public void StartRecordind_SetIsRecordingAtTrue()
        {
            CCTV CCTV = new("telecamera");
            CCTV.StartRecording();
            Assert.True(CCTV.IsRecording);
        }

        [Fact]
        public void StopRecordind_SetIsRecordingAtFalse()
        {
            CCTV CCTV = new("telecamera");
            CCTV.StartRecording();
            CCTV.StopRecording();
            Assert.False(CCTV.IsRecording);
        }
    }
}
