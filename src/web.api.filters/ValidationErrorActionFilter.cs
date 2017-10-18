
/*
     This is a generic validation error action filter .
     It checks if model state is valid or set a bad request response 
     along with the error details.

     Can be used on 
     -> Controller Level 
     -> Action Level 
     -> Global Level 

     This may be a naive example but illustrate the use of action filters .
     Author - Sudhansu Nayak
*/
namespace web.api.filters
{
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using System.Web.Http.ModelBinding;

    public class ValidationErrorActionFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Runs to check whether model state is valid or not .
        /// If not returns bad request (400) along with errors.
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = SetErrorResponse(actionContext.ModelState);
            }
            else
            {
                base.OnActionExecuting(actionContext);
            }

        }

        /// <summary>
        ///  Sets the response to bad request along with the errors as payload
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private HttpResponseMessage SetErrorResponse(ModelStateDictionary state)
        {

            var response = new HttpResponseMessage();
            var errors = state
                   .Where(e => e.Value.Errors.Count > 0)
                   .Select(e => new ValidationError()
                   {
                       Key = e.Key,
                       Message = e.Value.Errors.First().ErrorMessage
                       //exceptions can also be sent but I dont think its a good idea.
                       //Exception = e.Value.Errors.First().Exception

                   }).ToArray();
            response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            response.Content = new ObjectContent<ValidationError[]>(errors, new JsonMediaTypeFormatter());
            return response;
        }
    }
}
