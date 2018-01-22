using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_WoundAnalysisSystem.DTO.ViewModel
{
    public class PatientVM
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        [Required(ErrorMessage = "Please enter First Name")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle name 
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        [Required(ErrorMessage = "Please enter Last Name")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the email address
        /// </summary>
        [Required(ErrorMessage = "Please enter Email Address")]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the telephone
        /// </summary>
        [Required(ErrorMessage = "Please enter Telephone Number")]
        [DisplayName("Telephone Number")]
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
        /// Gets or sets the document path
        /// </summary>
        [Required(ErrorMessage = "Please Upload Document")]
        [DisplayName("Document")]
        public string DocumentPath { get; set; }

        ///// <summary>
        ///// Gets or sets the created date
        ///// </summary>
        public DateTime? CreatedDate { get; set; }

        ///// <summary>
        ///// Gets or sets the modified date
        ///// </summary>
        public DateTime? ModifiedDate { get; set; }
        //public string BloodGroup { get; set; }
        /// <summary>
        /// Gets or sets the created by user ID
        /// </summary>
        public int? CreatedByID { get; set; }

        [Required(ErrorMessage = "Please Upload Document")]
        [DisplayName("Document")]
        public HttpPostedFileBase DocumentUpload { get; set; }
    }
}
