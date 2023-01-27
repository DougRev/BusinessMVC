using BusinessData.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData
{
    public class Franchise
    {
        [Key]
        public int FranchiseId { get; set; }
        public Guid OwnerId { get; set; }
        public string FranchiseName { get; set; }
        public virtual State State { get; set; }
        public List<Client> Clients { get; set; }

    }
}
