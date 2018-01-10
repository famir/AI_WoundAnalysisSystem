using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_WoundAnalysisSystem.DTO.ViewModel
{
    /// <summary>
    /// User Login View Model Class
    /// </summary>
    public class UserLoginVM
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the Personal Number
        /// </summary>
        public int PersonalNumber { get; set; }

        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        public int UserRoleID { get; set; }

        /// <summary>
        /// Gets or sets the Username
        /// </summary>
        [Required(ErrorMessage = "Please enter Username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle name 
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the User Type Code
        /// </summary>
        public string UserTypeCode { get; set; }

    }
}

