﻿
//using DocumentFormat.OpenXml.Spreadsheet;
using AI_WoundAnalysisSystem.BLL.BusinessObject.Common;
using AI_WoundAnalysisSystem.BLL.Interface;
using AI_WoundAnalysisSystem.BLL.Persistance;
using AI_WoundAnalysisSystem.DTO;
using AI_WoundAnalysisSystem.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace AI_WoundAnalysisSystem.BLL.BusinessObject
{
    /// <summary> 
    /// Class for managing Employee
    /// </summary>
    public class ManagePatient : IManagePatient
    {
        #region Private Fields

        /// <summary> 
        /// Unit of work
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        #endregion

        #region Contructor

        /// <summary> 
        /// Initializes a new instance of the <see cref="ManagePatient"/> class.
        /// </summary>
        public ManagePatient()
        {
            this.unitOfWork = new UnitOfWork();
        }

        /// <summary> 
        /// Initializes a new instance of the <see cref="ManageEmployee"/> class.
        /// </summary>
        /// <param name="uWork">the unit of work</param>
        public ManagePatient(IUnitOfWork uWork)
        {
            this.unitOfWork = uWork;
        }

        #endregion

        #region Public member methods.

        /// <summary>
        ///  Function to get all employees
        /// </summary>
        /// <returns>returns employee list</returns>
        public List<PatientListingVM> GetAllPatient()
        {
            var empList = this.unitOfWork.UsersRepository.GetQuery(null).ToList();

            List<PatientListingVM> lstEmployee = (from v in this.unitOfWork.UsersRepository.GetQuery(null)
                                                select new PatientListingVM
                                                {
                                                    UserID = v.UserID,
                                                    //PersonalNummmer = v.PersonalNummmer,
                                                    FullName = v.FirstName + " " + v.MiddleName + " " + v.LastName,
                                                    //SupplierType = v.SupplierType != null ? v.SupplierType.SupplierType : string.Empty,
                                                    EmailAddress = v.EmailAddress,
                                                    Country = v.Country,
                                                    //StundennachweisPath = v.StundennachweisPath
                                                    //DOB = v.DOB,

                                                }).ToList();
            return lstEmployee;
        }

        /// <summary>
        ///  Function to get all employees based on UserRoleCode
        /// </summary>
        /// <returns>returns employee list</returns>
        public List<PatientListingVM> GetAllPatientByRole(string UserRoleCode)
        {
            var empList = this.unitOfWork.UsersRepository.GetQuery(null).ToList();

            if (UserRoleCode != Enum.GetName(typeof(CommonClass.UserRole), CommonClass.UserRole.OPTR))
            {
                string userRoleName = Enum.GetName(typeof(CommonClass.UserRole), CommonClass.UserRole.OPTR);
                empList = this.unitOfWork.UsersRepository.GetQuery(null).Where(x => x.UserRole.UserRoleName != userRoleName).ToList();
            }

            List<PatientListingVM> lstEmployee = (from v in empList
                                                select new PatientListingVM
                                                {
                                                    UserID = v.UserID,
                                                    //PersonalNummmer = v.PersonalNummmer,
                                                    FullName = v.FirstName + " " + v.MiddleName + " " + v.LastName,
                                                    //SupplierType = v.SupplierType != null ? v.SupplierType.SupplierType : string.Empty,
                                                    EmailAddress = v.EmailAddress,
                                                    Country = v.Country,
                                                    //StundennachweisPath = v.StundennachweisPath
                                                    //DOB = v.DOB,

                                                }).ToList();
            return lstEmployee;
        }

        /// <summary>
        /// Gets employee details by user ID
        /// </summary>
        /// <param name="userID">user ID</param>
        /// <returns>Return user model</returns>
        public Users GetPatientDetails(int userID)
        {
            return this.unitOfWork.UsersRepository.GetQuery(p => p.UserID == userID).FirstOrDefault();
        }

        ///// <summary>
        ///// Gets employee details by user ID
        ///// </summary>
        ///// <param name="userID">user ID</param>
        ///// <returns>Return employee view model</returns>
        //public EmployeeVM GetEmployeeById(int userID)
        //{
        //    try
        //    {
        //        Users user = this.unitOfWork.UsersRepository.GetQuery(u => u.UserID == userID).FirstOrDefault();
        //        if (user != null)
        //        {
        //            EmployeeVM objEmployeeVM = new EmployeeVM();

        //            objEmployeeVM.UserID = user.UserID;
        //            objEmployeeVM.FirstName = user.FirstName;
        //            objEmployeeVM.MiddleName = user.MiddleName;
        //            objEmployeeVM.LastName = user.LastName;
        //            objEmployeeVM.FullName = user.FirstName + " " + user.MiddleName + " " + user.LastName;
        //            objEmployeeVM.Country = user.Country;
        //            objEmployeeVM.DOB = user.DOB;
        //            objEmployeeVM.EmailAddress = user.EmailAddress;
        //            objEmployeeVM.Mobile = user.Mobile;
        //            objEmployeeVM.CreatedByID = user.CreatedByID;
        //            objEmployeeVM.CreatedDate = DateTime.Now;
        //            objEmployeeVM.Telephone = user.Telephone;
        //            objEmployeeVM.StundennachweisPath = user.StundennachweisPath;
        //            objEmployeeVM.PersonalNummmer = user.PersonalNummmer;


        //            objEmployeeVM.UploadStatus = false;

        //            //if (!string.IsNullOrEmpty(user.StundennachweisPath))
        //            //{
        //            //    objEmployeeVM.StundennachweisPath = "~/UserData/StundennachweisUpload/FileExist.png";
        //            //    objEmployeeVM.UploadStatus = true;
        //            //}


        //            return objEmployeeVM;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //    return null;
        //}

        ///// <summary>
        ///// Gets user details by email Address
        ///// </summary>
        ///// <param name="emailAddress">email Address</param>
        ///// <returns>Return user by id</returns>
        //public Users GetUserDetailsByEmail(string emailAddress)
        //{
        //    return this.unitOfWork.UsersRepository.GetQuery(p => p.EmailAddress == emailAddress).FirstOrDefault();
        //}

        ///// <summary>
        ///// save employee 
        ///// </summary>
        ///// <param name="model">user model</param>
        ///// <returns>Return employee</returns>
        //public Users SaveEmployee(Users model)
        //{
        //    if (model.UserID == 0)
        //    {
        //        this.unitOfWork.UsersRepository.Insert(model);
        //    }
        //    else
        //    {
        //        this.unitOfWork.UsersRepository.Update(model);
        //    }

        //    this.unitOfWork.Save();
        //    var userId = model.UserID;
        //    return model;
        //}

        ///// <summary>
        ///// Saves Employee details
        ///// </summary>
        ///// <param name="model">Employee view model</param>
        ///// <returns>ID of saved object</returns>
        //public EmployeeVM SaveEmployeeDetails(EmployeeVM model)
        //{
        //    var userInstance = this.GetUserDetailsByEmail(model.EmailAddress);

        //    Users obj;
        //    if (model.UserID == 0)
        //    {
        //        obj = new Users();
        //        obj.CreatedDate = DateTime.Now;
        //        obj.CreatedByID = 1;
        //        obj.Username = model.EmailAddress;
        //        obj.Password = this.GenerateRandomPassword(model.EmailAddress);
        //        //obj.UserStatusID = 1;
        //        //obj.UserTypeID = 5;
        //        if (userInstance != null)
        //        {
        //            model.EmployeeExistStatus = 0;//Already registered
        //            return model;
        //        }
        //    }
        //    else
        //    {
        //        obj = this.GetEmployeeDetails(model.UserID);
        //        if (userInstance != null && userInstance.UserID != model.UserID)
        //        {
        //            model.EmployeeExistStatus = 0;//Already registered
        //            return model;
        //        }
        //    }

        //    obj.FirstName = model.FirstName;
        //    obj.MiddleName = model.MiddleName;
        //    obj.LastName = model.LastName;
        //    obj.EmailAddress = model.EmailAddress;
        //    obj.Telephone = model.Telephone;
        //    obj.Mobile = model.Mobile;
        //    obj.PersonalNummmer = model.PersonalNummmer;

        //    obj.DOB = model.DOB;
        //    obj.StundennachweisPath = model.StundennachweisPath;
        //    //obj.FlatHouseNameNumber = model.FlatHouseNameNumber;
        //    //obj.Address1 = model.Address1;
        //    //obj.Address2 = model.Address2;
        //    //obj.City = model.City;

        //    //obj.ModifiedByID = 1;
        //    obj.ModifiedDate = DateTime.Now;
        //    obj.UserRoleID = 3;
        //    if (model.UserID == 0)
        //    {
        //        this.SendMailToUser(obj);
        //    }
        //    obj = this.SaveEmployee(obj);
        //    //model.UserID = obj.UserID;
        //    model.EmployeeExistStatus = 1;
        //    return model;



        //    //var userInstance = this.GetUserDetailsByEmail(model.EmailAddress);

        //    //if (userInstance != null)
        //    //{
        //    //    model.EmployeeExistStatus = 0;//Already registered
        //    //    return model;
        //    //}
        //    //else
        //    //{
        //    //    obj = this.SaveEmployee(obj);
        //    //    model.UserID = obj.UserID;
        //    //    model.EmployeeExistStatus = 1;
        //    //    return model;
        //    //}
        //}

        ///// <summary> 
        ///// Send Mail to user 
        ///// </summary>
        ///// <param name="userModel">User model</param>
        //public void SendMailToUser(Users userModel)
        //{
        //    CommonClass objCommon = new CommonClass();
        //    string subject = "Login credentials  for your account";
        //    string bodyMessage = string.Empty;
        //    //bodyMessage = "Hi " + userModel.LastName + " " + userModel.FirstName + ","
        //    //  + "<br/><br/>"
        //    //  + "Please login to the site using following credentials."
        //    //  + "<br/>";
        //    ////+ "Username : " + userModel.Username
        //    ////+ "<br/>"
        //    ////+ "Password : " + userModel.Password
        //    ////+ "</br><br/>";
        //    string tempFolderName = ConfigurationManager.AppSettings["UserCredentialTemplate"];

        //    //Read template file from the App_Data folder
        //    using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/" + tempFolderName)))

        //    {

        //        bodyMessage = reader.ReadToEnd();

        //    }

        //    bodyMessage = bodyMessage.Replace("{EmployeeName}", userModel.LastName + " " + userModel.FirstName);

        //    bodyMessage = bodyMessage.Replace("{UserName}", userModel.Username); //replacing the required things  

        //    bodyMessage = bodyMessage.Replace("{Password}", userModel.Password);




        //    bool mailSend = objCommon.SendEmailNotificationUsingTemplate(subject, bodyMessage, userModel.EmailAddress);
        //}

        ///// <summary>
        ///// Creates a new password by email
        ///// </summary>
        ///// <param name="email">enail</param>
        ///// <returns>Returns newly generated username</returns> 
        //public string GenerateRandomPassword(string email)
        //{
        //    string strPwdchar = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // string of character from which we will choose username's characters

        //    string result = email.Substring(0, 4);
        //    string strUserName = result;  //// string to store randomly generated username
        //    Random rnd = new Random();
        //    //// no. of iteration will be equal to username length [here username length is 8]
        //    for (int i = 0; i <= 3; i++)
        //    {
        //        int iRandom = rnd.Next(0, strPwdchar.Length - 1);
        //        strUserName += strPwdchar.Substring(iRandom, 1);
        //    }

        //    return strUserName;
        //}

        ///// <summary>
        /////  delete user by user id
        ///// </summary>
        ///// <param name="userId">user Id</param>
        ///// <returns>true for successful delete</returns>
        //public bool DeleteByUserId(int userId)
        //{
        //    this.unitOfWork.UsersRepository.Delete(userId);
        //    this.unitOfWork.Save();

        //    var isNotDeleted = this.unitOfWork.UsersRepository.GetQuery(x => x.UserID == userId).Any();

        //    return !isNotDeleted;
        //}


        ///// <summary>
        ///// Check If Employee Exist in Zeiterfasung Table
        ///// </summary>
        ///// <param name="personalnummer">personalnummer</param>
        ///// <param name="month">month</param>
        ///// <param name="year">year</param>
        ///// <returns>ID of saved object</returns>
        //public bool CheckIfEmpExist(int personalnummer, string month, string year)
        //{
        //    var empRecordList = this.unitOfWork.ZeiterfassungRepository.GetQuery(null).Where(x => x.PersonalNummmer == personalnummer && x.Month == month && x.Year == year).ToList();
        //    if (empRecordList != null && empRecordList.Count > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

      



        #endregion
    }
}