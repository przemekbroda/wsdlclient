using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Threading.Tasks;

namespace wsdlclient
{
    public class SoapMessageInterceptor : IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            Console.WriteLine(reply);
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var property = new HttpRequestMessageProperty();
            property.Headers["User-Agent"] = "value";
            request.Properties.Add(HttpRequestMessageProperty.Name, property);
            return null;
        }
    }
}
