using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CaseStudy.Infrastructure
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                var exceptionDetail = GetExceptionDetail(exception);
                _logger.LogError("An error occurred at this address. Path:{0} Error:{1}", context.Request.Path, exceptionDetail.Item2);
                context.Response.StatusCode = exceptionDetail.Item1;
                await context.Response.WriteAsync(exceptionDetail.Item2);
            }
        }

        private static Tuple<int, string> GetExceptionDetail(Exception exception)
        {
            Tuple<int, string> exceptionDetail = exception switch
            {
                var _ when exception is ValidationException => new Tuple<int, string>((int)HttpStatusCode.BadRequest, exception.Message),
                var _ when exception is ArgumentException => new Tuple<int, string>((int)HttpStatusCode.NotFound, exception.Message),
                _ => new Tuple<int, string>((int)HttpStatusCode.InternalServerError, exception.Message),
            };
            return exceptionDetail;
        }
    }
}