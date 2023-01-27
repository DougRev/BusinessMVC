using BusinessData.Enum;
using BusinesssData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusinessData
{
    public class Client
    {
        [Key]
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public State State { get; set; }
        public Guid OwnerId { get; set; }
        public int FranchiseeId { get; set; }
        public virtual FranchiseOwner Franchisee { get; set; }

        public int FranchiseId { get; set; }

        [ForeignKey(nameof(Franchise))]
        public virtual Franchise Franchise { get; set; }

        [Display(Name ="Transfer Station")]
        public bool XferStation { get; set; }

        [Display(Name = "SMT Distance to Client")]
        public float ToClientDist { get; set; }

        [Display(Name = "SMT Distance from Client")]
        public float FromClientDist { get; set; }

        [Display(Name = "Hauler Distance to Client")]
        public float ToHaulerDist { get; set; }

        [Display(Name = "Hauler Distance to Landfill")]
        public float LandfillDist { get; set; }

        [Display(Name = "Hauler Distance to Next Customer")]
        public float FromHaulerDist { get; set; }

        [Display(Name = "Pre-SMT Hauls per Day")]
        public int HaulsPerDay { get; set; }

        [Display(Name = "Pre-SMT Est. Yearly Hauls ")]
        public int PreSMTYearlyHauls { get; set; }

        public int Num1 
        { 
            get
            {
                int preSmtYearlyHauls = HaulsPerDay * 260; //Assuming 260 work days
                return PreSMTYearlyHauls = preSmtYearlyHauls;

            }
        }
        public float EmissionsMath
        {
            get
            {
                float smtRoundTripDist = ToClientDist + FromClientDist;
                float haulerRoundTripDist = (LandfillDist * 2) + ToHaulerDist + FromHaulerDist;





                return smtRoundTripDist;
            }
        }

        public double BaselineHaulerTruckRunningEmissions
        {
            get
            {

                int yearlyHauls = PreSMTYearlyHauls;
                float vmt = (LandfillDist * 2) + ToHaulerDist + FromHaulerDist;
                double emissionFactor = 1761.871366;
                double conversionFactor = .002204622622;
                double baslineHaulerTruckRunningEmissions = yearlyHauls * vmt * emissionFactor * conversionFactor;
                return baslineHaulerTruckRunningEmissions;
            }
        }

        public double BaslineHaulerTruckIdlingEmissions
        {
            get
            {
                int yearlyHauls = PreSMTYearlyHauls;
                double vit = 0.7;
                double emissionFactor = 7657.722697;
                double conversionFactor = .002204622622;
                double baselineHaulerTruckIdlingEmissions = yearlyHauls * vit * emissionFactor * conversionFactor;
                return baselineHaulerTruckIdlingEmissions;

            }
        }
        //public virtual ICollection<Franchisee> Franchisees { get; set; }
    }
}