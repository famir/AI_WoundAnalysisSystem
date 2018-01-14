using AI_WoundAnalysisSystem.BLL.BusinessObject;
using AI_WoundAnalysisSystem.BLL.Interface;
using AI_WoundAnalysisSystem.DTO.ViewModel;
using System.Net.Http;
using System.Web.Mvc;

namespace AI_WoundAnalysisSystem.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// Calling Client
        /// </summary>
        private HttpClient client;

        /// <summary>
        /// manage User Login
        /// </summary>
        private readonly IManageUserLogin _manageUserLogin;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        public LoginController()
        {
            this._manageUserLogin = new ManageUserLogin();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class
        /// </summary>
        /// <param name="manageUserLogin">manage User Login</param>
        public LoginController(ManageUserLogin manageUserLogin)
        {
            this._manageUserLogin = manageUserLogin;
        }

        /// <summary>
        /// Show login details
        /// </summary>
        /// <param name="loginType">user or admin type</param>
        /// <returns>login details view</returns>
        [HttpGet]
        public ActionResult LoginDetails()
        {
            return this.PartialView();
        }

        /// <summary>
        /// Show login details
        /// </summary>
        /// <param name="userName">user Name</param>
        /// <param name="passWord">the password</param>
        /// <param name="disclaimerAccept">1 if disclaimer has read</param>
        /// <returns>login details view</returns>
        [HttpPost]
        public ActionResult LoginDetails(UserLoginVM userloginVM)
        {
            if (string.IsNullOrEmpty(userloginVM.Username) || string.IsNullOrEmpty(userloginVM.Password))
            {
                this.TempData["Message"] = 0;
                return this.View();
            }

            if (!string.IsNullOrEmpty(userloginVM.Username) && !string.IsNullOrEmpty(userloginVM.Password))
            {
                var userDetails = this._manageUserLogin.AuthenticateTemp(userloginVM.Username, userloginVM.Password);
                if (userDetails != null)
                {
                    if (userDetails.UserID > 0)
                    {
                        this.Session["LoggedInUser"] = userDetails.FirstName + " " + " " + userDetails.MiddleName + " " + userDetails.LastName;
                        this.Session["UserID"] = userDetails.UserID;
                        this.Session["UserRoleCode"] = userDetails.UserRole.UserRoleCode;

                        if (this.Session["UserRoleCode"].ToString() == "OPTR")
                        {
                            return this.RedirectToAction("Index", "Operator", new { Area = "Operator" });
                        }
                        else
                        {
                            return this.RedirectToAction("Index", "Patient", new { Area = "Patient"});
                
                        }

                    }
                }
                else
                {
                    this.TempData["Message"] = -1;
                    return this.View();
                }
            }

            return this.View();
        }

        /// <summary>
        /// Show login details
        /// </summary>
        /// <param name="userName">user Name</param>
        /// <param name="passWord">the password</param>
        /// <returns>response Message</returns>
        public ActionResult LoginDetails_Token(string userName, string passWord)
        {
            ////string url = ConfigurationManager.AppSettings["MonnieAPIUrl"] + "Auth/Api/Authenticate/Authenticate";
            ////HttpClient client = new HttpClient();
            ////client.DefaultRequestHeaders.Accept.Clear();
            ////var byteArray = Encoding.ASCII.GetBytes(userName + ":" + passWord);
            ////client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            ////client.BaseAddress = new Uri(url);
            ////HttpResponseMessage responseMessage = client.GetAsync(url).Result;
            ////if (responseMessage.IsSuccessStatusCode)
            ////{
            ////}

            ////return this.View();
            ////new MonnieAPIService().AuthorizeUser("client", "password");
            return this.RedirectToAction("Navigation");
        }

        /// <summary>
        /// Navigation details
        /// </summary>
        /// <returns>response Message</returns>
        public ActionResult Navigation()
        {
            ////new MonnieAPIService(" ", " ").GetNavigations(1);
            return this.View();
        }

        /// <summary>
        /// Forgot password
        /// </summary>
        /// <returns>forgot password view</returns>
        public ActionResult ForgotPassword()
        {
            return this.View();
        }

        /// <summary>
        /// Logout User
        /// </summary>
        /// <returns>forgot password view</returns>
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            return this.RedirectToAction("LoginDetails");
        }
    }
}