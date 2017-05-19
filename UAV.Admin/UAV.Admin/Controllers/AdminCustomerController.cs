using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UAV.Admin.Filters;
using UAVBusiness.Business;
using UAVBusiness.Common;
using UAVBusiness.Models;

namespace UAV.Admin.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AdminCustomerController : Controller
    {
        TResponse objTResponse = new TResponse();

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
         
            return View();
        }
        [HttpPost]
        public ActionResult Login(CustomerLoginModel objCustomerLoginModel)
        {

            return View(objCustomerLoginModel);
        }
        [HttpGet]
        public ActionResult Index()
        {
          
            return View();
        }

    }
}
