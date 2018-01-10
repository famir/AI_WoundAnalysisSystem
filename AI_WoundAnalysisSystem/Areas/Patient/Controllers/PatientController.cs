using System.Web.Mvc;

namespace AI_WoundAnalysisSystem.Areas.Patient.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient/Patient
        public ActionResult Index()
        {
            return View();
        }
    }
}