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
    public class SurveyDetailController : Controller
    {
        TResponse objTResponse = new TResponse();

        [HttpGet]
        public ActionResult Add(int id = 0)
        {
            //objTResponse = new CustomerBusiness().GetAll();

            //ViewBag.CustomerList = (objTResponse.ResponsePacket as List<CustomerModel>).Select(c => new SelectListItem
            //{
            //    Text = c.FName+" "+c.LName,
            //    Value = c.ID.ToString(),
            //    Selected = (c.ID == 0)
            //}).ToList();

            //objTResponse = new CustomerLocationBusiness().GetAll();
            //ViewBag.CustomerLocationList = (objTResponse.ResponsePacket as List<CustomerLocationModel>).Select(c => new SelectListItem
            //{
            //    Text = c.LocationName ,
            //    Value = c.ID.ToString(),
            //    Selected = (c.ID == 0)
            //}).ToList();
            //ViewBag.CustomerList = (objTResponse.ResponsePacket as List<CustomerModel>).Select(c => new SelectListItem
            //{
            //    Text = c.FName + " " + c.LName,
            //    Value = c.ID.ToString(),
            //    Selected = (c.ID == 0)
            //}).ToList();

            objTResponse = new SurveyDetailBusiness().GetByID(id);
            return View(objTResponse.ResponsePacket);
        }

        [HttpPost]
        public ActionResult AddUpdate(SurveyModel objSurveyModel)
        {
            new SurveyDetailBusiness().AddUpdate(objSurveyModel);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult List()
        {
            objTResponse = new SurveyDetailBusiness().GetAll();
            return View(objTResponse.ResponsePacket);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new SurveyDetailBusiness().Delete(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult ChangeStatus(int id, bool status)
        {
            new SurveyDetailBusiness().UpdateStatus(id, status);
            return RedirectToAction("List");
        }

    }
}
