using Hangfire.Dashboard;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpodIgly.Infrastructure
{
    public class MyAuthorizationFilter : IDashboardAuthorizationFilter
    {

        public bool Authorize(DashboardContext context)
        {
            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                return true;
            }

            return false;
        }

    }
}