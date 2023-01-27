using BusinessData.Enum;
using BusinesssData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessModels
{
    public class BusinessDetails
    {
        [Display(Name = "Client ID")]
        public int BusinessId { get; set; }

        [Display(Name = "Client Name")]
        public string BusinessName { get; set; }
        public State State { get; set; }
        public Guid OwnerId { get; set; }
        //public virtual Franchisee Franchisee { get; set; }
        public int FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public int FranchiseeId { get; set; }
        public string FranchiseeName { get; set; }

        [Display(Name = "Transfer Station")]
        public bool XferStation { get; set; }

        [Display(Name = "SMT Distance to Client")]
        public float ToClientDist { get; set; }

        [Display(Name = "SMT Distance from Client")]
        public float FromClientDist { get; set; }

        [Display(Name = "Hauler Distance to Customer")]
        public float ToHaulerDist { get; set; }

        [Display(Name = "Hauler Distance from Customer")]
        public float FromHaulerDist { get; set; }

        [Display(Name = "Distance to Landfill")]
        public float LandfillDist { get; set; }

        [Display(Name = "Pre-SMT Hauls per Day")]
        public int HaulsPerDay { get; set; }

        [Display(Name = "Pre-SMT Est. Yearly Hauls")]
        public int PreSMTYearlyHauls { get; set; }
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int DoMath { get; set; }
        public float EmissionsMath { get; set; }
        public double BaselineHaulerTruckRunningEmissions { get; set; }
        public double BaselineHaulerTruckIdlingEmissions { get; set; }


    }
}
