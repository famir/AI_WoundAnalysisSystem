using AI_WoundAnalysisSystem.BLL.BusinessObject;
using AI_WoundAnalysisSystem.BLL.Interface;
using System.Web.Mvc;

namespace AI_WoundAnalysisSystem.Areas.Operator.Controllers
{
    public class OperatorController : Controller
    {
        /// <summary>
        /// manage User Login
        /// </summary>
        private readonly IManageUserLogin _manageUserLogin;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorController"/> class.
        /// </summary>
        public OperatorController()
        {
            this._manageUserLogin = new ManageUserLogin();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorController"/> class
        /// </summary>
        /// <param name="manageUserLogin">manage User Login</param>
        public OperatorController(ManageUserLogin manageUserLogin)
        {
            this._manageUserLogin = manageUserLogin;
        }


        // GET: Operator/Operator
        public ActionResult Index()
        {
            ViewData["PatientCount"] = this._manageUserLogin.GetUserCount();
            return View();
        }

        /// <summary>
        /// Load the tabs of admin details
        /// </summary>
        /// <param name="tab"> indicate which tab</param>
        /// <param name="clientID">client ID</param>
        /// <returns>view of tabs</returns>
        public ActionResult LoadAdminTab(string tab)
        {
            switch (tab)
            {

                case "tabDashboard":
                    {
                        return this.PartialView("Index");
                    }

                case "tabUserProfile":
                    {
                        return this.PartialView("UserProfile");
                    }

                case "tabPatientList":
                    {
                        return this.PartialView("TabPatientList");
                    }

                case "tabRoles":
                    {
                        return this.PartialView("ClientRoles");
                    }

                case "tabStaffTypes":
                    {
                        return this.PartialView("ClientStaffTypes");
                    }

                default:
                    {
                        return this.PartialView("ClientHeadOffice");
                    }
            }
        }

    }
}