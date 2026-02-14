//using BlaisePascal.SmartHouse.Domain.Devices.CCTV;

//namespace BlaisePascal.SmartHouse.TestDomain.CCTVTest
//{
//    public class CCTVTest
//    {
//        //FINISHED
//        [Fact]
//        public void SetRotationDegrees_WhenValueIsUnderMinRotationIsSetAtMin()
//        {
//            CCTV CCTV = new("telecamera");
//            CCTV.SetRotationDegrees(-100);
//            Assert.Equal(CCTV.MinRotationDegrees, CCTV.RotationDegrees);
//        }

//        [Fact]
//        public void SetRotationDeegrees_WhenValueIsOverTheMaxRotationIsSetAtMax()
//        {
//            CCTV CCTV = new("telecamera");
//            CCTV.SetRotationDegrees(100);
//            Assert.Equal(CCTV.MaxRotationDegrees, CCTV.RotationDegrees);
//        }

//        [Fact]
//        public void SetRotationDegrees_CCTVCannotBeOff()
//        {
//            CCTV CCTV = new("telecamera");
//            CCTV.SwitchOff();
//            Assert.Throws<InvalidOperationException>(() => CCTV.SetRotationDegrees(2));
//        } 

//        [Fact]
//        public void SetRotationDegrees_WhenDegreesValueIsRightRotationIsSetCorrectly()
//        {
//            CCTV CCTV = new("telecamera");
//            CCTV.SetRotationDegrees(50);
//            Assert.Equal(50, CCTV.RotationDegrees);
//        }

//        [Fact]
//        public void IncreaseRotationDegrees_WhenValueGoesOverTheMaxRotationIsSetAtMax()
//        {
//            CCTV CCTV = new("telecamera");
//            CCTV.SetRotationDegrees(50);
//            CCTV.IncreaseRotationDegrees(100);
//            Assert.Equal(CCTV.MaxRotationDegrees, CCTV.RotationDegrees);
//        }

//        [Fact]
//        public void IncreaseRotationDegrees_ValueCannotBeNegative()
//        {
//            CCTV CCTV = new("telecamera");
//            Assert.Throws<ArgumentException>(() => CCTV.IncreaseRotationDegrees(-1));
//        }

//        [Fact]
//        public void IncreaseRotationDegrees_CCTVCannotBeOff()
//        {
//            CCTV CCTV = new("telecamera");
//            CCTV.SwitchOff();
//            Assert.Throws<InvalidOperationException>(() => CCTV.IncreaseRotationDegrees(10));
//        }

//        [Fact]
//        public void IncreaseRotationDegrees_WhenValueIsPositiveAndDoesNotOverflowTheRangeRotationRotationIsSetCorrectly()
//        {
//            CCTV CCTV = new("telecamera");
//            CCTV.SetRotationDegrees(10);
//            CCTV.IncreaseRotationDegrees(50);
//            Assert.Equal(60, CCTV.RotationDegrees);
//        }

//        [Fact]
//        public void DecreaseRotationDegrees_WhenValueGoesUnderMinValueRotationIsSetAtMin()
//        {
//            CCTV CCTV = new("telecamera");
//            CCTV.SetRotationDegrees(-50);
//            CCTV.DecreaseRotationDegrees(100);
//            Assert.Equal(CCTV.MinRotationDegrees, CCTV.RotationDegrees);
//        }

//        [Fact]
//        public void DecreaseValue_ValueCannotBeNegative()
//        {
//            CCTV CCTV = new("telecamera");
//            Assert.Throws<ArgumentException>(() => CCTV.DecreaseRotationDegrees(-1));
//        }

//        [Fact]
//        public void DecreaseValue_CCTVCannotBeOff()
//        {
//            CCTV CCTV = new("telecamera");
//            CCTV.SwitchOff();
//            Assert.Throws<InvalidOperationException>(() => CCTV.DecreaseRotationDegrees(10));
//        }

//        [Fact]
//        public void DecreaseRotationDegrees_WhenValueIsPositiveAndDoesNotOverflowTheRangeRotationIsSetCorrectly()
//        {
//            CCTV CCTV = new("telecamera");
//            CCTV.SetRotationDegrees(60);
//            CCTV.DecreaseRotationDegrees(50);
//            Assert.Equal(10, CCTV.RotationDegrees);
//        }

//        [Fact]
//        public void SetZoom_WhenValueGoesUnderTheMinZoomIsSetAtMin()
//        {
//            CCTV CCTV = new("telecamera");
//            CCTV.SetZoom(-200);
//            Assert.Equal(CCTV.MinZoomValue, CCTV.ZoomValue);
//        }

//        [Fact]
//        public void SetZoom_WhenValueGoesOverTheMaxZoomIsSetAtMax() 
//        { 
//            CCTV CCTV = new("telecamera");
//            CCTV.SetZoom(200);
//            Assert.Equal(CCTV.MaxZoomValue, CCTV.ZoomValue);
//        }

//        [Fact]
//        public void SetZoom_CCTVCannotbeOff()
//        {
//            CCTV CCTV = new("telecamera");
//            CCTV.SwitchOff();
//            Assert.Throws<InvalidOperationException>(() => CCTV.SetZoom(10));
//        }

//        [Fact]
//        public void SetZoom_WhenZoomIsRightTheZoomIsSetCorrectly()
//        {
//            CCTV CCTV = new("telecamera");
//            CCTV.SetZoom(3);
//            Assert.Equal(3, CCTV.ZoomValue);
//        }

//        [Fact]
//        public void StartRecordind_SetIsRecordingAtTrue()
//        {
//            CCTV CCTV = new("telecamera");
//            CCTV.StartRecording();
//            Assert.True(CCTV.IsRecording);
//        }

//        [Fact]
//        public void StopRecordind_SetIsRecordingAtFalse()
//        {
//            CCTV CCTV = new("telecamera");
//            CCTV.StartRecording();
//            CCTV.StopRecording();
//            Assert.False(CCTV.IsRecording);
//        }
//    }
//}
