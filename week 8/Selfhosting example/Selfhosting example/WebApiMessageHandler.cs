using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selfhosting_example
{
    public class WebApiMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var task = new Task<HttpResponseMessage>(() =>
              {
                  HttpResponseMessage message = new HttpResponseMessage();
                  message.Content = new StringContent("I am a response");
                  return message;
              });
            task.Start();
            return task;
        }
    }
}
