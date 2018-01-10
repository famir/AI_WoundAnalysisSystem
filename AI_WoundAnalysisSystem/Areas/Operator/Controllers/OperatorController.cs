using AI_WoundAnalysisSystem.BLL.BusinessObject;
using AI_WoundAnalysisSystem.BLL.Interface;
using System.Web.Mvc;

namespace AI_WoundAnalysisSystem.Areas.Operator.Controllers
{
    public class OperatorController : Controller
    {
        private readonly IManageUserLogin _manageUserLogin;
        // GET: Operator/Operator
        public ActionResult Index()
        {
            int userDetails = this._manageUserLogin.CountUser(2); //Patient id is 2 and Operator Id is 1
            ViewBag.UserCount = userDetails;
            return View();
        }
        public OperatorController()
        {
            this._manageUserLogin = new ManageUserLogin();
        }
    }
}