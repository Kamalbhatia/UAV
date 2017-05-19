

using System.Web.Mvc;
using UAVBusiness.Business;
using UAVBusiness.Common;
using UAVBusiness.Models;
namespace UAV.Web.Controllers
{

    [AdminLoginActionFilter]
    public class AdminPilotController : Controller
    {
        TResponse objTResponse;
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add(int id = 0)
        {
            objTResponse = new UserProfileBusiness().GetByTypeID("Pilot", id);
            return View(objTResponse.ResponsePacket);
        }

        [HttpPost]
        public ActionResult AddUpdate(UserProfileModel objUserProfileModel)
        {
            if (objUserProfileModel.Type == "Pilot")
                objTResponse = new UserProfileBusiness().AddUpdate(objUserProfileModel);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult List()
        {
            objTResponse = new UserProfileBusiness().GetAllByType("Pilot");
            return View(objTResponse.ResponsePacket);
        }

        [HttpGet]
        public ActionResult CustomerList(long Pilotid = 0)
        {
            objTResponse = new AssignedCustomerBusiness().GetByPilot(Pilotid);
            return View(objTResponse.ResponsePacket);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new UserProfileBusiness().DeleteByTypeId("Pilot", id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult ChangeStatus(int id, bool status)
        {
            new UserProfileBusiness().UpdateStatusByTypeId("Pilot", id, status);
            return RedirectToAction("List");
        }

    }
}
