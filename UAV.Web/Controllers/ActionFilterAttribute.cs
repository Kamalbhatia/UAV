using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using UAV.Web.Common;

namespace UAV.Web.Controllers
{
    public class AdminLoginActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (UserSession.UserId > 0 && UserSession.UserType != "Admin" || UserSession.UserType == null)
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

    public class CustomerLoginActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (UserSession.UserId > 0 && UserSession.UserType != "Customer" || UserSession.UserType == null)
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