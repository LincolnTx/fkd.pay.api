using System;
using fkd.pay.api.Filters.ErrorModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace fkd.pay.api.Filters
{
    public class GlobalExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public GlobalExceptionFilterAttribute() { }

        public void OnException(ExceptionContext context)
        {
            context.Result = new BadRequestObjectResult(
                new DefaultError(false, 
                    new ErrorsResponse[]
                    {
                        new ErrorsResponse("188",
                            "An unexpected error occurred",
                            DateTime.Now)
                    }
                )
            );
        }
    }
}