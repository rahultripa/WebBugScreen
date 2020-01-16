using Newtonsoft.Json;
using screenshare3.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace screenshare3.Controllers
{
    public class JdaLiveController : ApiController
    {
    private static readonly ConcurrentQueue<StreamWriter> _streammessage = new ConcurrentQueue<StreamWriter>();

    public HttpResponseMessage Get(HttpRequestMessage request)
    {
      HttpResponseMessage response = request.CreateResponse();
      response.Content = new PushStreamContent(OnStreamAvailable, "text/event-stream");
      return response;
    }

    private void OnStreamAvailable(Stream arg1, HttpContent arg2, TransportContext arg3)
    {
      // throw new NotImplementedException();

      StreamWriter streamwriter = new StreamWriter(arg1);
      _streammessage.Enqueue(streamwriter);
    }

    public void Post(JDADebugActivityInfo jDADebugActivityInfo)
    {
      jDADebugActivityInfo.CurrentDate = DateTime.Now;
     // m.log = "jyoti";
      MessageCallback(jDADebugActivityInfo);
    }

    public static void OnStreamAvailable(Stream stream, HttpContentHeaders headers, TransportContext context)
    {
      StreamWriter streamwriter = new StreamWriter(stream);
      _streammessage.Enqueue(streamwriter);
    }

    private static void MessageCallback(JDADebugActivityInfo jDADebugActivityInfo)
    {
      foreach (var subscriber in _streammessage)
      {
        subscriber.WriteLine("data:" + JsonConvert.SerializeObject(jDADebugActivityInfo) + "\n");
        subscriber.Flush();
      }
    }
  }
}
