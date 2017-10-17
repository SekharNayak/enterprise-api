using System;

namespace web.api.middlewares.options
{
    public class ClientValidationMiddlewareOptions
    {
        
        public Predicate<string> validateHandler { get; set; }
        public string errorMessage { get; set; }
        public  int errorCode { get; set; }
                
    }
}