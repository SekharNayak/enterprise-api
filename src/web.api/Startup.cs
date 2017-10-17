using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using owin;

[assembly: OwinStartup(typeof(web.api.Startup))]

namespace web.api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseClientValidationMiddleware(new middlewares.options.ClientValidationMiddlewareOptions() {

                errorCode = 100,
                errorMessage = "Client Id is needed to access the api .",
                validateHandler = (x)=>{ return true;}
            });


            app.UseWebApi(WebApiConfig.Register());
        }
    }
}
