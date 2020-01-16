using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace screenshare3.Models
{
  public class JDADebugDeviceInfo
  {
    public string DeviceName { get; set; }
    public string DeviceType { get; set; }
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public string DevicePlatform { get; set; }
    public string DeviceVersion { get; set; }
    public int ID { get; set; }

    public int BugId { get; set; }

    public DateTime CurrentDate { get; set; }
    public string vession { get; set; }
   public string build { get; set; }
  public string ScreenResolution { get; set; }
  public string batterylevel { get; set; }
  public string DeviceLang { get; set; }
    public string CurrentNetwork { get; set; }
    public string CurrentProfile { get; set; }



    public string MaxCPU { get; set; }
    public string MaxMemory { get; set; }
    public string MaxDataFreme { get; set; }
    public string MaxVirtualMemory { get; set; }
    public string MaxSpace { get; set; }
  }

  public class JDADebugActivityInfo
  {
    public string ScreenShot { get; set; }
    public string ActivityData { get; set; }
    public string BuildData { get; set; }
    public string AnalyticsInfo { get; set; }
    public string NetworkData { get; set; }
    public string DeviceOrientation { get; set; }
    public int ID { get; set; }

    public int BugId { get; set; }

    public DateTime CurrentDate { get; set; }


    public string CPUUses { get; set; }
    public string MemoryUses { get; set; }
    public string DataFreme { get; set; }
    public string VirtualMemory { get; set; }
    public string SpaceUses { get; set; }

  }


  public class JDADebugInfo
  {
    public string BugName { get; set; }
    public string ClientName { get; set; }
    public string CreatedBy { get; set; }
    public string AnalyticsInfo { get; set; }

    public int ID { get; set; }


    public DateTime CurrentDate { get; set; }

  }
}
