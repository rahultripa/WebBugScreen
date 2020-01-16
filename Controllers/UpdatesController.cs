using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Collections.Concurrent;
using System.Web.Services.Description;
using Newtonsoft.Json;

namespace screenshare3.Controllers
{
  public class Message
  {
    public string username { get; set; }
    public string text { get; set; }
    public string dt { get; set; }
  }

  public class Update
  {
    public string Status { get; set; }

    public DateTime Date { get; set; }
  }
  public class UpdatesController : ApiController
    {

    private static readonly ConcurrentQueue<StreamWriter> _streammessage = new ConcurrentQueue<StreamWriter>();

    public HttpResponseMessage Get(HttpRequestMessage request)
    {
      HttpResponseMessage response = request.CreateResponse();
      response.Content = new PushStreamContent(OnStreamAvailable, "text/event-stream");
      return response;
    }

    private static void OnStreamAvailable(Stream arg1, HttpContent arg2, TransportContext arg3)
    {
      //throw new NotImplementedException();
      StreamWriter streamwriter = new StreamWriter(arg1);
      _streammessage.Enqueue(streamwriter);
    }

    public void Post(Message m)
    {
      m.dt = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
      MessageCallback(m);
    }

    public static void OnStreamAvailable(Stream stream, HttpContentHeaders headers, TransportContext context)
    {
      StreamWriter streamwriter = new StreamWriter(stream);
      _streammessage.Enqueue(streamwriter);
    }

    private static void MessageCallback(Message m)
    {
      foreach (var subscriber in _streammessage)
      {
        subscriber.WriteLine("data:" + JsonConvert.SerializeObject(m) + "\n");
        subscriber.Flush();
      }
    }
    static readonly Dictionary<Guid, Update> updates = new Dictionary<Guid, Update>();

    [HttpPost]
    [ActionName("Complex")]
    //public HttpResponseMessage PostComplex(Update update)
    //{
    //  if (ModelState.IsValid && update != null)
    //  {
    //    // Convert any HTML markup in the status text.
    //    // update.Status = HttpUtility.HtmlEncode(update.Status);

    //    // Assign a new ID.
    //    var path = @"C:\Users\1025642\source\repos\screenShare\screenshare3\Views\Jda.cshtml";
    //   // var response = new HttpResponseMessage();
    //  //  response.Content = new StringContent(File.ReadAllText(path));
    //    var response = new HttpResponseMessage(HttpStatusCode.Created)
    //    {
    //      Content = new StringContent(File.ReadAllText(path))
    //    };
    //    response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
    //    response.Headers.Location =
    //               new Uri(Url.Link("DefaultApi", new { action = "status", id = "" }));
    //    //response.Headers.Location = new Uri(Url.Link("https://localhost:44308/BugView/", new { action = "status", bugid = update.Status }));
    //    return response;
    //    //var id = Guid.NewGuid();
    //    //updates[id] = update;

    //    //// Create a 201 response.
    //    //var response = new HttpResponseMessage(HttpStatusCode.Created)
    //    //{
    //    //  Content = new StringContent(update.Status)
    //    //};
    //    //response.Headers.Location =
    //    //    new Uri(Url.Link("DefaultApi", new { action = "status", id = id }));
    //    //return response;
    //  }
    //  else
    //  { 
    //   return Request.CreateResponse(HttpStatusCode.BadRequest);
    //  }
    //}

    [HttpGet]
    public Update Status(Guid id)
    {
      Update update;
      if (updates.TryGetValue(id, out update))
      {
        return update;
      }
      else
      {
        throw new HttpResponseException(HttpStatusCode.NotFound);
      }
    }
  }
}
