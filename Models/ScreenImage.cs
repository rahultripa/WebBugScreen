using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace screenshare3.Models
{
  public class ScreenImage
  {
    public int ID { get; set; }
    public string imageScreen { get; set; }
    public string Data { get; set; }
   
  }




  public class ScreenImageInfo
  {
    public int ID { get; set; }
    public string imageScreen { get; set; }
    public string Data { get; set; }

    public DeviceInfo deviceInfo { get; set; }

    public string textRecognisaion { get; set; }


  }
  public class DeviceInfo
  {

    public string DeviceName { get; set; }
    public string DeviceType { get; set; }
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public string Platform { get; set; }
    public string Version { get; set; }

  }

}
