using Forum.Exceptions;

namespace Forum.Middleware
{
        public class ErrorHandlingMiddleware : IMiddleware
        {
            public async Task InvokeAsync(HttpContext context, RequestDelegate next)
            {
                try
                {
                    await next.Invoke(context);
                }
                catch (BadRequestException badRequestException)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync(badRequestException.Message);
                }
                catch (NotFoundException NotFoundException)
                {
                    context.Response.StatusCode = 404;
                    await context.Response.WriteAsync(NotFoundException.Message);
                }
                catch (Exception e)
                {

                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("Something went wrong");
                }
            }
        }
    }



