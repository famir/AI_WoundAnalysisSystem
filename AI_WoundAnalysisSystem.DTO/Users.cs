using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AI_WoundAnalysisSystem.DTO
{
    public class Users
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        [Key]
        public int UserID { get; set; }

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
        /// Gets or sets the Profile Image path
        /// </summary>
        public string ProfileImagePath { get; set; }

        /// <summary>
        /// Gets or sets the Stundennachweis document path
        /// </summary>
        public string DocumentPath { get; set; }

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

        /// <summary>
        /// Gets or sets the user User Role ID
        /// </summary>
        [ForeignKey("UserRole")]
        public int UserRoleID { get; set; }

        //public string BloodGroup { get; set; }
        ///// <summary>
        ///// Gets or sets the Buchungs nummer 
        ///// </summary>
        //public string Buchungsnummer { get; set; }

        ///// <summary>
        ///// Gets or sets the Stundenanzahl 
        ///// </summary>
        //public int? Stundenanzahl { get; set; }

        /// <summary>
        /// Gets or sets the User Role
        /// </summary>
        public virtual UserRole UserRole { get; set; }
    }
}

