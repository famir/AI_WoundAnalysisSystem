using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_WoundAnalysisSystem.DTO.ViewModel
{
   public class UserVM
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        public int UserID { get; set; }

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
        /// Gets or sets the patient Count
        /// </summary>
        public int? patientCount { get; set; }

    }
}
