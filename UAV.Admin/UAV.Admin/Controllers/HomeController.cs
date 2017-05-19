using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UAV.Admin.Common;
using UAV.Admin.Common;
using UAVBusiness.Business;
using UAVBusiness.Common;
using UAVBusiness.Models;

namespace UAV.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login(string returnUrl)
        {

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                TResponse objTResponse = new UserProfileBusiness().UserProfileLogin(model);
                if (objTResponse.ResponsePacket != null)
                {
                    UserProfileModel objUserProfileModel = objTResponse.ResponsePacket as UserProfileModel;
                    if (objUserProfileModel != null && objUserProfileModel.Type == "Admin")
                    {
                        UserSession.UserId = objUserProfileModel.UserId;
                        UserSession.UserType = objUserProfileModel.Type;
                        return RedirectToAction("Index", "AdminUser");
                    }
                    else if (objUserProfileModel != null && objUserProfileModel.Type == "User")
                    {
                        UserSession.UserId = objUserProfileModel.UserId;
                        UserSession.UserType = objUserProfileModel.Type;
                        return RedirectToAction("Index", "PilotUser");
                    }
                }



            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }
    
    }
}