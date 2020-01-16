using screenshare3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace screenshare3.Controllers
{
    public class ImageProcessingController : ApiController
    {
    // POST: api/SiffyCategories
    [ResponseType(typeof(ScreenImage))]
    public IHttpActionResult ImageProcessing(ScreenImage siffyCategory)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      RouteConfig.screenImage = siffyCategory;
      //db.SiffyCategories.Add(siffyCategory);
      //db.SaveChanges();
      //  return Ok();
      return CreatedAtRoute("DefaultApi", new { id = siffyCategory.ID }, siffyCategory);
    }
  }
}
