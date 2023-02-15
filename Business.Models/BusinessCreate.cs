﻿using BusinessData;
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

        [Display(Name = "Franchise ID")]
        public int FranchiseId { get; set; }

        [Display(Name = "Franchise Name")]
        public string FranchiseName { get; set; }
        public Guid OwnerId { get; set; }
        public State State { get; set; }
        public Compactibility Compactibility { get; set; }
        public int FranchiseeId { get; set; }

        [Display(Name = "Hauls Per Day")]
        public int HaulsPerDay { get; set; }
    }
}
