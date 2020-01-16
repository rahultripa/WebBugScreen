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
    public class JDADebugInfoesController : ApiController
    {
        private screenshare3Context db = new screenshare3Context();
    private static  ConcurrentQueue<StreamWriter> _streammessage1= new ConcurrentQueue<StreamWriter>();

    // GET: api/JDADebugInfoes
    //public IQueryable<JDADebugInfo> GetJDADebugInfoes()
    //{
    //    return db.JDADebugInfoes;
    //}

    public  HttpResponseMessage Get(HttpRequestMessage request)
    {
      HttpResponseMessage response = request.CreateResponse();
      response.Content = new PushStreamContent(OnStreamAvailable, "text/event-stream");
      _streammessage1 = new ConcurrentQueue<StreamWriter>();
      return response;
    }
    private  static void OnStreamAvailable(Stream arg1, HttpContent arg2, TransportContext arg3)
    {
      // throw new NotImplementedException();

      StreamWriter streamwriter = new StreamWriter(arg1);
      _streammessage1.Enqueue(streamwriter);
    }

    // GET: api/JDADebugInfoes/5
    [ResponseType(typeof(JDADebugInfo))]
        public IHttpActionResult GetJDADebugInfo(int id)
        {
            JDADebugInfo jDADebugInfo = db.JDADebugInfoes.Find(id);
            if (jDADebugInfo == null)
            {
                return NotFound();
            }

            return Ok(jDADebugInfo);
        }

        // PUT: api/JDADebugInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJDADebugInfo(int id, JDADebugInfo jDADebugInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jDADebugInfo.ID)
            {
                return BadRequest();
            }

            db.Entry(jDADebugInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JDADebugInfoExists(id))
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

        // POST: api/JDADebugInfoes
        [ResponseType(typeof(JDADebugInfo))]
        public IHttpActionResult PostJDADebugInfo(JDADebugInfo jDADebugInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
               jDADebugInfo.CurrentDate = DateTime.Now;

             db.JDADebugInfoes.Add(jDADebugInfo);
            db.SaveChanges();
      MessageCallback(jDADebugInfo);
      return CreatedAtRoute("DefaultApi", new { id = jDADebugInfo.ID }, jDADebugInfo);
        }

        // DELETE: api/JDADebugInfoes/5
        [ResponseType(typeof(JDADebugInfo))]
        public IHttpActionResult DeleteJDADebugInfo(int id)
        {
            JDADebugInfo jDADebugInfo = db.JDADebugInfoes.Find(id);
            if (jDADebugInfo == null)
            {
                return NotFound();
            }

            db.JDADebugInfoes.Remove(jDADebugInfo);
            db.SaveChanges();

            return Ok(jDADebugInfo);
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
      StreamWriter streamwriter = new StreamWriter(stream);
      _streammessage1.Enqueue(streamwriter);
    }

    private static async void MessageCallback(JDADebugInfo jDADebugInfo)
    {
      foreach (var subscriber in _streammessage1)
      {
        try
        {

        
        await subscriber.WriteLineAsync("data:" + Newtonsoft.Json.JsonConvert.SerializeObject(jDADebugInfo) + "\n");
        
        await subscriber.FlushAsync();

        subscriber.Dispose();
      }


        catch (Exception)
      {
        StreamWriter ignore;
        // subscriber.(out ignore);
      }
      //   subscriber.Close();
    }
    }

    private bool JDADebugInfoExists(int id)
        {
            return db.JDADebugInfoes.Count(e => e.ID == id) > 0;
        }
    }
}
