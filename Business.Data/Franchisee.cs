using BusinessData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinesssData
{
    public class Franchisee
    {
        [Key]
        public int FranchiseeId { get; set; }
        public string FranchiseeName { get; set; }

        public Guid OwnerId { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }

    }
}