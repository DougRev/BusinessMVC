using BusinesssData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusinessData
{
    public class BusinesssFranchisee
    {
        [Key]
        [Column(Order = 1)]
        public int FranchiseeId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int BusinessId { get; set; }

        public virtual Franchisee Franchisee { get; set; }
        public virtual Business Business { get; set; }

        public virtual ICollection<Franchisee> Franchisees { get; set; }

    }
}