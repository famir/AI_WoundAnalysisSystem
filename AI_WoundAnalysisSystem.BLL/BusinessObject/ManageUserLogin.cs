using AI_WoundAnalysisSystem.BLL.Interface;
using AI_WoundAnalysisSystem.BLL.Persistance;
using AI_WoundAnalysisSystem.DTO;
using AI_WoundAnalysisSystem.DTO.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace AI_WoundAnalysisSystem.BLL.BusinessObject
{
    /// <summary> 
    /// Class for managing User Login
    /// </summary>
    public class ManageUserLogin : IManageUserLogin
    {
        #region Private Fields

        /// <summary> 
        /// Unit of work
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        #endregion

        #region Contructor

        /// <summary> 
        /// Initializes a new instance of the <see cref="ManageUserLogin"/> class.
        /// </summary>
        public ManageUserLogin()
        {
            this.unitOfWork = new UnitOfWork();
        }

        /// <summary> 
        /// Initializes a new instance of the <see cref="ManageUserLogin"/> class.
        /// </summary>
        /// <param name="uWork">the unit of work</param>
        public ManageUserLogin(IUnitOfWork uWork)
        {
            this.unitOfWork = uWork;
        }

        #endregion

        #region Public member methods.

        /// <summary>
        ///  Function to authenticate
        /// </summary>
        /// <param name="userName">user Name</param>
        /// <param name="password">pass word</param>
        /// <returns>returns UserID</returns>
        public int Authenticate(string userName, string password)
        {
            var user = this.unitOfWork.UsersRepository.GetQuery(u => u.Username == userName && u.Password == password).FirstOrDefault();
            if (user != null && user.UserID > 0)
            {
                return user.UserID;
            }

            return 0;
        }

        /// <summary>
        ///  Function to authenticate temp
        /// </summary>
        /// <param name="userName">user Name</param>
        /// <param name="password">pass word</param>
        /// <returns>returns Users object</returns>
        public Users AuthenticateTemp(string userName, string password)
        {
            Users obj = new Users();

            var user = this.unitOfWork.UsersRepository.GetQuery(u => u.Username == userName && u.Password == password);

            return user.FirstOrDefault();
        }

        /// <summary>
        /// Get User Count 
        /// </summary>
        /// <returns>user count</returns>
        public int? GetUserCount()
        {
            return this.unitOfWork.UsersRepository.GetQuery(x => x.UserRoleID == 2).Count();
        }


        ///// <summary>
        ///// Gets the user type 
        ///// </summary>
        ///// <returns>user entity</returns>
        //public IEnumerable<UserTypeViewModel> GetUserTypes()
        //{
        //    List<UserTypeViewModel> lstUserType = new List<UserTypeViewModel>();
        //    try
        //    {

        //        lstUserType = (from UT in this.unitOfWork.UserTypeRepository.GetQuery(null).AsEnumerable()
        //                       select new UserTypeViewModel
        //                       {
        //                           UserTypeCode = UT.UserTypeCode,
        //                           UserTypeID = UT.UserTypeID,
        //                           UserTypeName = UT.UserTypeName
        //                       }).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //    return lstUserType;
        //}

        ///// <summary>
        ///// Gets the user Type details for a user
        ///// </summary>
        ///// <param name="userTypeID">user Type ID</param>
        ///// <returns>role ID</returns>
        //public UserTypeViewModel GetUserTypeByTypeId(int userTypeID)
        //{
        //    UserTypeViewModel userTypeDetails = this.GetUserTypes().Where(x => x.UserTypeID == userTypeID).FirstOrDefault();

        //    return userTypeDetails;
        //}

        ///// <summary>
        ///// Gets the client ID for a user
        ///// </summary>
        ///// <param name="userID">user ID</param>
        ///// <returns>client ID</returns>
        //public int GetClientIDOfUser(int userID)
        //{
        //    ClientUserRelation crel = this.unitOfWork.ClientUserRelationRepository.Get(x => x.UserID == userID).FirstOrDefault();

        //    return crel != null ? crel.ClientID : 0;
        //}

        ///// <summary>
        ///// Gets the Role ID for a user
        ///// </summary>
        ///// <param name="userID">user ID</param>
        ///// <returns>role ID</returns>
        //public int GetRoleIDOfUser(int userID)
        //{
        //    UsersUserRoleRelation rrel = this.unitOfWork.UsersUserRoleRelationRepository.Get(x => x.UserID == userID).OrderByDescending(x => x.UsersUserRoleRelationID).FirstOrDefault();

        //    return rrel != null ? rrel.UserRoleID : 0;
        //}

        ///// <summary>
        ///// Gets the user based on userId from User User Role Relation Repository
        ///// </summary>
        ///// <param name="userId">User Id</param>
        ///// <returns>user entity</returns>
        //public UsersUserRoleRelation GetUserByUserId(int userId)
        //{
        //    return this.unitOfWork.UsersUserRoleRelationRepository.GetQuery(p => p.UserID == userId).OrderByDescending(p => p.UsersUserRoleRelationID).FirstOrDefault();
        //}



        #endregion
    }
}
