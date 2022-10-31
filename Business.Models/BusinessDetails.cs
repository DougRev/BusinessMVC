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
        [Display(Name = "Franchise ID")]
        public int BusinessId { get; set; }

        [Display(Name = "Franchise Name")]
        public string BusinessName { get; set; }
        public State State { get; set; }
        public Guid OwnerId { get; set; }
        //public virtual Franchisee Franchisee { get; set; }
        public int FranchiseeId { get; set; }
        public string FranchiseeName { get; set; }

        [Display(Name = "Transfer Station")]
        public bool XferStation { get; set; }

        [Display(Name = "Distance to Client")]
        public float ClientDist { get; set; }

        [Display(Name = "Distance to Hauler")]
        public float HaulerDist { get; set; }

        [Display(Name = "Distance to Landfill")]
        public float LandfillDist { get; set; }

        [Display(Name = "Est. Yearly Smashes")]
        public int YearlySmashes { get; set; }
        public int Calculation { get; set; }
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int DoMath { get; set; }


    }
}
