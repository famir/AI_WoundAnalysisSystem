
using AI_WoundAnalysisSystem.DTO;
using AI_WoundAnalysisSystem.DTO.ViewModel;

using System.Collections.Generic;


namespace AI_WoundAnalysisSystem.BLL.Interface
{
    /// <summary>
    /// Interface for Manage Employee
    /// </summary>
    public interface IManagePatient
    {
        /// <summary>
        ///  Function to get all employees
        /// </summary>
        /// <returns>returns employee list</returns>
        List<PatientListingVM> GetAllPatient();

        /// <summary>
        ///  Function to get all employees based on UserRoleCode
        /// </summary>
        /// <returns>returns employee list</returns>
        List<PatientListingVM> GetAllPatientByRole(string UserRoleCode);

        /// <summary>
        /// Gets employee details by user ID
        /// </summary>
        /// <param name="userID">user ID</param>
        /// <returns>Return user</returns>
        Users GetPatientDetails(int userID);

        ///// <summary>
        ///// Gets patient details by user ID
        ///// </summary>
        /// <param name="userID">user ID</param>
        /// <returns>Return patient view model</returns>
        PatientVM GetPatientById(int userID);

        ///// <summary>
        ///// Saves Patient details
        ///// </summary>
        ///// <param name="model">Patient view model</param>
        ///// <returns>ID of saved object</returns>
        PatientVM SavePatientDetails(PatientVM model);

        ///// <summary>
        ///// Gets user details by email Address
        ///// </summary>
        ///// <param name="emailAddress">email Address</param>
        ///// <returns>Return user by id</returns>
        //Users GetUserDetailsByEmail(string emailAddress);


        ///// <summary>
        ///// save employee 
        ///// </summary>
        ///// <param name="model">user model</param>
        ///// <returns>Return employee</returns>
        //Users SaveEmployee(Users model);

        ///// <summary>
        ///// Saves Employee details
        ///// </summary>
        ///// <param name="model">Employee view model</param>
        ///// <returns>ID of saved object</returns>
        //EmployeeVM SaveEmployeeDetails(EmployeeVM model);


        ///// <summary>
        /////  delete user by user id
        ///// </summary>
        ///// <param name="userId">user Id</param>
        ///// <returns>true for successful delete</returns>
        //bool DeleteByUserId(int userId);

        ///// <summary>
        ///// Saves Employee details
        ///// </summary>
        ///// <param name="model">Employee view model</param>
        ///// <returns>ID of saved object</returns>
        //int SaveZeiterfassung(List<Zeiterfassung> model);

        ///// <summary>
        /////  Insert Zeiterfassung Records To Db
        ///// </summary>
        ///// <param name="userId">user Id</param>
        ///// <returns>true for successful delete</returns>
        //void InsertZeiterfassungRecordToDb(List<Zeiterfassung> model);

        ///// <summary>
        ///// GenerateZeiterfassung 
        ///// </summary>
        ///// <returns>generate spreadsheet excel</returns>
        //SLDocument GenerateZeiterfassung(string tempFldrPath);

        ///// <summary>
        ///// Generate SAP Template 
        ///// </summary>
        ///// <returns>generate sap template</returns>
        //SLDocument GenerateSAPTemplate(string fileUrl);

        ///// <summary>
        ///// Check If Employee Exist in Zeiterfasung Table
        ///// </summary>
        ///// <param name="personalnummer">personalnummer</param>
        ///// <param name="month">month</param>
        ///// <param name="year">year</param>
        ///// <returns>ID of saved object</returns>
        //bool CheckIfEmpExist(int personalnummer, string month, string year);
    }
}
