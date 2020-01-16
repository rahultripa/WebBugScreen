using screenshare3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace screenshare3.Controllers
{
  public class ScreenImageInfoController : ApiController
  {
    // POST: api/SiffyCategories
    [ResponseType(typeof(ScreenImageInfo))]
    public IHttpActionResult ImageProcessing(ScreenImageInfo siffyCategory)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      RouteConfig.screenImageInfo = siffyCategory;
      //db.SiffyCategories.Add(siffyCategory);
      //db.SaveChanges();
      //  return Ok();
      return CreatedAtRoute("DefaultApi", new { id = siffyCategory.ID }, siffyCategory);
    }
  }
  }
