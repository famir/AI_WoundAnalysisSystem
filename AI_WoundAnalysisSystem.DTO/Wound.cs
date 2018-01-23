using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AI_WoundAnalysisSystem.DTO
{
    public  class Wound
    { 
        public int WoundId { get; set; }

        public string WoundTitle { get; set; }

        public string Woundtype { get; set; }

        public DateTime SufferingFrom { get; set; }

        public string WoundDetails { get; set; }

        public string WoundImagePath { get; set; }

        public string OriginalImage { get; set; }

        public string SecondImage { get; set; }

        public string EdgeDetectedImage { get; set; }

        public int? Threshold { get; set; }
        /// <summary>
        /// Gets or sets the user User Role ID
        /// </summary>
        [ForeignKey("Users")]
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the Users
        /// </summary>
        public virtual Users Users { get; set; }
    }
}
