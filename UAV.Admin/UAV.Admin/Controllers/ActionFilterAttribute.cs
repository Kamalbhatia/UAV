using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using UAV.Admin.Common;

namespace UAV.Admin.Controllers
{
    public class AdminLoginActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (UserSession.UserId > 0 && UserSession.UserType != "Admin")
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JavaScriptResult() { Script = "window.location = '" + WebConfigurationManager.AppSettings["SiteUrl"] + "Home/Login'" };
                }
                else
                {
                    filterContext.Result = new RedirectResult(WebConfigurationManager.AppSettings["SiteUrl"] + "Home/Login");
                }
            }
        }
    }

    public class PilotLoginActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (UserSession.UserId > 0 && UserSession.UserType != "Pilot")
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JavaScriptResult() { Script = "window.location = '" + WebConfigurationManager.AppSettings["SiteUrl"] + "Home/Login'" };
                }
                else
                {
                    filterContext.Result = new RedirectResult(WebConfigurationManager.AppSettings["SiteUrl"] + "Home/Login");
                }
            }
        }
    }
}