using LibraryAssistant.API.Extensions;
using LibraryAssistant.Core.Exceptions;
using LibraryAssistant.Core.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

using System.Net;

namespace LibraryAssistant.API.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
       // private readonly ILogService _log;

        public GlobalExceptionFilter()
        {
            //_log = new SerilogService(new SerilogServiceOptions());
        }

        public void OnException(ExceptionContext context)
        {
           // _log.Information($"Error occured. Error details: {context.Exception.Message}, Stack Trace: {context.Exception.StackTrace}, Inner Exception Details: " + (context.Exception.InnerException == null ? context.Exception.Message : context.Exception.InnerException.Message));
            var content = GetStatusCode<object>(context.Exception);
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)content.Item2;
            response.ContentType = "application/json";

            context.Result = new JsonResult(content.Item1);
        }

        public static (Response<T>, HttpStatusCode) GetStatusCode<T>(Exception exception)
        {

            switch (exception)
            {
                case BaseException bex:
                    return (new Response<T>
                    {
                        Message = bex.GetInnerMessage(),
                        Succeeded = false,
                    }, bex.httpStatusCode);
                default:
                    return (new Response<T>
                    {
                        Message = exception.GetInnerMessage(),
                        Succeeded = false
                    }, HttpStatusCode.InternalServerError);
            }
        }
    }

}
