using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DocLibrary.Helper.BaseController
{
    public class WebBaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        public static async Task<long> GetUserId()
        {
            // Load User Id dummy data
            // HttpContext.User.Identity...
            return await Task.FromResult<long>(1);
        }
    }
}
