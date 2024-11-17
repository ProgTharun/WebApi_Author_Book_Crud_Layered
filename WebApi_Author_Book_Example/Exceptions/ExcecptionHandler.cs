using Microsoft.AspNetCore.Diagnostics;
using WebApi_Author_Book_Example.Model;

namespace WebApi_Author_Book_Example.Exceptions
{
    public class ExcecptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var response = new ErrorResponse();
            if (exception is UnauthorizedAccessException)
            {
                response.Statuscode = StatusCodes.Status404NotFound;
                response.ExceptionMessage = exception.Message;
                response.Title = "Invalid Input";
            }
            else
            {
                response.Statuscode= StatusCodes.Status500InternalServerError;
                response.ExceptionMessage= exception.Message;
                response.Title = "Something went worng";
            }
            await httpContext.Response.WriteAsJsonAsync(response,cancellationToken);
            return true;


           
        }
    }
}
