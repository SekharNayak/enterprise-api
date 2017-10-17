/*
    This middleware validates client id for request .
    If request does not contain the custom header x-client-id .Returns X-Error-Message.
    If it has the custom header  but not valid entry then  return 435 (client id not valid).
    -- Sudhansu Nayak
 */

namespace web.api.middlewares
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>,
        System.Threading.Tasks.Task>;
    using Microsoft.Owin;
    using options;
    public class ClientValidationMiddleware
    {
        private const string x_client_id = "X-client-id";
        private const string x_error_message = "X-error-message";
        AppFunc _next;
        ClientValidationMiddlewareOptions _options;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="validateHandler"></param>
        /// <param name="errorMessage"></param>
        /// <param name="errorCode"></param>
        public ClientValidationMiddleware(AppFunc next, ClientValidationMiddlewareOptions options)
        {
            this._next = next;
            if (options == null)
                throw new ArgumentNullException("options can not be null");

            if (options.validateHandler == null)
                throw new ArgumentNullException("handler can not be null");

            this._options = options;

        }

        public async Task Invoke(IDictionary<string, object> envoirnment)
        {
            var context = new OwinContext(envoirnment);
            string[] headersList;
            context.Request.Headers.TryGetValue(x_client_id, out headersList);
            if (headersList != null && headersList.Length > 0)
            {
                var value = headersList.FirstOrDefault();
                if (!string.IsNullOrEmpty(value))
                {

                    if (_options.validateHandler(value))
                    {
                        await _next.Invoke(envoirnment);
                    }
                    else
                    {
                        context.Response.OnSendingHeaders((state) =>
                        {
                            var resp = (OwinResponse)state;
                            resp.Headers.Add(x_error_message, new string[]{
                        $" {_options.errorCode} : {_options.errorMessage} "
                        });
                            resp.StatusCode = 401;
                            resp.ReasonPhrase = "UnAuthorized";

                        }, context.Response);
                    }


                }
                else
                {
                    context.Response.OnSendingHeaders((state) =>
                    {
                        var resp = (OwinResponse)state;
                        resp.Headers.Add(x_error_message, new string[]{
                        $" {_options.errorCode} : {_options.errorMessage} "
                        });
                        resp.StatusCode = 401;
                        resp.ReasonPhrase = "UnAuthorized";

                    }, context.Response);
                }

            }
            else
            {
                context.Response.OnSendingHeaders((state) =>
                {
                    var resp = (OwinResponse)state;
                    resp.Headers.Add(x_error_message, new string[]{
                        $" {_options.errorCode} : {_options.errorMessage} "
                        });
                    resp.StatusCode = 401;
                    resp.ReasonPhrase = "UnAuthorized";

                }, context.Response);

            }
           // await _next.Invoke(envoirnment);
        }
    }
}
