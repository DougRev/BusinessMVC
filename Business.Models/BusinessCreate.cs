using BusinessData;
using BusinessData.Enum;
using BusinesssData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class BusinessCreate
    {
        public int BusinessId { get; set; }

        [Display(Name = "Client Name")]
        public string BusinessName { get; set; }

        [Display(Name = "Account")]
        public int FranchiseId { get; set; }

        [Display(Name = "Franchise Name")]
        public string FranchiseName { get; set; }
        public Guid OwnerId { get; set; }
        [Display(Name = "Facility ID")]
        public string FacilityID { get; set; }
        public State State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        [Display(Name = "Zip Code")]
        [Range(1, 99950, ErrorMessage = "Zip code must be between 00001 and 99950.")]
        public int ZipCode { get; set; }

        public Compactibility Compactibility { get; set; }
        public int FranchiseeId { get; set; }

        [Display(Name = "Number of Dumpsters")]
        public int NumberOfDumpsters { get; set; }

        [Display(Name = "Hauls Per Week")]
        public int HaulsPerDay { get; set; }

        [Display(Name = "Distance to Landfill (One Way)")]
        public float LandfillDist { get; set; }

        [Display(Name = "Save")]
        public bool AddToDb { get; set; }


    }
}
