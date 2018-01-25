using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_WoundAnalysisSystem.DTO
{
   public class WoundTypes
    {
        public int WoundTypesID { get; set; }

        public string WoundTypeName { get; set; }

        public string WoundTypeCode { get; set; }

        public string Features { get; set; }

        public string MedicinePrescribed { get; set; }
    }
}
