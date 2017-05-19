
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UAV.Web.Common;
using UAVBusiness.Business;
using UAVBusiness.Common;
using UAVBusiness.Models;

namespace UAV.Web.Controllers
{

    [AdminLoginActionFilter]
    public class AdminCustomerLocationController : Controller
    {
        TResponse objTResponse;
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add(int id = 0)
        {
            objTResponse = new CustomerLocationBusiness().GetByID(id);

            TResponse objTResponse_ = new UserProfileBusiness().GetAllUserByType("Customer");

            ViewBag.CustomerList = (objTResponse_.ResponsePacket as List<UserProfileModel>).Select(c => new SelectListItem
            {
                Text = c.FName + " " + c.LName,
                Value = c.UserId.ToString(),
                Selected = (c.UserId ==(id==0?0:(objTResponse.ResponsePacket as CustomerLocationModel).CustomerID))
            }).ToList();




            return View(objTResponse.ResponsePacket);
        }

        [HttpPost]
        public ActionResult AddUpdate(CustomerLocationModel objCustomerLocationModel)
        {
            objTResponse = new CustomerLocationBusiness().AddUpdate(objCustomerLocationModel);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult List()
        {
            objTResponse = new CustomerLocationBusiness().GetAll();
            return View(objTResponse.ResponsePacket);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new CustomerLocationBusiness().Delete(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult ChangeStatus(int id, bool status)
        {
            new CustomerLocationBusiness().UpdateStatus(id, status);
            return RedirectToAction("List");
        }

    }

   
}
