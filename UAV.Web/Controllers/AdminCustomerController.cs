

using System.Web.Mvc;
using UAVBusiness.Business;
using UAVBusiness.Common;
using UAVBusiness.Models;
namespace UAV.Web.Controllers
{

    [AdminLoginActionFilter]
    public class AdminCustomerController : Controller
    {
        TResponse objTResponse;
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add(int id = 0)
        {
            objTResponse = new UserProfileBusiness().GetByTypeID("Customer",id);
            return View(objTResponse.ResponsePacket);
        }

        [HttpPost]
        public ActionResult AddUpdate(UserProfileModel objUserProfileModel)
        {
            if (objUserProfileModel.Type=="Customer")
            objTResponse = new UserProfileBusiness().AddUpdate(objUserProfileModel);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult List()
        {
            objTResponse = new UserProfileBusiness().GetAllByType("Customer");
            return View(objTResponse.ResponsePacket);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            new UserProfileBusiness().DeleteByTypeId("Customer",id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult ChangeStatus(int id, bool status)
        {
            new UserProfileBusiness().UpdateStatusByTypeId("Customer",id, status);
            return RedirectToAction("List");
        }

    }
}
