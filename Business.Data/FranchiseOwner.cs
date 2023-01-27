using BusinessData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinesssData
{
    public class FranchiseOwner
    {
        [Key]
        public int FranchiseeId { get; set; }
        public string FranchiseeName { get; set; }

        public Guid OwnerId { get; set; }
        public virtual ICollection<Client> Businesses { get; set; }

    }
}