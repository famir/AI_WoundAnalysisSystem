using AI_WoundAnalysisSystem.BLL.BusinessObject;
using AI_WoundAnalysisSystem.BLL.BusinessObject.Common;
using AI_WoundAnalysisSystem.BLL.Interface;
using AI_WoundAnalysisSystem.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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

                case "tabProfile":
                    {
                        return this.PartialView("Profile");
                    }

                case "tabTimeline":
                    {
                        return this.PartialView("WoundHealingTimeline");
                    }

                case "tabMedicheck":
                    {
                        return this.PartialView("MediCheck");
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

            if (this.Session["UserRoleCode"] != null)
            {
                patientList = this._managePatient.GetAllPatientByRole(this.Session["UserRoleCode"].ToString());
            }

            return Json(new { rows = patientList }, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// Adds or edits an Patient
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>add or edit view</returns>
        public ActionResult AddOrEditPatient(string id)
        {
            int userId = Convert.ToInt32(id);
            PatientVM patientDetails;
            if (userId == 0)
            {
                patientDetails = new PatientVM();

                return this.PartialView("AddOrEditPatient", patientDetails);
            }
            else
            {
                patientDetails = this._managePatient.GetPatientById(userId);
                return this.PartialView("AddOrEditPatient", patientDetails);
            }

        }


        /// <summary>
        /// Save Patient Details
        /// </summary>
        /// <param name="details">contents in Patient details page</param>
        /// <returns>success message if saved</returns>
        [HttpPost]
        public ActionResult SavePatientDetails(PatientVM details)
        {
            int? result = -1;

            if (details != null)
            {

                var userDetails = this._managePatient.SavePatientDetails(details);

          
                        if (userDetails != null)
                        {
                            if (details.UserID == 0)
                            {
                                this.TempData["SucessAlert"] = "1";
                            }
                            else if (details.UserID > 0)
                            {
                                this.TempData["SucessAlert"] = "2";
                            }
                        }
                        else
                        {
                            this.TempData["SucessAlert"] = "0";
                        }
            



                if (this.Session["UserRoleCode"] != null)
                {
                    if (this.Session["UserRoleCode"].ToString() == Enum.GetName(typeof(CommonClass.UserRole), CommonClass.UserRole.OPTR))
                    {
                        return this.RedirectToAction("Index", "Operator", new { area = "Operator", tab = "PatientList" });
                    }
                    else if (Session["UserRoleCode"].ToString() == Enum.GetName(typeof(CommonClass.UserRole), CommonClass.UserRole.PTNT))
                    {
                        return this.RedirectToAction("Index", "Patient", new { area = "Patient", tab = "PatientList" });
                    }
                }


            }
            return this.RedirectToAction("Index", "Operator", new { area = "Operator", tab = "Dashboard" });
        }
        [HttpGet]
        //[DeleteFileAttribute] //Action Filter, it will auto delete the file after download, 
        //I will explain it later
        public ActionResult Download(string filePath)
        {
            //get the temp folder and file path in server
            string fullPath = Path.Combine(Server.MapPath("~/temp"), filePath);
            string fileName = filePath.Replace("~/UserData/StundennachweisUpload//", "");
            //return the file for download, this is an Excel 
            //so I set the file content type to "application/vnd.ms-excel"
            return File(filePath, "application/vnd.ms-excel", fileName);
        }
    }
}