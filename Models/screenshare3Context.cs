﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace screenshare3.Models
{
    public class screenshare3Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public screenshare3Context() : base("name=screenshare3Context")
        {
        }

    public System.Data.Entity.DbSet<screenshare3.Models.JDAImages> JDAImages { get; set; }

    public System.Data.Entity.DbSet<screenshare3.Models.JDADebugActivityInfo> JDADebugActivityInfoes { get; set; }

    public System.Data.Entity.DbSet<screenshare3.Models.JDADebugDeviceInfo> JDADebugDeviceInfoes { get; set; }

    public System.Data.Entity.DbSet<screenshare3.Models.JDADebugInfo> JDADebugInfoes { get; set; }
  }
}
