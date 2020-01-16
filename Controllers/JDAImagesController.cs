using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using screenshare3.Models;

namespace screenshare3.Controllers
{
    public class JDAImagesController : ApiController
    {
        private screenshare3Context db = new screenshare3Context();

        // GET: api/JDAImages
        public IQueryable<JDAImages> GetJDAImages()
        {
            return db.JDAImages;
        }

        // GET: api/JDAImages/5
        [ResponseType(typeof(JDAImages))]
        public IHttpActionResult GetJDAImages(int id)
        {
            JDAImages jDAImages = db.JDAImages.Find(id);
            if (jDAImages == null)
            {
                return NotFound();
            }

            return Ok(jDAImages);
        }

        // PUT: api/JDAImages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJDAImages(int id, JDAImages jDAImages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jDAImages.id)
            {
                return BadRequest();
            }

            db.Entry(jDAImages).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JDAImagesExists(id))
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

        // POST: api/JDAImages
        [ResponseType(typeof(JDAImages))]
        public IHttpActionResult PostJDAImages(JDAImages jDAImages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
      try
      {
        jDAImages.CurrentDate = DateTime.Now;
        db.JDAImages.Add(jDAImages);
        db.SaveChanges();
      }
      catch(Exception ex)
      {

      }

            return CreatedAtRoute("DefaultApi", new { id = jDAImages.id }, jDAImages);
        }

        // DELETE: api/JDAImages/5
        [ResponseType(typeof(JDAImages))]
        public IHttpActionResult DeleteJDAImages(int id)
        {
            JDAImages jDAImages = db.JDAImages.Find(id);
            if (jDAImages == null)
            {
                return NotFound();
            }

            db.JDAImages.Remove(jDAImages);
            db.SaveChanges();

            return Ok(jDAImages);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JDAImagesExists(int id)
        {
            return db.JDAImages.Count(e => e.id == id) > 0;
        }
    }
}
