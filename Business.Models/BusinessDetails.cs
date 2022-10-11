using BusinesssData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class BusinessDetails
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public Guid OwnerId { get; set; }
        //public virtual Franchisee Franchisee { get; set; }
        public int FranchiseeId { get; set; }
        public string FranchiseeName { get; set; }


    }
}
