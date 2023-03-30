using BusinessData;
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
    public class FranchiseDetails
    {
        [Display(Name = "Franchise ID")]
        public int FranchiseId { get; set; }
        [Display(Name = "Account")]
        public string FranchiseName { get; set; }
        public State State { get; set; }
        public float EmissionsTotal { get; set; }
        public List<Client> Clients { get; set; } = new List<Client>();
        public double TotalCO2Saved { get; set; }
        public int StateReach { get; set; }
        public int Locations { get; set; }

    }
}
