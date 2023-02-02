using BusinessData.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class BusinessListItem
    {
        [Display(Name = "Client ID")]
        public int BusinessId { get; set; }

        [Display(Name = "Client Name")]
        public string BusinessName { get; set; }
        public string FranchiseName { get; set; }
        public State State { get; set; }
        public Guid OwnerId { get; set; }
        public double TotalNOXBaselineTruckEmissions { get; set; }
        public double TotalNOXEmissionsWithSmash { get; set; }
        public double TestTotal { get; set; }
        public double NOXBaselineHaulerTruckRunningEmissions { get; set; }
    }
}
