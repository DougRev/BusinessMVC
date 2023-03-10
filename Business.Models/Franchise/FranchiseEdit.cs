using BusinessData.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessModels.Franchise
{
    public class FranchiseEdit
    {
        [Display(Name = "Franchise ID")]
        public int FranchiseId { get; set; }
        [Display(Name = "Account")]
        public string FranchiseName { get; set; }
        public State State { get; set; }
        //public Guid OwnerId { get; set; }

    }
}
