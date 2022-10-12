using BusinessData.Enum;
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
        public State State { get; set; }
        public Guid OwnerId { get; set; }
        public int FranchiseeId { get; set; }
        public virtual Franchisee Franchisee { get; set; }
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int DoMath
        {
            get
            {
                int value = Num1 + Num2;
                return value;
            }
        }
        public int Calculation
        {
            get
            {
                int value = 50;
                return value;
            }
        }
        //public virtual ICollection<Franchisee> Franchisees { get; set; }
    }
}