using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class BusinessListItem
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public Guid OwnerId { get; set; }
    }
}
