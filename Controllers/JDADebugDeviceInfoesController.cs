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
using screenshare3.Models;

namespace screenshare3.Controllers
{
    public class JDADebugDeviceInfoesController : ApiController
    {
        private screenshare3Context db = new screenshare3Context();
    private static ConcurrentQueue<StreamWriter> _streammessage2 = new ConcurrentQueue<StreamWriter>();


    // GET: api/JDADebugDeviceInfoes
    //public IQueryable<JDADebugDeviceInfo> GetJDADebugDeviceInfoes()
    //{
    //    return db.JDADebugDeviceInfoes;
    //}
    public  HttpResponseMessage Get(HttpRequestMessage request)
    {
      HttpResponseMessage response = request.CreateResponse();
      response.Content = new PushStreamContent(OnStreamAvailable, "text/event-stream");
      _streammessage2 = new ConcurrentQueue<StreamWriter>();
      return response;
    }
    private static void OnStreamAvailable(Stream arg1, HttpContent arg2, TransportContext arg3)
    {
      // throw new NotImplementedException();

      
      StreamWriter streamwriter = new StreamWriter(arg1);
      _streammessage2.Enqueue(streamwriter);
    }
    // GET: api/JDADebugDeviceInfoes/5
    [ResponseType(typeof(JDADebugDeviceInfo))]
        public IHttpActionResult GetJDADebugDeviceInfo(int id)
        {
            JDADebugDeviceInfo jDADebugDeviceInfo = db.JDADebugDeviceInfoes.Where(c=>c.BugId==id).FirstOrDefault();
            if (jDADebugDeviceInfo == null)
            {
                return NotFound();
            }

            return Ok(jDADebugDeviceInfo);
        }

        // PUT: api/JDADebugDeviceInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJDADebugDeviceInfo(int id, JDADebugDeviceInfo jDADebugDeviceInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jDADebugDeviceInfo.ID)
            {
                return BadRequest();
            }

            db.Entry(jDADebugDeviceInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JDADebugDeviceInfoExists(id))
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

        // POST: api/JDADebugDeviceInfoes
        [ResponseType(typeof(JDADebugDeviceInfo))]
        public IHttpActionResult PostJDADebugDeviceInfo(JDADebugDeviceInfo jDADebugDeviceInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             jDADebugDeviceInfo.CurrentDate = DateTime.Now;
            db.JDADebugDeviceInfoes.Add(jDADebugDeviceInfo);
            db.SaveChanges();
      MessageCallback(jDADebugDeviceInfo);

      return CreatedAtRoute("DefaultApi", new { id = jDADebugDeviceInfo.ID }, jDADebugDeviceInfo);
        }
    public static void OnStreamAvailable(Stream stream, HttpContentHeaders headers, TransportContext context)
    {
      StreamWriter streamwriter = new StreamWriter(stream);
      _streammessage2.Enqueue(streamwriter);
    }

    private static async void MessageCallback(JDADebugDeviceInfo jDADebugDeviceInfo)
    {
      foreach (var subscriber in _streammessage2)
      {
        try {
               await subscriber.WriteLineAsync("data:" + Newtonsoft.Json.JsonConvert.SerializeObject(jDADebugDeviceInfo) + "\n");
            await subscriber.FlushAsync();

             subscriber.Dispose();
        }
       
        catch (Exception)
        {
          StreamWriter ignore;
         // subscriber.(out ignore);
        }
     
        //  subscriber.Close();
      }
    }

    // DELETE: api/JDADebugDeviceInfoes/5
    [ResponseType(typeof(JDADebugDeviceInfo))]
        public IHttpActionResult DeleteJDADebugDeviceInfo(int id)
        {
            JDADebugDeviceInfo jDADebugDeviceInfo = db.JDADebugDeviceInfoes.Find(id);
            if (jDADebugDeviceInfo == null)
            {
                return NotFound();
            }

            db.JDADebugDeviceInfoes.Remove(jDADebugDeviceInfo);
            db.SaveChanges();

            return Ok(jDADebugDeviceInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JDADebugDeviceInfoExists(int id)
        {
            return db.JDADebugDeviceInfoes.Count(e => e.ID == id) > 0;
        }
    }
}
