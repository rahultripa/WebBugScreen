using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace screenshare3.Models
{
  public class JDAImages
  {

    public int id { get; set; }


    public string ImageBase64 { get; set; }



    public string raknumber { get; set; }

    public DateTime CurrentDate { get; set; }

    public int MaxmumProduct { get; set; }

    public int currentProduct { get; set; }
  }
}
