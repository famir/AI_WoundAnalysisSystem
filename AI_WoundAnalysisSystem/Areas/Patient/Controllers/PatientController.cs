using AI_WoundAnalysisSystem.BLL.BusinessObject;
using AI_WoundAnalysisSystem.BLL.BusinessObject.Common;
using AI_WoundAnalysisSystem.BLL.Interface;
using AI_WoundAnalysisSystem.DTO;
using AI_WoundAnalysisSystem.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace AI_WoundAnalysisSystem.Areas.Patient.Controllers
{
    public class PatientController : Controller
    {
        private readonly IManageUserLogin _manageUserLogin;
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
                        Users patientDetails = this._managePatient.GetPatientDetails(Int32.Parse(this.Session["UserId"].ToString()));
                        return this.PartialView("Profile",patientDetails);
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
            var returnResult ="";
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

        public ActionResult DeletePatient(string id)
        {
            int userId = Convert.ToInt32(id);
            var deleted = this._managePatient.DeleteByUserId(userId);

            if (!deleted)
            {
                userId = -1;
            }
            return this.Json(userId, JsonRequestBehavior.AllowGet);

        }

        public ActionResult SendStatus(string id, string operation)
        {
            int userId = Convert.ToInt32(id);
            var deleted = this._managePatient.SendStatus(userId, operation);

            if (!deleted)
            {
                userId = -1;
            }
            return this.Json(userId, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        //[DeleteFileAttribute] //Action Filter, it will auto delete the file after download, 
        //I will explain it later
        public ActionResult Download(string fileName)
        {
            string contentType = "application/pdf";
            //get the temp folder and file path in server
            //string fullPath = Path.Combine(Server.MapPath("~/temp"), filePath);
            string filePath = HttpContext.Server.MapPath("~/UserData/PatientDoc//" + fileName);
            //return the file for download, this is an Excel 
            //so I set the file content type to "application/vnd.ms-excel"

            if (contentType.Contains("png"))
            {
                contentType = "application/png";
            }
            else if (contentType.Contains("jpg"))
            {
                contentType = "application/jpg";
            }
            return File(filePath, contentType, fileName);
        }

        public ActionResult SavePatientPhoto(HttpPostedFileBase PHOTO)
        {
            var response = "";
            if (this.Session["UserRoleCode"] != null)
            {
                string path = "";
                string newImageName = Guid.NewGuid().ToString() + "-" + Path.GetFileName(PHOTO.FileName);
                if (PHOTO != null)
                    path = HttpContext.Server.MapPath("~//Images//PatientImage//" + newImageName);

                if (PHOTO != null)
                    PHOTO.SaveAs(path);

                int userId = Int32.Parse(this.Session["UserId"].ToString());

                var userDetails=  this._managePatient.SavePatientPhoto(userId, newImageName);
                response = path;
            }
            else
            {
                response = "-1"; 
            } 
            return Json(Response, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddWound(Wound model)
        {
            var response = "";
            if (this.Session["UserRoleCode"] != null)
            {
                // Wound wound = this._managePatient.SavePatientPhoto(userId, newImageName); 
                 
                AddWoundImage(model.OriginalImage,"original",1);
                AddWoundImage(model.SecondImage, "second", 1);
                AddWoundImage(model.EdgeDetectedImage, "edge", 1);

            }
            else
            {
                response = "-1";
            }
            return Json(response);
        }

        public void AddWoundImage(string imageData, string type, int woundId)
        {
            string path = "";
              switch (type)
            {
                case "original":
                    path = HttpContext.Server.MapPath("~//Images//PatientWoundImage////OriginalWoundImage//" + woundId);
                    break;
                case "second":
                    path = HttpContext.Server.MapPath("~//Images//PatientWoundImage////SecondWoundImage//" + woundId);
                    break;
                case "edge":
                    path = HttpContext.Server.MapPath("~//Images//PatientWoundImage////EdgeDetectedWoundImage//" + woundId);
                    break;
            }
            string fileNameWitPath = path + DateTime.Now.ToString().Replace("/", "-").Replace(" ", "- ").Replace(":", "") + ".png";
            
            using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();
                }
            }
        }

        // GET: Patient/Patient
        public ActionResult PatientRegister()
        {
            PatientVM patientDetails = new PatientVM();
            return PartialView("PatientRegisterPV", patientDetails);
        }

        public ActionResult RegisterPatientDetails(PatientVM details)
        {
            if (details != null && details.DocumentUpload != null)
            {
                string path = "";
                string newImageName = DateTime.Now.Day + "_" + Path.GetFileName(details.DocumentUpload.FileName);
                path = HttpContext.Server.MapPath("~/UserData/PatientDoc//" + newImageName);
                details.DocumentUpload.SaveAs(path);
                details.DocumentPath = newImageName;
            }
            var userDetails = this._managePatient.RegisterPatientDetails(details);
            if (userDetails)
            {

                this.TempData["SucessAlert"] = "1";
            }
            else
            {
                this.TempData["SucessAlert"] = "0";
            }

            return RedirectToAction("Index", "Home", new
            {
                Area = "",
                message = this.TempData["SucessAlert"]
            });
        }
    }
}