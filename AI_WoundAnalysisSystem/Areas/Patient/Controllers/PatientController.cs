using AI_WoundAnalysisSystem.BLL.BusinessObject;
using AI_WoundAnalysisSystem.BLL.Interface;
using AI_WoundAnalysisSystem.DTO.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AI_WoundAnalysisSystem.Areas.Patient.Controllers
{
    public class PatientController : Controller
    {

        /// <summary>
        /// manage Employee
        /// </summary>
        private readonly IManagePatient _managePatient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientController"/> class.
        /// </summary>
        public PatientController()
        {
            this._managePatient = new ManagePatient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientController"/> class
        /// </summary>
        /// <param name="manageEmployee">manage Employee</param>
        public PatientController(ManagePatient managePatient)
        {
            this._managePatient = managePatient;
        }


        // GET: Patient/Patient
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Load the tabs of patient 
        /// </summary>
        /// <param name="tab"> indicate which tab</param>
        /// <returns>view of tabs</returns>
        public ActionResult LoadPatientTab(string tab)
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

                case "tabEmployeeList":
                    {
                        return this.PartialView("TabEmployeeList");
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

        /// <summary>
        ///  Get all patient
        /// </summary>
        /// <returns>returns patient list</returns>
        public ActionResult GetPatientList()
        {
            List<PatientListingVM> patientList = new List<PatientListingVM>();

            if (this.Session["UserRole"] != null)
            {
                patientList = this._managePatient.GetAllPatientByRole(this.Session["UserRole"].ToString());
            }

            return Json(new { rows = patientList }, JsonRequestBehavior.AllowGet);
        }
    }
}