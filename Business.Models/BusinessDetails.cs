using BusinessData.Enum;
using BusinesssData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessModels
{
    public class BusinessDetails
    {
        [Display(Name = "Client ID")]
        public int BusinessId { get; set; }

        [Display(Name = "Client Name")]
        public string BusinessName { get; set; }
        public State State { get; set; }
        public Guid OwnerId { get; set; }
        //public virtual Franchisee Franchisee { get; set; }
        public int FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public int FranchiseeId { get; set; }
        public string FranchiseeName { get; set; }
        public Compactibility Compactibility { get; set; }

        [Display(Name = "Transfer Station")]
        public bool XferStation { get; set; }

        [Display(Name = "SMT Distance to Client")]
        public float ToClientDist { get; set; }

        [Display(Name = "SMT Distance from Client")]
        public float FromClientDist { get; set; }

        [Display(Name = "Hauler Distance to Customer")]
        public float ToHaulerDist { get; set; }

        [Display(Name = "Hauler Distance from Customer")]
        public float FromHaulerDist { get; set; }

        [Display(Name = "Distance to Landfill")]
        public float LandfillDist { get; set; }

        [Display(Name = "Pre-SMT Hauls per Day")]
        public int HaulsPerDay { get; set; }

        [Display(Name = "Pre-SMT Est. Yearly Hauls")]
        public int PreSMTYearlyHauls { get; set; }

        //NOX

        [Display(Name = "Hauler Running Emissions")]
        public double NOXBaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "Hauler Idling Emissions")]
        public double NOXBaselineHaulerTruckIdlingEmissions { get; set; }
        public double NOXSmashingEmissions { get; set; }
        public double NOXSMTRunningEmissions { get; set; }
        public double NOXSMTIdlingEmissions { get; set; }
        public double NOXHaulerRunningEmissionsWithCompactibility { get; set; }
        public double NOXHaulerIdlingEmissionsWithCompactibility { get; set; }
        public double TotalNOXBaselineTruckEmissions { get; set; }
        public double TotalNOXEmissionsWithSmash { get; set; }
        public string NOXPercentSaved { get; set; }

        [Display(Name = "Hauler Running Emissions")]
        public double N20BaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "Hauler Idling Emissions")]
        public double N20BaselineHaulerTruckIdlingEmissions { get; set; }
        public double N20SmashingEmissions { get; set; }
        public double N20SMTRunningEmissions { get; set; }
        public double N20SMTIdlingEmissions { get; set; }
        public double N20HaulerRunningEmissionsWithCompactibility { get; set; }
        public double N20HaulerIdlingEmissionsWithCompactibility { get; set; }
        public double TotalN20BaselineTruckEmissions { get; set; }
        public double TotalN20EmissionsWithSmash { get; set; }
        public string N20PercentSaved { get; set; }

        [Display(Name = "Hauler Running Emissions")]
        public double PM25BaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "Hauler Idling Emissions")]
        public double PM25BaselineHaulerTruckIdlingEmissions { get; set; }
        public double PM25SmashingEmissions { get; set; }
        public double PM25SMTRunningEmissions { get; set; }
        public double PM25SMTIdlingEmissions { get; set; }
        public double PM25HaulerRunningEmissionsWithCompactibility { get; set; }
        public double PM25HaulerIdlingEmissionsWithCompactibility { get; set; }
        public double TotalPM25BaselineTruckEmissions { get; set; }
        public double TotalPM25EmissionsWithSmash { get; set; }
        public string PM25PercentSaved { get; set; }


        [Display(Name = "Hauler Running Emissions")]
        public double PM10BaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "Hauler Idling Emissions")]
        public double PM10BaselineHaulerTruckIdlingEmissions { get; set; }
        public double PM10SmashingEmissions { get; set; }
        public double PM10SMTRunningEmissions { get; set; }
        public double PM10SMTIdlingEmissions { get; set; }
        public double PM10HaulerRunningEmissionsWithCompactibility { get; set; }
        public double PM10HaulerIdlingEmissionsWithCompactibility { get; set; }
        public double TotalPM10BaselineTruckEmissions { get; set; }
        public double TotalPM10EmissionsWithSmash { get; set; }
        public string PM10PercentSaved { get; set; }


        [Display(Name = "Hauler Running Emissions")]
        public double SO2BaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "Hauler Idling Emissions")]
        public double SO2BaselineHaulerTruckIdlingEmissions { get; set; }
        public double SO2SmashingEmissions { get; set; }
        public double SO2SMTRunningEmissions { get; set; }
        public double SO2SMTIdlingEmissions { get; set; }
        public double SO2HaulerRunningEmissionsWithCompactibility { get; set; }
        public double SO2HaulerIdlingEmissionsWithCompactibility { get; set; }
        public double TotalSO2BaselineTruckEmissions { get; set; }
        public double TotalSO2EmissionsWithSmash { get; set; }
        public string SO2PercentSaved { get; set; }


        [Display(Name = "Hauler Running Emissions")]
        public double CH4BaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "Hauler Idling Emissions")]
        public double CH4BaselineHaulerTruckIdlingEmissions { get; set; }
        public double CH4SmashingEmissions { get; set; }
        public double CH4SMTRunningEmissions { get; set; }
        public double CH4SMTIdlingEmissions { get; set; }
        public double CH4HaulerRunningEmissionsWithCompactibility { get; set; }
        public double CH4HaulerIdlingEmissionsWithCompactibility { get; set; }
        public double TotalCH4BaselineTruckEmissions { get; set; }
        public double TotalCH4EmissionsWithSmash { get; set; }
        public string CH4PercentSaved { get; set; }


        [Display(Name = "Hauler Running Emissions")]
        public double VOCBaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "Hauler Idling Emissions")]
        public double VOCBaselineHaulerTruckIdlingEmissions { get; set; }
        public double VOCSmashingEmissions { get; set; }
        public double VOCSMTRunningEmissions { get; set; }
        public double VOCSMTIdlingEmissions { get; set; }
        public double VOCHaulerRunningEmissionsWithCompactibility { get; set; }
        public double VOCHaulerIdlingEmissionsWithCompactibility { get; set; }
        public double TotalVOCBaselineTruckEmissions { get; set; }
        public double TotalVOCEmissionsWithSmash { get; set; }
        public string VOCPercentSaved { get; set; }


        [Display(Name = "Hauler Running Emissions")]
        public double CO2BaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "Hauler Idling Emissions")]
        public double CO2BaselineHaulerTruckIdlingEmissions { get; set; }
        public double CO2SmashingEmissions { get; set; }
        public double CO2SMTRunningEmissions { get; set; }
        public double CO2SMTIdlingEmissions { get; set; }
        public double CO2HaulerRunningEmissionsWithCompactibility { get; set; }
        public double CO2HaulerIdlingEmissionsWithCompactibility { get; set; }
        public double TotalCO2BaselineTruckEmissions { get; set; }
        public double TotalCO2EmissionsWithSmash { get; set; }
        public string CO2PercentSaved { get; set; }


        [Display(Name = "Hauler Running Emissions")]
        public double CO2EQBaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "Hauler Idling Emissions")]
        public double CO2EQBaselineHaulerTruckIdlingEmissions { get; set; }
        public double CO2EQSmashingEmissions { get; set; }
        public double CO2EQSMTRunningEmissions { get; set; }
        public double CO2EQSMTIdlingEmissions { get; set; }
        public double CO2EQHaulerRunningEmissionsWithCompactibility { get; set; }
        public double CO2EQHaulerIdlingEmissionsWithCompactibility { get; set; }
        public double TotalCO2EQBaselineTruckEmissions { get; set; }
        public double TotalCO2EQEmissionsWithSmash { get; set; }
        public string CO2EQPercentSaved { get; set; }

    }
}
