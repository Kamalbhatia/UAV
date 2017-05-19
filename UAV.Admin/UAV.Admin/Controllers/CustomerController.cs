using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UAV.Admin.Filters;
using UAVBusiness.Business;
using UAVBusiness.Common;
using UAVBusiness.Models;
using WebMatrix.WebData;

namespace UAV.Admin.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class CustomerController : Controller
    {
        TResponse objTResponse = new TResponse();

        [HttpGet]
        public ActionResult Add(int id = 0)
        {
            objTResponse = new CustomerBusiness().GetByID(id);
            return View(objTResponse.ResponsePacket);
        }

        [HttpPost]
        public ActionResult AddUpdate(CustomerModel objCustomerModel)
        {
            try
            {
                if (objCustomerModel.ID == 0)
                {
                    WebSecurity.CreateUserAndAccount(objCustomerModel.Email, objCustomerModel.Password);
                    objCustomerModel.UserId = WebSecurity.GetUserId(objCustomerModel.Email);
                   
                }
                new CustomerBusiness().AddUpdate(objCustomerModel);
                return RedirectToAction("List");
            }
            catch (MembershipCreateUserException e)
            {
                ModelState.AddModelError("errorMsg", ErrorCodeToString(e.StatusCode));
                return View("Add");
            }
        }

        [HttpGet]
        public ActionResult List()
        {
            objTResponse = new CustomerBusiness().GetAll();
            return View(objTResponse.ResponsePacket);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new CustomerBusiness().Delete(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult ChangeStatus(int id, bool status)
        {
            new CustomerBusiness().UpdateStatus(id, status);
            return RedirectToAction("List");
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindView(ControllerContext, viewName, null);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }


    }
}
