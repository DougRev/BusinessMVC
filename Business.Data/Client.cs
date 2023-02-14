using BusinessData.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessData
{
    public class Client
    {
        [Key]
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public State State { get; set; }
        public Guid OwnerId { get; set; }

        //public int FranchiseeId { get; set; }
        //public virtual FranchiseOwner Franchisee { get; set; }
        public int FranchiseId { get; set; }
        public string FranchiseName { get; set; }

        [ForeignKey(nameof(Franchise))]
        public virtual Franchise Franchise { get; set; }


        [Display(Name = "Transfer Station")]
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
        public int PreSMTYearlyHauls
        {
            get
            {
                int preSmtYearlyHauls = HaulsPerDay * 260; //Assuming 260 work days
                return preSmtYearlyHauls;
            }
        }

        public Compactibility Compactibility { get; set; }
        public double CompactibilityValue
        {
            get
            {
                double value = 0;
                return value = GetCompactibility(Compactibility);
            }
        }


        private double GetCompactibility(Compactibility compactibility)
        {
            switch (compactibility)
            {
                case Compactibility.High:
                    return .2;

                case Compactibility.Medium:
                    return .3;

                case Compactibility.Low:
                    return .4;
                default:
                    return 0;
            }
        }

        //Emissions Added Totals

        public double BaselineTotals
        {
            get
            {
                double total = TotalNOXBaselineTruckEmissions + TotalN20BaselineTruckEmissions + TotalPM25BaselineTruckEmissions + TotalPM10BaselineTruckEmissions + TotalSO2BaselineTruckEmissions + TotalCH4BaselineTruckEmissions + TotalCOBaselineTruckEmissions + TotalVOCBaselineTruckEmissions + TotalCO2BaselineTruckEmissions;
                return total;
            }
        }

        public double EmissionsWithSmashTotals
        {
            get
            {
                double total = TotalNOXEmissionsWithSmash + TotalN20EmissionsWithSmash + TotalPM25EmissionsWithSmash + TotalPM10EmissionsWithSmash + TotalSO2EmissionsWithSmash + TotalCH4EmissionsWithSmash + TotalCOEmissionsWithSmash + TotalVOCEmissionsWithSmash + TotalCO2EmissionsWithSmash;
                return total;
            }
        }

        public string SavingsTotal
        {
            get
            {
                double total = BaselineTotals - EmissionsWithSmashTotals;
                double percent = total / BaselineTotals;
                string changed = string.Format("{0:P2}", percent);
                return changed;
            }
        }


        // NOx Emissions
        public double NOXBaselineHaulerTruckRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                //float vmt = (LandfillDist * 2) + ToHaulerDist + FromHaulerDist;
                float vmt = 34;
                double emissionFactor = emissions.RunningNOX;
                double conversionFactor = .002204622622;
                double baslineHaulerTruckRunningEmissions = yearlyHauls * vmt * emissionFactor * conversionFactor;
                return baslineHaulerTruckRunningEmissions;
            }
        }
        public double NOXBaselineHaulerTruckIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double vit = 0.722916667;
                double emissionFactor = emissions.IdleNOX;
                double conversionFactor = .002204622622;
                double baselineHaulerTruckIdlingEmissions = yearlyHauls * vit * emissionFactor * conversionFactor;
                return baselineHaulerTruckIdlingEmissions;

            }
        }

        public double NOXSmashingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double smashingTime = .083333333;
                double emissionFactor = emissions.SmashNOX;
                double conversionFactor = .002204622622;
                double smashingEmissions = yearlyHauls * smashingTime * emissionFactor * conversionFactor;
                return smashingEmissions;

            }
        }

        public double NOXSMTRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                //double roundTrip = ToClientDist + FromClientDist;
                double roundTrip = 2;
                double emissionFactor = emissions.SmashRunNOX;
                double conversionFactor = .002204622622;
                double runningEmissions = yearlyHauls * roundTrip * emissionFactor * conversionFactor;
                return runningEmissions;
            }
        }
        public double NOXSMTIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                double idlingTime = .083333333;
                double emissionFactor = emissions.SmashIdleNOX;
                double conversionFactor = .002204622622;
                double idlingEmissions = yearlyHauls * idlingTime * emissionFactor * conversionFactor;
                return idlingEmissions;
            }
        }
        public double NOXHaulerRunningEmissionsWithCompactibility
        {
            get
            {
                double total = NOXBaselineHaulerTruckRunningEmissions * CompactibilityValue;
                return total;
            }
        }
        public double NOXHaulerIdlingEmissionsWithCompactibility
        {
            get
            {
                double total = NOXBaselineHaulerTruckIdlingEmissions * CompactibilityValue;
                return total;
            }
        }

        public double TotalNOXBaselineTruckEmissions
        {
            get
            {

                double c02Total = NOXBaselineHaulerTruckRunningEmissions + NOXBaselineHaulerTruckIdlingEmissions;
                return c02Total;
            }
        }

        public double TotalNOXEmissionsWithSmash
        {
            get
            {
                double c02SmashTotal = NOXSmashingEmissions + NOXSMTRunningEmissions + NOXSMTIdlingEmissions + NOXHaulerRunningEmissionsWithCompactibility + NOXHaulerIdlingEmissionsWithCompactibility;
                return c02SmashTotal;
            }
        }

        public string NOXPercentSaved
        {
            get
            {
                double saved = TotalNOXBaselineTruckEmissions - TotalNOXEmissionsWithSmash;
                double percent = saved / TotalNOXBaselineTruckEmissions;
                string changed = string.Format("{0:P2}", percent);
                return changed;
            }
        }

        // N20 Emissions
        public double N20BaselineHaulerTruckRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                //float vmt = (LandfillDist * 2) + ToHaulerDist + FromHaulerDist;
                float vmt = 34;
                double emissionFactor = emissions.RunningN20;
                double conversionFactor = .002204622622;
                double baslineHaulerTruckRunningEmissions = yearlyHauls * vmt * emissionFactor * conversionFactor;
                return baslineHaulerTruckRunningEmissions;
            }
        }

        public double N20BaselineHaulerTruckIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double vit = 0.7;
                double emissionFactor = emissions.IdleN20;
                double conversionFactor = .002204622622;
                double baselineHaulerTruckIdlingEmissions = yearlyHauls * vit * emissionFactor * conversionFactor;
                return baselineHaulerTruckIdlingEmissions;

            }
        }
        public double N20SmashingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double smashingTime = .083333333;
                double emissionFactor = emissions.SmashN20;
                double conversionFactor = .002204622622;
                double smashingEmissions = yearlyHauls * smashingTime * emissionFactor * conversionFactor;
                return smashingEmissions;

            }
        }
        public double N20SMTRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                //double roundTrip = ToClientDist + FromClientDist;
                double roundTrip = 2;
                double emissionFactor = emissions.SmashRunN20;
                double conversionFactor = .002204622622;
                double runningEmissions = yearlyHauls * roundTrip * emissionFactor * conversionFactor;
                return runningEmissions;
            }
        }
        public double N20SMTIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                double idlingTime = .083333333;
                double emissionFactor = emissions.SmashIdleN20;
                double conversionFactor = .002204622622;
                double idlingEmissions = yearlyHauls * idlingTime * emissionFactor * conversionFactor;
                return idlingEmissions;
            }
        }
        public double N20HaulerRunningEmissionsWithCompactibility
        {
            get
            {
                double total = N20BaselineHaulerTruckRunningEmissions * CompactibilityValue;
                return total;
            }
        }
        public double N20HaulerIdlingEmissionsWithCompactibility
        {
            get
            {
                double total = N20BaselineHaulerTruckIdlingEmissions * CompactibilityValue;
                return total;
            }
        }
        public double TotalN20BaselineTruckEmissions
        {
            get
            {

                double c02Total = N20BaselineHaulerTruckRunningEmissions + N20BaselineHaulerTruckIdlingEmissions;
                return c02Total;
            }
        }

        public double TotalN20EmissionsWithSmash
        {
            get
            {
                double c02SmashTotal = N20SmashingEmissions + N20SMTRunningEmissions + N20SMTIdlingEmissions + N20HaulerRunningEmissionsWithCompactibility + N20HaulerIdlingEmissionsWithCompactibility;
                return c02SmashTotal;
            }
        }
        public string N20PercentSaved
        {
            get
            {
                double saved = TotalN20BaselineTruckEmissions - TotalN20EmissionsWithSmash;
                double percent = saved / TotalN20BaselineTruckEmissions;
                string changed = string.Format("{0:P2}", percent);
                return changed;
            }
        }

        // PM2.5 Emissions
        public double PM25BaselineHaulerTruckRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                //float vmt = (LandfillDist * 2) + ToHaulerDist + FromHaulerDist;
                float vmt = 34;
                double emissionFactor = emissions.RunningPM25;
                double conversionFactor = .002204622622;
                double baslineHaulerTruckRunningEmissions = yearlyHauls * vmt * emissionFactor * conversionFactor;
                return baslineHaulerTruckRunningEmissions;
            }
        }

        public double PM25BaselineHaulerTruckIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double vit = 0.7;
                double emissionFactor = emissions.IdlePM25;
                double conversionFactor = .002204622622;
                double baselineHaulerTruckIdlingEmissions = yearlyHauls * vit * emissionFactor * conversionFactor;
                return baselineHaulerTruckIdlingEmissions;

            }
        }
        public double PM25SmashingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double smashingTime = .083333333;
                double emissionFactor = emissions.SmashPM25;
                double conversionFactor = .002204622622;
                double smashingEmissions = yearlyHauls * smashingTime * emissionFactor * conversionFactor;
                return smashingEmissions;

            }
        }
        public double PM25SMTRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                //double roundTrip = ToClientDist + FromClientDist;
                double roundTrip = 2;
                double emissionFactor = emissions.SmashRunPM25;
                double conversionFactor = .002204622622;
                double runningEmissions = yearlyHauls * roundTrip * emissionFactor * conversionFactor;
                return runningEmissions;
            }
        }
        public double PM25SMTIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                double idlingTime = .083333333;
                double emissionFactor = emissions.SmashIdlePM25;
                double conversionFactor = .002204622622;
                double idlingEmissions = yearlyHauls * idlingTime * emissionFactor * conversionFactor;
                return idlingEmissions;
            }
        }
        public double PM25HaulerRunningEmissionsWithCompactibility
        {
            get
            {
                double total = PM25BaselineHaulerTruckRunningEmissions * CompactibilityValue;
                return total;
            }
        }
        public double PM25HaulerIdlingEmissionsWithCompactibility
        {
            get
            {
                double total = PM25BaselineHaulerTruckIdlingEmissions * CompactibilityValue;
                return total;
            }
        }
        public double TotalPM25BaselineTruckEmissions
        {
            get
            {

                double c02Total = PM25BaselineHaulerTruckRunningEmissions + PM25BaselineHaulerTruckIdlingEmissions;
                return c02Total;
            }
        }

        public double TotalPM25EmissionsWithSmash
        {
            get
            {
                double c02SmashTotal = PM25SmashingEmissions + PM25SMTRunningEmissions + PM25SMTIdlingEmissions + PM25HaulerRunningEmissionsWithCompactibility + PM25HaulerIdlingEmissionsWithCompactibility;
                return c02SmashTotal;
            }
        }
        public string PM25PercentSaved
        {
            get
            {
                double saved = TotalPM25BaselineTruckEmissions - TotalPM25EmissionsWithSmash;
                double percent = saved / TotalPM25BaselineTruckEmissions;
                string changed = string.Format("{0:P2}", percent);
                return changed;
            }
        }

        // PM10 Emissions
        public double PM10BaselineHaulerTruckRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                //float vmt = (LandfillDist * 2) + ToHaulerDist + FromHaulerDist;
                float vmt = 34;
                double emissionFactor = emissions.RunningPM10;
                double conversionFactor = .002204622622;
                double baslineHaulerTruckRunningEmissions = yearlyHauls * vmt * emissionFactor * conversionFactor;
                return baslineHaulerTruckRunningEmissions;
            }
        }

        public double PM10BaselineHaulerTruckIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double vit = 0.7;
                double emissionFactor = emissions.IdlePM10;
                double conversionFactor = .002204622622;
                double baselineHaulerTruckIdlingEmissions = yearlyHauls * vit * emissionFactor * conversionFactor;
                return baselineHaulerTruckIdlingEmissions;

            }
        }
        public double PM10SmashingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double smashingTime = .083333333;
                double emissionFactor = emissions.SmashPM10;
                double conversionFactor = .002204622622;
                double smashingEmissions = yearlyHauls * smashingTime * emissionFactor * conversionFactor;
                return smashingEmissions;

            }
        }
        public double PM10SMTRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                //double roundTrip = ToClientDist + FromClientDist;
                double roundTrip = 2;
                double emissionFactor = emissions.SmashRunPM10;
                double conversionFactor = .002204622622;
                double runningEmissions = yearlyHauls * roundTrip * emissionFactor * conversionFactor;
                return runningEmissions;
            }
        }
        public double PM10SMTIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                double idlingTime = .083333333;
                double emissionFactor = emissions.SmashIdlePM10;
                double conversionFactor = .002204622622;
                double idlingEmissions = yearlyHauls * idlingTime * emissionFactor * conversionFactor;
                return idlingEmissions;
            }
        }
        public double PM10HaulerRunningEmissionsWithCompactibility
        {
            get
            {
                double total = PM10BaselineHaulerTruckRunningEmissions * CompactibilityValue;
                return total;
            }
        }
        public double PM10HaulerIdlingEmissionsWithCompactibility
        {
            get
            {
                double total = PM10BaselineHaulerTruckIdlingEmissions * CompactibilityValue;
                return total;
            }
        }
        public double TotalPM10BaselineTruckEmissions
        {
            get
            {

                double c02Total = PM10BaselineHaulerTruckRunningEmissions + PM10BaselineHaulerTruckIdlingEmissions;
                return c02Total;
            }
        }

        public double TotalPM10EmissionsWithSmash
        {
            get
            {
                double c02SmashTotal = PM10SmashingEmissions + PM10SMTRunningEmissions + PM10SMTIdlingEmissions + PM10HaulerRunningEmissionsWithCompactibility + PM10HaulerIdlingEmissionsWithCompactibility;
                return c02SmashTotal;
            }
        }

        public string PM10PercentSaved
        {
            get
            {
                double saved = TotalPM10BaselineTruckEmissions - TotalPM10EmissionsWithSmash;
                double percent = saved / TotalPM10BaselineTruckEmissions;
                string changed = string.Format("{0:P2}", percent);
                return changed;
            }
        }

        // SO2 Emissions
        public double SO2BaselineHaulerTruckRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                //float vmt = (LandfillDist * 2) + ToHaulerDist + FromHaulerDist;
                float vmt = 34;
                double emissionFactor = emissions.RunningSO2;
                double conversionFactor = .002204622622;
                double baslineHaulerTruckRunningEmissions = yearlyHauls * vmt * emissionFactor * conversionFactor;
                return baslineHaulerTruckRunningEmissions;
            }
        }

        public double SO2BaselineHaulerTruckIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double vit = 0.7;
                double emissionFactor = emissions.IdleSO2;
                double conversionFactor = .002204622622;
                double baselineHaulerTruckIdlingEmissions = yearlyHauls * vit * emissionFactor * conversionFactor;
                return baselineHaulerTruckIdlingEmissions;

            }
        }
        public double SO2SmashingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double smashingTime = .083333333;
                double emissionFactor = emissions.SmashSO2;
                double conversionFactor = .002204622622;
                double smashingEmissions = yearlyHauls * smashingTime * emissionFactor * conversionFactor;
                return smashingEmissions;

            }
        }
        public double SO2SMTRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                //double roundTrip = ToClientDist + FromClientDist;
                double roundTrip = 2;
                double emissionFactor = emissions.SmashRunSO2;
                double conversionFactor = .002204622622;
                double runningEmissions = yearlyHauls * roundTrip * emissionFactor * conversionFactor;
                return runningEmissions;
            }
        }
        public double SO2SMTIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                double idlingTime = .083333333;
                double emissionFactor = emissions.SmashIdleSO2;
                double conversionFactor = .002204622622;
                double idlingEmissions = yearlyHauls * idlingTime * emissionFactor * conversionFactor;
                return idlingEmissions;
            }
        }
        public double SO2HaulerRunningEmissionsWithCompactibility
        {
            get
            {
                double total = SO2BaselineHaulerTruckRunningEmissions * CompactibilityValue;
                return total;
            }
        }
        public double SO2HaulerIdlingEmissionsWithCompactibility
        {
            get
            {
                double total = SO2BaselineHaulerTruckIdlingEmissions * CompactibilityValue;
                return total;
            }
        }
        public double TotalSO2BaselineTruckEmissions
        {
            get
            {

                double c02Total = SO2BaselineHaulerTruckRunningEmissions + SO2BaselineHaulerTruckIdlingEmissions;
                return c02Total;
            }
        }

        public double TotalSO2EmissionsWithSmash
        {
            get
            {
                double c02SmashTotal = SO2SmashingEmissions + SO2SMTRunningEmissions + SO2SMTIdlingEmissions + SO2HaulerRunningEmissionsWithCompactibility + SO2HaulerIdlingEmissionsWithCompactibility;
                return c02SmashTotal;
            }
        }

        public string SO2PercentSaved
        {
            get
            {
                double saved = TotalSO2BaselineTruckEmissions - TotalSO2EmissionsWithSmash;
                double percent = saved / TotalSO2BaselineTruckEmissions;
                string changed = string.Format("{0:P2}", percent);
                return changed;
            }
        }

        // CH4 Emissions
        public double CH4BaselineHaulerTruckRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                //float vmt = (LandfillDist * 2) + ToHaulerDist + FromHaulerDist;
                float vmt = 34;
                double emissionFactor = emissions.RunningCH4;
                double conversionFactor = .002204622622;
                double baslineHaulerTruckRunningEmissions = yearlyHauls * vmt * emissionFactor * conversionFactor;
                return baslineHaulerTruckRunningEmissions;
            }
        }

        public double CH4BaselineHaulerTruckIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double vit = 0.7;
                double emissionFactor = emissions.IdleCH4;
                double conversionFactor = .002204622622;
                double baselineHaulerTruckIdlingEmissions = yearlyHauls * vit * emissionFactor * conversionFactor;
                return baselineHaulerTruckIdlingEmissions;

            }
        }
        public double CH4SmashingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double smashingTime = .083333333;
                double emissionFactor = emissions.SmashCH4;
                double conversionFactor = .002204622622;
                double smashingEmissions = yearlyHauls * smashingTime * emissionFactor * conversionFactor;
                return smashingEmissions;

            }
        }
        public double CH4SMTRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                //double roundTrip = ToClientDist + FromClientDist;
                double roundTrip = 2;
                double emissionFactor = emissions.SmashRunCH4;
                double conversionFactor = .002204622622;
                double runningEmissions = yearlyHauls * roundTrip * emissionFactor * conversionFactor;
                return runningEmissions;
            }
        }
        public double CH4SMTIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                double idlingTime = .083333333;
                double emissionFactor = emissions.SmashidleCH4;
                double conversionFactor = .002204622622;
                double idlingEmissions = yearlyHauls * idlingTime * emissionFactor * conversionFactor;
                return idlingEmissions;
            }
        }
        public double CH4HaulerRunningEmissionsWithCompactibility
        {
            get
            {
                double total = CH4BaselineHaulerTruckRunningEmissions * CompactibilityValue;
                return total;
            }
        }
        public double CH4HaulerIdlingEmissionsWithCompactibility
        {
            get
            {
                double total = CH4BaselineHaulerTruckIdlingEmissions * CompactibilityValue;
                return total;
            }
        }
        public double TotalCH4BaselineTruckEmissions
        {
            get
            {

                double c02Total = CH4BaselineHaulerTruckRunningEmissions + CH4BaselineHaulerTruckIdlingEmissions;
                return c02Total;
            }
        }

        public double TotalCH4EmissionsWithSmash
        {
            get
            {
                double c02SmashTotal = CH4SmashingEmissions + CH4SMTRunningEmissions + CH4SMTIdlingEmissions + CH4HaulerRunningEmissionsWithCompactibility + CH4HaulerIdlingEmissionsWithCompactibility;
                return c02SmashTotal;
            }
        }

        public string CH4PercentSaved
        {
            get
            {
                double saved = TotalCH4BaselineTruckEmissions - TotalCH4EmissionsWithSmash;
                double percent = saved / TotalCH4BaselineTruckEmissions;
                string changed = string.Format("{0:P2}", percent);
                return changed;
            }
        }

        // CO Emissions
        public double COBaselineHaulerTruckRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                //float vmt = (LandfillDist * 2) + ToHaulerDist + FromHaulerDist;
                float vmt = 34;
                double emissionFactor = emissions.RunningCO;
                double conversionFactor = .002204622622;
                double baslineHaulerTruckRunningEmissions = yearlyHauls * vmt * emissionFactor * conversionFactor;
                return baslineHaulerTruckRunningEmissions;
            }
        }

        public double COBaselineHaulerTruckIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double vit = 0.7;
                double emissionFactor = emissions.IdleCO;
                double conversionFactor = .002204622622;
                double baselineHaulerTruckIdlingEmissions = yearlyHauls * vit * emissionFactor * conversionFactor;
                return baselineHaulerTruckIdlingEmissions;

            }
        }
        public double COSmashingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double smashingTime = .083333333;
                double emissionFactor = emissions.SmashCO;
                double conversionFactor = .002204622622;
                double smashingEmissions = yearlyHauls * smashingTime * emissionFactor * conversionFactor;
                return smashingEmissions;

            }
        }
        public double COSMTRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                //double roundTrip = ToClientDist + FromClientDist;
                double roundTrip = 2;
                double emissionFactor = emissions.SmashRunCO;
                double conversionFactor = .002204622622;
                double runningEmissions = yearlyHauls * roundTrip * emissionFactor * conversionFactor;
                return runningEmissions;
            }
        }
        public double COSMTIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                double idlingTime = .083333333;
                double emissionFactor = emissions.SmashIdleCO;
                double conversionFactor = .002204622622;
                double idlingEmissions = yearlyHauls * idlingTime * emissionFactor * conversionFactor;
                return idlingEmissions;
            }
        }
        public double COHaulerRunningEmissionsWithCompactibility
        {
            get
            {
                double total = COBaselineHaulerTruckRunningEmissions * CompactibilityValue;
                return total;
            }
        }
        public double COHaulerIdlingEmissionsWithCompactibility
        {
            get
            {
                double total = COBaselineHaulerTruckIdlingEmissions * CompactibilityValue;
                return total;
            }
        }
        public double TotalCOBaselineTruckEmissions
        {
            get
            {

                double c02Total = COBaselineHaulerTruckRunningEmissions + COBaselineHaulerTruckIdlingEmissions;
                return c02Total;
            }
        }

        public double TotalCOEmissionsWithSmash
        {
            get
            {
                double c02SmashTotal = COSmashingEmissions + COSMTRunningEmissions + COSMTIdlingEmissions + COHaulerRunningEmissionsWithCompactibility + COHaulerIdlingEmissionsWithCompactibility;
                return c02SmashTotal;
            }
        }

        public string COPercentSaved
        {
            get
            {
                double saved = TotalCOBaselineTruckEmissions - TotalCOEmissionsWithSmash;
                double percent = saved / TotalCOBaselineTruckEmissions;
                string changed = string.Format("{0:P2}", percent);
                return changed;
            }
        }

        // VOC Emissions
        public double VOCBaselineHaulerTruckRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                //float vmt = (LandfillDist * 2) + ToHaulerDist + FromHaulerDist;
                float vmt = 34;
                double emissionFactor = emissions.RunningVOC;
                double conversionFactor = .002204622622;
                double baslineHaulerTruckRunningEmissions = yearlyHauls * vmt * emissionFactor * conversionFactor;
                return baslineHaulerTruckRunningEmissions;
            }
        }

        public double VOCBaselineHaulerTruckIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double vit = 0.7;
                double emissionFactor = emissions.IdleVOC;
                double conversionFactor = .002204622622;
                double baselineHaulerTruckIdlingEmissions = yearlyHauls * vit * emissionFactor * conversionFactor;
                return baselineHaulerTruckIdlingEmissions;

            }
        }
        public double VOCSmashingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double smashingTime = .083333333;
                double emissionFactor = emissions.SmashVOC;
                double conversionFactor = .002204622622;
                double smashingEmissions = yearlyHauls * smashingTime * emissionFactor * conversionFactor;
                return smashingEmissions;

            }
        }
        public double VOCSMTRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                //double roundTrip = ToClientDist + FromClientDist;
                double roundTrip = 2;
                double emissionFactor = emissions.SmashRunVOC;
                double conversionFactor = .002204622622;
                double runningEmissions = yearlyHauls * roundTrip * emissionFactor * conversionFactor;
                return runningEmissions;
            }
        }
        public double VOCSMTIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                double idlingTime = .083333333;
                double emissionFactor = emissions.SmashIdleVOC;
                double conversionFactor = .002204622622;
                double idlingEmissions = yearlyHauls * idlingTime * emissionFactor * conversionFactor;
                return idlingEmissions;
            }
        }
        public double VOCHaulerRunningEmissionsWithCompactibility
        {
            get
            {
                double total = VOCBaselineHaulerTruckRunningEmissions * CompactibilityValue;
                return total;
            }
        }
        public double VOCHaulerIdlingEmissionsWithCompactibility
        {
            get
            {
                double total = VOCBaselineHaulerTruckIdlingEmissions * CompactibilityValue;
                return total;
            }
        }
        public double TotalVOCBaselineTruckEmissions
        {
            get
            {

                double c02Total = VOCBaselineHaulerTruckRunningEmissions + VOCBaselineHaulerTruckIdlingEmissions;
                return c02Total;
            }
        }

        public double TotalVOCEmissionsWithSmash
        {
            get
            {
                double c02SmashTotal = VOCSmashingEmissions + VOCSMTRunningEmissions + VOCSMTIdlingEmissions + VOCHaulerRunningEmissionsWithCompactibility + VOCHaulerIdlingEmissionsWithCompactibility;
                return c02SmashTotal;
            }
        }

        public string VOCPercentSaved
        {
            get
            {
                double saved = TotalVOCBaselineTruckEmissions - TotalVOCEmissionsWithSmash;
                double percent = saved / TotalVOCBaselineTruckEmissions;
                string changed = string.Format("{0:P2}", percent);
                return changed;
            }
        }

        // CO2 Emissions
        public double CO2BaselineHaulerTruckRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                //float vmt = (LandfillDist * 2) + ToHaulerDist + FromHaulerDist;
                float vmt = 34;
                double emissionFactor = emissions.RunningCO2;
                double conversionFactor = .002204622622;
                double baslineHaulerTruckRunningEmissions = yearlyHauls * vmt * emissionFactor * conversionFactor;
                return baslineHaulerTruckRunningEmissions;
            }
        }

        public double CO2BaselineHaulerTruckIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double vit = 0.7;
                double emissionFactor = emissions.IdleCO2;
                double conversionFactor = .002204622622;
                double baselineHaulerTruckIdlingEmissions = yearlyHauls * vit * emissionFactor * conversionFactor;
                return baselineHaulerTruckIdlingEmissions;

            }
        }
        public double CO2SmashingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double smashingTime = .083333333;
                double emissionFactor = emissions.SmashCO2;
                double conversionFactor = .002204622622;
                double smashingEmissions = yearlyHauls * smashingTime * emissionFactor * conversionFactor;
                return smashingEmissions;

            }
        }

        public double CO2SMTRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                //double roundTrip = ToClientDist + FromClientDist;
                double roundTrip = 2;
                double emissionFactor = emissions.SmashRunCO2;
                double conversionFactor = .002204622622;
                double runningEmissions = yearlyHauls * roundTrip * emissionFactor * conversionFactor;
                return runningEmissions;
            }
        }
        public double CO2SMTIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                double idlingTime = .083333333;
                double emissionFactor = emissions.SmashIdleCO2;
                double conversionFactor = .002204622622;
                double idlingEmissions = yearlyHauls * idlingTime * emissionFactor * conversionFactor;
                return idlingEmissions;
            }
        }
        public double CO2HaulerRunningEmissionsWithCompactibility
        {
            get
            {
                double total = CO2BaselineHaulerTruckRunningEmissions * CompactibilityValue;
                return total;
            }
        }
        public double CO2HaulerIdlingEmissionsWithCompactibility
        {
            get
            {
                double total = CO2BaselineHaulerTruckIdlingEmissions * CompactibilityValue;
                return total;
            }
        }
        public double TotalCO2BaselineTruckEmissions
        {
            get
            {

                double c02Total = CO2BaselineHaulerTruckRunningEmissions + CO2BaselineHaulerTruckIdlingEmissions;
                return c02Total;
            }
        }

        public double TotalCO2EmissionsWithSmash
        {
            get
            {
                double c02SmashTotal = CO2SmashingEmissions + CO2SMTRunningEmissions + CO2SMTIdlingEmissions + CO2HaulerRunningEmissionsWithCompactibility + CO2HaulerIdlingEmissionsWithCompactibility;
                return c02SmashTotal;
            }
        }

        public string CO2PercentSaved
        {
            get
            {
                double saved = TotalCO2BaselineTruckEmissions - TotalCO2EmissionsWithSmash;
                double percent = saved / TotalCO2BaselineTruckEmissions;
                string changed = string.Format("{0:P2}", percent);
                return changed;
            }
        }

        // CO2 eq Emissions
        public double CO2EQBaselineHaulerTruckRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                //float vmt = (LandfillDist * 2) + ToHaulerDist + FromHaulerDist;
                float vmt = 34;
                double emissionFactor = emissions.RunningCO2EQ;
                double conversionFactor = .002204622622;
                double baslineHaulerTruckRunningEmissions = yearlyHauls * vmt * emissionFactor * conversionFactor;
                return baslineHaulerTruckRunningEmissions;
            }
        }

        public double CO2EQBaselineHaulerTruckIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double vit = 0.7;
                double emissionFactor = emissions.IdleCO2EQ;
                double conversionFactor = .002204622622;
                double baselineHaulerTruckIdlingEmissions = yearlyHauls * vit * emissionFactor * conversionFactor;
                return baselineHaulerTruckIdlingEmissions;

            }
        }
        public double CO2EQSmashingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                int yearlyHauls = PreSMTYearlyHauls;
                double smashingTime = .083333333;
                double emissionFactor = emissions.SmashCO2EQ;
                double conversionFactor = .002204622622;
                double smashingEmissions = yearlyHauls * smashingTime * emissionFactor * conversionFactor;
                return smashingEmissions;

            }
        }

        public double CO2EQSMTRunningEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                //double roundTrip = ToClientDist + FromClientDist;
                double roundTrip = 2;
                double emissionFactor = emissions.SmashRunCO2EQ;
                double conversionFactor = .002204622622;
                double runningEmissions = yearlyHauls * roundTrip * emissionFactor * conversionFactor;
                return runningEmissions;
            }
        }

        public double CO2EQSMTIdlingEmissions
        {
            get
            {
                Emissions emissions = new Emissions();
                double yearlyHauls = PreSMTYearlyHauls;
                double idlingTime = .083333333;
                double emissionFactor = emissions.SmashIdleC02EQ;
                double conversionFactor = .002204622622;
                double idlingEmissions = yearlyHauls * idlingTime * emissionFactor * conversionFactor;
                return idlingEmissions;
            }
        }
        public double CO2EQHaulerRunningEmissionsWithCompactibility
        {
            get
            {
                double total = CO2EQBaselineHaulerTruckRunningEmissions * CompactibilityValue;
                return total;
            }
        }
        public double CO2EQHaulerIdlingEmissionsWithCompactibility
        {
            get
            {
                double total = CO2EQBaselineHaulerTruckIdlingEmissions * CompactibilityValue;
                return total;
            }
        }

        public double TotalCO2EQBaselineTruckEmissions
        {
            get
            {

                double c02Total = CO2EQBaselineHaulerTruckRunningEmissions + CO2EQBaselineHaulerTruckIdlingEmissions;
                return c02Total;
            }
        }

        public double TotalCO2EQEmissionsWithSmash
        {
            get
            {
                double c02SmashTotal = CO2EQSmashingEmissions + CO2EQSMTRunningEmissions + CO2EQSMTIdlingEmissions + CO2EQHaulerRunningEmissionsWithCompactibility + CO2EQHaulerIdlingEmissionsWithCompactibility;
                return c02SmashTotal;
            }
        }

        public string CO2EQPercentSaved
        {
            get
            {
                double saved = TotalCO2EQBaselineTruckEmissions - TotalCO2EQEmissionsWithSmash;
                double percent = saved / TotalCO2BaselineTruckEmissions;
                string changed = string.Format("{0:P2}", percent);
                return changed;
            }
        }


    }
}