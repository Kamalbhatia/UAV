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
    public class DroneEquipmentController : Controller
    {
        TResponse objTResponse = new TResponse();

        [HttpGet]
        public ActionResult Add(int id = 0)
        {
            objTResponse = new DroneEquipmentBusiness().GetByID(id);
            return View(objTResponse.ResponsePacket);
        }

        [HttpPost]
        public ActionResult AddUpdate(DroneEquipmentModel objDroneEquipmentModel)
        {
            new DroneEquipmentBusiness().AddUpdate(objDroneEquipmentModel);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult List()
        {
            objTResponse = new DroneEquipmentBusiness().GetAll();
            return View(objTResponse.ResponsePacket);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new DroneEquipmentBusiness().Delete(id);
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult ChangeStatus(int id, bool status)
        {
            new DroneEquipmentBusiness().UpdateStatus(id, status);
            return RedirectToAction("List");
        }

    }
}
