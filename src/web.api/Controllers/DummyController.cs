using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace web.api.Controllers
{
    public class DummyController : ApiController
    {
        [Route("api/dummy")]
        public IHttpActionResult Get() {

            return Ok("A dummy value .. just to check api is running ...");
        }
    }
}
