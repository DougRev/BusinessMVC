﻿using BusinessData.Enum;
using BusinesssData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml.Linq;

namespace BusinessModels
{
    public class BusinessEdit
    {
        [Display(Name = "Client ID")]
        public int BusinessId { get; set; }

        [Display(Name = "Client Name")]
        public string BusinessName { get; set; }

        [Display(Name = "Facility ID")]
        public string FacilityID { get; set; }
        public State State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        public Guid OwnerId { get; set; }
        public int FranchiseId { get; set; }
        public List<SelectListItem> Franchises { get; set; }

        public string FranchiseName { get; set; }
        public int FranchiseeId { get; set; }
        public Compactibility Compactibility { get; set; }

        [Display(Name = "Transfer Station")]
        public bool XferStation { get; set; }

        [Display(Name = "SMT Distance to Client")]
        public float ToClientDist { get; set; }

        [Display(Name = "SMT Distance from Client")]
        public float FromClientDist { get; set; }

        [Display(Name = "Hauler Distance to Client")]
        public float ToHaulerDist { get; set; }

        [Display(Name = "Hauler Distance to Landfill")]
        public float LandfillDist { get; set; }

        [Display(Name = "Hauler Distance to Next Customer")]
        public float FromHaulerDist { get; set; }

        [Display(Name = "Hauls Per Week")]
        public int HaulsPerDay { get; set; }

        [Display(Name = "Number of Dumpsters")]
        public int NumberOfDumpsters { get; set; }

        [Display(Name = "Pre-SMT Est. Yearly Hauls ")]
        public int PreSMTYearlyHauls { get; set; }


        //public virtual Franchisee Franchisee { get; set; }
    }
}
