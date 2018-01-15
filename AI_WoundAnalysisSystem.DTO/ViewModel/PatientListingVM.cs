using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_WoundAnalysisSystem.DTO.ViewModel
{
    public class PatientListingVM
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
        /// Gets or sets the user name
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
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
        /// Gets or sets the full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the email address
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the telephone
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the PostCode
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// Gets or sets the mobile
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the date of birth
        /// </summary>
        public DateTime? DOB { get; set; }

        /// <summary>
        /// Gets or sets the Personal Nummmer 
        /// </summary>
        public int PersonalNummmer { get; set; }

        /// <summary>
        /// Gets or sets the Stundennachweis document path
        /// </summary>
        public string StundennachweisPath { get; set; }

        ///// <summary>
        ///// Gets or sets the created date
        ///// </summary>
        public DateTime? CreatedDate { get; set; }

        ///// <summary>
        ///// Gets or sets the modified date
        ///// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the created by user ID
        /// </summary>
        public int? CreatedByID { get; set; }
    }
}
