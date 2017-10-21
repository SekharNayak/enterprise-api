using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace web.api.formatters
{
    public class JsonpFormatter : MediaTypeFormatter
    {
        const string Jsonp_Media_Type = "Application/JSONP";
        public JsonpFormatter()
        {
            this.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue(Jsonp_Media_Type));
        }
        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {

            return true;
        }

        public override Task WriteToStreamAsync(Type type, object value, 
            Stream writeStream, HttpContent content, TransportContext transportContext)
        {

            return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
        }
    }
}
