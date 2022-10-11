using BusinesssData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessData
{
    public class Business
    {
        [Key]
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public int? BusinessIdNumber { get; set; }
        public Guid OwnerId { get; set; }
        public int FranchiseeId { get; set; }
        public virtual Franchisee Franchisee { get; set; }
        //public virtual ICollection<Franchisee> Franchisees { get; set; }
    }
}