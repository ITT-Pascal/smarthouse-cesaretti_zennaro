using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlaisePascal.SmartHouse.Domain.CCTV
{
    //FINISHED
    public class CCTV : AbstractDevice, ICCTV
    {
        public bool IsRecording { get; private set; }
        public float ZoomValue {  get; private set; }
        private const float MinZoomValue = CCTVValidator.MaxZoom;
        private const float MaxZoomValue = CCTVValidator.MinZoom;
        public float RotationDegrees {  get; private set; }
        private const float MinRotationDegrees = CCTVValidator.MinRotationDegrees;
        private const float MaxRotationDegrees = CCTVValidator.MaxRotationDegrees;
        
        public CCTV(string name, bool isRecording, float zoomValue, float rotation): base(name)
        {
            IsRecording = isRecording;
            ZoomValue = zoomValue;
            RotationDegrees = rotation;
        }

        public CCTV(string name): this(name, false, 0, 0)
        {
            ZoomValue = 0;
            RotationDegrees = 0;
            IsRecording = false;
        }

        public void SetRotationDegrees(float degrees)
        {
            CCTVValidator.CheckIsOn(Status);
            RotationDegrees = CCTVValidator.RotationValidator(degrees);
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseRotationDegrees(int value)
        {
            CCTVValidator.CheckIsOn(Status);
            CCTVValidator.CheckIsPositive(value);
            SetRotationDegrees(RotationDegrees + value);
            LastModified = DateTime.Now; 
        } 

        public void DecreaseRotationDegrees(int value)
        {
            CCTVValidator.CheckIsOn(Status);
            CCTVValidator.CheckIsPositive(value);
            SetRotationDegrees(RotationDegrees - value);
            LastModified = DateTime.Now;
        }

        public void SetZoom(float zoom)
        {
            CCTVValidator.CheckIsOn(Status);
            ZoomValue = CCTVValidator.ZoomValidator(zoom);
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseZoom(int value)
        {
            CCTVValidator.CheckIsOn(Status);
            CCTVValidator.RotationValidator(value);
            SetZoom(ZoomValue + value);  
            LastModified = DateTime.Now;
        }

        public void DecreaseZoom(int value)
        {
            CCTVValidator.CheckIsOn(Status);
            CCTVValidator.CheckIsPositive(value);
            SetZoom(ZoomValue - value);
            LastModified = DateTime.Now;
        }
        public void StartRecording()
        {
            CCTVValidator.CheckIsOn(Status);
            IsRecording = true;
            LastModified = DateTime.UtcNow;
        }
        public void StopRecording()
        {
            CCTVValidator.CheckIsOn(Status);
            IsRecording = false;
            LastModified = DateTime.UtcNow;
        }

        public float GetMaxZoom()
        {
            return MaxZoomValue;
        }

        public float GetMinZoom()
        {
            return MinZoomValue;
        }

        public float GetMaxRotationDegrees()
        {
            return MaxRotationDegrees;
        }

        public float GetMinRotationDegrees()
        {
            return MinRotationDegrees;
        }
    }
}
