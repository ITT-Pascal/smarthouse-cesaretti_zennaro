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
        public float MinZoomValue { get; private set; } = CCTVValidator.MinZoom;
        public float MaxZoomValue { get; private set; } = CCTVValidator.MaxZoom;
        public float RotationDegrees {  get; private set; }
        public float MinRotationDegrees { get; private set; } = CCTVValidator.MinRotationDegrees;
        public float MaxRotationDegrees { get; private set; } = CCTVValidator.MaxRotationDegrees;
        
        public CCTV(string name, bool isRecording, float zoomValue, float rotation): base(name)
        {
            IsRecording = isRecording;
            ZoomValue = zoomValue;
            RotationDegrees = rotation;
        }

        public CCTV(string name): this(name, false, 0, 0)
        {

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
    }
}
