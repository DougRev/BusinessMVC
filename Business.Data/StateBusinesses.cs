using BusinessData.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessData
{
    public class StateBusinesses
    {
        public int StateId { get; set; }
        public virtual State State { get; set; }
        public int BusinessId { get; set; }
        public virtual Business Business { get; set; }
        public ICollection<Business> Businesses { get; set; }
    }
}
