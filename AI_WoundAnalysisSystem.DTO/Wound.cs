using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string UserId { get; set; }
        public string OriginalImage { get; set; }
        public string SecondImage { get; set; }
        public string EdgeDetectedImage { get; set; }
    }
}
