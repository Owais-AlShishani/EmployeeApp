namespace EmployeeApp
{
    public class GlobalErrorHandling : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }

            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                Console.WriteLine($"Error: {error.Message}");
                Console.WriteLine($"Error Details: {context.Request.Path}");

                await response.WriteAsync("Error");
            }
        }
    }
}
