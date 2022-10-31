using BusinessData.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class BusinessListItem
    {
        [Display(Name = "Franchise ID")]
        public int BusinessId { get; set; }

        [Display(Name = "Franchise Name")]
        public string BusinessName { get; set; }
        public State State { get; set; }
        public Guid OwnerId { get; set; }
    }
}
