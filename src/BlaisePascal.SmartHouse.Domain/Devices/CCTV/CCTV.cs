using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.CCTV.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.CCTV
{
    public class CCTV : AbstractDevice, ICCTV
    {
        public bool IsRecording { get; private set; }

        public int ZoomDefaultStep = 1;
        public Zoom ZoomValue {  get; private set; }
        public Zoom MinZoomValue { get; private set; } = Zoom.CreateNew(CCTVValidator.MinZoom);
        public Zoom MaxZoomValue { get; private set; } = Zoom.CreateNew(CCTVValidator.MaxZoom);
        public Zoom DefaultZoomValue { get; private set; } = Zoom.CreateNew(5);

        public int RotationDefaultStep = 10;
        public Rotation RotationDegrees {  get; private set; }
        public Rotation MinRotationDegrees { get; private set; } = Rotation.CreateNew(CCTVValidator.MinRotationDegrees);
        public Rotation MaxRotationDegrees { get; private set; } = Rotation.CreateNew(CCTVValidator.MaxRotationDegrees);
        public Rotation DefaultRotationDegrees { get; private set; } = Rotation.CreateNew(0);

        public CCTV(Name name, bool isRecording, float zoomValue, float rotation): base(name)
        {
            IsRecording = isRecording;
            ZoomValue = Zoom.CreateNew(zoomValue);
            RotationDegrees = Rotation.CreateNew(rotation);
        }

        public CCTV(Name name): base(name)
        {
            IsRecording = true;
            ZoomValue = DefaultZoomValue;
            RotationDegrees = DefaultRotationDegrees;
        }


        public void SetRotationDegrees()
        {
            CCTVValidator.CheckIsOn(Status);
            RotationDegrees = DefaultRotationDegrees;
            LastModified = DateTime.UtcNow;
        }

        public void SetRotationDegrees(Rotation rotationDegrees)
        {
            CCTVValidator.CheckIsOn(Status);
            RotationDegrees = rotationDegrees;
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseRotationDegrees()
        {
            CCTVValidator.CheckIsOn(Status);
            RotationDegrees = Rotation.CreateNew(RotationDegrees + RotationDefaultStep);
            LastModified = DateTime.Now;
        }
        public void IncreaseRotationDegrees(float value)
        {
            CCTVValidator.CheckIsOn(Status);
            CCTVValidator.CheckIsPositive(value);
            RotationDegrees = Rotation.CreateNew(RotationDegrees + value);
            LastModified = DateTime.Now; 
        } 

        public void DecreaseRotationDegrees()
        {
            CCTVValidator.CheckIsOn(Status);
            RotationDegrees = Rotation.CreateNew(RotationDegrees - RotationDefaultStep);
            LastModified = DateTime.Now;
        }
        public void DecreaseRotationDegrees(float value)
        {
            CCTVValidator.CheckIsOn(Status);
            CCTVValidator.CheckIsPositive(value);
            RotationDegrees = Rotation.CreateNew(RotationDegrees - value);
            LastModified = DateTime.Now;
        }

        public void SetZoom()
        {
            CCTVValidator.CheckIsOn(Status);
            ZoomValue = DefaultZoomValue;
            LastModified = DateTime.UtcNow;
        }

        public void SetZoom(Zoom zoom)
        {
            CCTVValidator.CheckIsOn(Status);
            ZoomValue = zoom;
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseZoom()
        {
            CCTVValidator.CheckIsOn(Status);
            ZoomValue = Zoom.CreateNew(ZoomValue + ZoomDefaultStep);
            LastModified = DateTime.Now;
        }
        public void IncreaseZoom(float value)
        {
            CCTVValidator.CheckIsOn(Status);
            CCTVValidator.CheckIsPositive(value);
            ZoomValue = Zoom.CreateNew(ZoomValue + value);
            LastModified = DateTime.Now;
        }

        public void DecreaseZoom()
        {
            CCTVValidator.CheckIsOn(Status);
            ZoomValue = Zoom.CreateNew(ZoomValue - ZoomDefaultStep);
            LastModified = DateTime.Now;
        }

        public void DecreaseZoom(float value)
        {
            CCTVValidator.CheckIsOn(Status);
            CCTVValidator.CheckIsPositive(value);
            ZoomValue = Zoom.CreateNew(ZoomValue - value);
            LastModified = DateTime.Now;
        }
        public void StartRecording()
        {
            CCTVValidator.CheckIsOn(Status);
            CCTVValidator.CheckIsRecording(IsRecording);
            IsRecording = true;
            LastModified = DateTime.UtcNow;
        }
        public void StopRecording()
        {
            CCTVValidator.CheckIsOn(Status);
            CCTVValidator.CheckIsNotRecording(IsRecording);
            IsRecording = false;
            LastModified = DateTime.UtcNow;
        }
    }
}
