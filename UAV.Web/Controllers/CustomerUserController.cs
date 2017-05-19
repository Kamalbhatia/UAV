

using System.Web.Mvc;
using UAVBusiness.Business;
using UAVBusiness.Common;
namespace UAV.Web.Controllers
{

    [CustomerLoginActionFilter]
    public class CustomerUserController : Controller
    {
        TResponse objTResponse;
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpGet]
        public ActionResult SurveyList()
        {
            objTResponse = new SurveyDetailBusiness().GetSurveyList(0);
            return View(objTResponse.ResponsePacket);
        }
    }
}
