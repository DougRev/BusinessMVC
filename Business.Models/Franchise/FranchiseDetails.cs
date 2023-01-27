using BusinessData;
using BusinessData.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.Franchise
{
    public class FranchiseDetails
    {
        public int FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public State State { get; set; }
        public float EmissionsTotal { get; set; }
        public virtual Client Client { get; set; }
        public List<Client> ClientList { get; set; }
    }
}
