using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using DergiAboneTakip.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DergiAboneTakip.Filter
{
    public class UserFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userId = context.HttpContext.Session.GetInt32("id");

            if (!userId.HasValue)
            {

                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {

                    { "action","UyeGiris" },
                    { "controller","Account" }

                });

            }
            base.OnActionExecuting(context);

        }
    }
}
