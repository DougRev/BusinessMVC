using BusinessData;
using BusinessData.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.Franchise
{
    public class FranchiseCreate
    {
        [Key]
        public int FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public Guid OwnerId { get; set; }
        public State State { get; set; }
        public List<Client> Clients { get; set; }
    }
}
