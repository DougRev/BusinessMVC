using BusinessData.Enum;
using BusinesssData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class BusinessCreate
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public Guid OwnerId { get; set; }
        public State State { get; set; }
        public virtual Franchisee Franchisee { get; set; }
        public ICollection<Franchisee> Franchisees { get; set; }
        public int FranchiseeId { get; set; }
    }
}
