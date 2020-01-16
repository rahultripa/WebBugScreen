using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using screenshare3.Models;

namespace screenshare3.Controllers
{
    public class JDADebugActivityInfoesController : ApiController
    {
    private static  ConcurrentQueue<StreamWriter> _streammessage = new ConcurrentQueue<StreamWriter>();

    private screenshare3Context db = new screenshare3Context();

        // GET: api/JDADebugActivityInfoes
      
    public  HttpResponseMessage Get(HttpRequestMessage request)
    {
      HttpResponseMessage response = request.CreateResponse();
      response.Content = new PushStreamContent(OnStreamAvailable, "text/event-stream");
      _streammessage = new ConcurrentQueue<StreamWriter>();
      // logexception1("Pandey", "Get");

      return response;
    }

    private static void OnStreamAvailable(Stream arg1, HttpContent arg2, TransportContext arg3)
    {
      // throw new NotImplementedException();
     //try { 
      StreamWriter streamwriter = new StreamWriter(arg1);
      _streammessage.Enqueue(streamwriter);
      //}
      //catch (Exception ex) {
      //  logexception(ex, "OnStreamAvailable");
      //}
    }

    // GET: api/JDADebugActivityInfoes/5
    [ResponseType(typeof(JDADebugActivityInfo))]
        public IQueryable<JDADebugActivityInfo> GetJDADebugActivityInfo(int id)
        {
      //var jDADebugActivityInfo = db.JDADebugActivityInfoes.Where(c=>c.BugId==id);
      // if (jDADebugActivityInfo == null)
      // {
      //   //  return NotFound();
      // }
      string path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/");

            var filePath = path + "output-" + id + ".json";// @"C:\Users\grahamo\Documents\Visual Studio 2013\Projects\WebApplication1\WebApplication1\bin\path.json";
            if (!File.Exists(filePath))
            {
       // return NotFound();
        //File.Create(filePath).Close();

          }
            // var jsonData = System.IO.File.ReadAllText(path + "output-" + jDADebugActivityInfo.BugId + ".json", jsondata);
            // De-serialize to object or create new list
            var jsonData = System.IO.File.ReadAllText(filePath);
             var employeeList = JsonConvert.DeserializeObject<List<JDADebugActivityInfo>>(jsonData)
                                  ?? new List<JDADebugActivityInfo>();

             return employeeList.AsQueryable(); ;
        }

        // PUT: api/JDADebugActivityInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJDADebugActivityInfo(int id, JDADebugActivityInfo jDADebugActivityInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jDADebugActivityInfo.ID)
            {
                return BadRequest();
            }

            db.Entry(jDADebugActivityInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JDADebugActivityInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/JDADebugActivityInfoes
        [ResponseType(typeof(JDADebugActivityInfo))]
        public IHttpActionResult PostJDADebugActivityInfo(JDADebugActivityInfo jDADebugActivityInfo)
        {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      MessageCallback(jDADebugActivityInfo);
      jDADebugActivityInfo.CurrentDate = DateTime.Now;
      //db.JDADebugActivityInfoes.Add(jDADebugActivityInfo);
      //db.SaveChanges();

      //  _streammessage.TryDequeue();
      // var objjDADebugActivityInfo = new JDADebugActivityInfo();
      //var jsondata = JsonConvert.SerializeObject(jDADebugActivityInfo);
      string path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/");
      // Write that JSON to txt file,  
      // System.IO.File.AppendAllText(path + "output-"+jDADebugActivityInfo.BugId+".json", jsondata);
      //var emptyNs = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
      //string path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/jDADebugActivityInfo.xml");
      //XmlSerializer xs = new XmlSerializer(typeof(JDADebugActivityInfo));

      //TextWriter tw = new StreamWriter(path,true);
      //xs.Serialize(tw, jDADebugActivityInfo,emptyNs);
      var filePath = path + "output-" + jDADebugActivityInfo.BugId + ".json";// @"C:\Users\grahamo\Documents\Visual Studio 2013\Projects\WebApplication1\WebApplication1\bin\path.json";
      if (!File.Exists(filePath))
      {
        File.Create(filePath).Close();

      }
      // var jsonData = System.IO.File.ReadAllText(path + "output-" + jDADebugActivityInfo.BugId + ".json", jsondata);
      // De-serialize to object or create new list
      var jsonData = System.IO.File.ReadAllText(filePath);
      var employeeList = JsonConvert.DeserializeObject<List<JDADebugActivityInfo>>(jsonData)
                            ?? new List<JDADebugActivityInfo>();

      // Add any new employees
      employeeList.Add(jDADebugActivityInfo);
     

      // Update json data string
      jsonData = JsonConvert.SerializeObject(employeeList);
      System.IO.File.WriteAllText(filePath, jsonData);
      return CreatedAtRoute("DefaultApi", new { id = jDADebugActivityInfo.ID }, jDADebugActivityInfo);
        }

        // DELETE: api/JDADebugActivityInfoes/5
        [ResponseType(typeof(JDADebugActivityInfo))]
        public IHttpActionResult DeleteJDADebugActivityInfo(int id)
        {
            JDADebugActivityInfo jDADebugActivityInfo = db.JDADebugActivityInfoes.Find(id);
            if (jDADebugActivityInfo == null)
            {
                return NotFound();
            }

            db.JDADebugActivityInfoes.Remove(jDADebugActivityInfo);
            db.SaveChanges();

            return Ok(jDADebugActivityInfo);
        }

    private static void logexception1(string ex, string functionname)
    {
      string path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/log.txt");
      string someText = ex + "" + functionname;
      using (StreamWriter sw = File.AppendText(path))
      {
        sw.WriteLine(someText);

      }

    }
    private static void logexception(Exception ex ,string functionname)
    {
      string path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/log.txt");

      string someText = ex.Message + "" + functionname;
      using (StreamWriter sw = File.AppendText(path))
      {
        sw.WriteLine(someText);
       
      }
           
      
    }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    public static void OnStreamAvailable(Stream stream, HttpContentHeaders headers, TransportContext context)
    {
   //   try { 
      StreamWriter streamwriter = new StreamWriter(stream);
      _streammessage.Enqueue(streamwriter);
      //    }
      //catch (Exception ex) {
      //  logexception(ex, "OnStreamAvailable");
      //   }
       }

    private static async void MessageCallback(JDADebugActivityInfo jDADebugActivityInfo)
    {
     // try {
        foreach (var subscriber in _streammessage)
        {
        try { 
        await subscriber.WriteLineAsync("data:" + JsonConvert.SerializeObject(jDADebugActivityInfo) + "\n");

        await subscriber.FlushAsync();

        subscriber.Dispose();
      }


        catch (Exception)
      {
        StreamWriter ignore;
        // subscriber.(out ignore);
      }
    }
        //  throw new NullReferenceException("Student object is null.");
    //  }
    //  catch (Exception ex) {
    //    logexception(ex, "OnStreamAvailable");
    //}
  }


    private bool JDADebugActivityInfoExists(int id)
        {
            return db.JDADebugActivityInfoes.Count(e => e.ID == id) > 0;
        }
    }
}
