using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.api.middlewares;
using web.api.middlewares.options;

namespace owin
{
    public static class ClientValidationMiddlewareExtension
    {

        public static void UseClientValidationMiddleware(this IAppBuilder app , 
            ClientValidationMiddlewareOptions options) {

            app.Use<ClientValidationMiddleware>(options);
        }
    }
}
