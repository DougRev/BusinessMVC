using BusinessData.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.Franchise
{
    public class FranchiseListItem
    {
        public int FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public State State { get; set; }

    }
}
