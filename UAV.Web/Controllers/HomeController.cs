using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UAV.Web.Common;
using UAVBusiness.Business;
using UAVBusiness.Common;
using UAVBusiness.Models;

namespace UAV.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login(string returnUrl)
        {
            UserSession.UserId = 0;
            UserSession.UserType = null;
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
                        UserSession.UserName = objUserProfileModel.FName + " " + objUserProfileModel.LName;

                        return RedirectToAction("Index", "AdminPilot");
                    }
                    else if (objUserProfileModel != null && objUserProfileModel.Type == "Customer")
                    {
                        UserSession.UserId = objUserProfileModel.UserId;
                        UserSession.UserType = objUserProfileModel.Type;
                        UserSession.UserName = objUserProfileModel.FName + " " + objUserProfileModel.LName;
                        return RedirectToAction("Index", "CustomerUser");
                    }
                }



            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            UserSession.UserName = null;
            UserSession.UserId = 0;
            UserSession.UserType = null;
            return RedirectToAction("Login", "Home");
        }

    }
}