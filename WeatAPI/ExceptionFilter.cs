using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using WeatAPImodels;

namespace WeatAPI
{
    public class ExceptionFilter:IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            RetModels ret = new RetModels();
            ret.code = 0;
            ret.message = "接口出错";
            string errRet = Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            if (context.ExceptionHandled == false)
            {
                context.Result = new ContentResult
                {
                    Content = errRet,
                    StatusCode = StatusCodes.Status200OK,
                    ContentType = "application/json"
                };
            }
            context.ExceptionHandled = true;
        }
        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;
        }
    }
}
