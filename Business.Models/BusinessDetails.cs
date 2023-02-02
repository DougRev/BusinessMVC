﻿using BusinessData.Enum;
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

        [Display(Name = "NOX Hauler Running Emissions")]
        public double NOXBaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "NOX Hauler Idling Emissions")]
        public double NOXBaselineHaulerTruckIdlingEmissions { get; set; }

        [Display(Name = "NOX SMT Smashing Emissions")]
        public double NOXSmashingEmissions { get; set; }

        [Display(Name = "NOX SMT Running Emissions")]
        public double NOXSMTRunningEmissions { get; set; }

        [Display(Name = "NOX SMT Idling Emissions")]
        public double NOXSMTIdlingEmissions { get; set; }

        [Display(Name = "NOX Hauler Running Emissions w/ Smash Services")]
        public double NOXHaulerRunningEmissionsWithCompactibility { get; set; }

        [Display(Name = "NOX Hauler Idling Emissions w/ Smash Services")]
        public double NOXHaulerIdlingEmissionsWithCompactibility { get; set; }
        
        [Display(Name = "NOX Total Hauler Emissions")]
        public double TotalNOXBaselineTruckEmissions { get; set; }

        [Display(Name = "NOX Total SMT Emissions")]
        public double TotalNOXEmissionsWithSmash { get; set; }
        
        [Display(Name = "N20 Percent Saved using SMT")]
        public string NOXPercentSaved { get; set; }

        [Display(Name = "N20Hauler Running Emissions")]
        public double N20BaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "N20Hauler Idling Emissions")]
        public double N20BaselineHaulerTruckIdlingEmissions { get; set; }

        [Display(Name = "N20 SMT Smashing Emissions")]
        public double N20SmashingEmissions { get; set; }

        [Display(Name = "N20 SMT Running Emissions")]
        public double N20SMTRunningEmissions { get; set; }

        [Display(Name = "N20 SMT Idling Emissions")]
        public double N20SMTIdlingEmissions { get; set; }

        [Display(Name = "N20 Hauler Running Emissions w/ Smash Services")]
        public double N20HaulerRunningEmissionsWithCompactibility { get; set; }

        [Display(Name = "N20 Hauler Idling Emissions w/ Smash Services")]
        public double N20HaulerIdlingEmissionsWithCompactibility { get; set; }
        
        [Display(Name = "N20 Total Hauler Emissions")]
        public double TotalN20BaselineTruckEmissions { get; set; }
        
        [Display(Name = "N20 Total SMT Emissions")]
        public double TotalN20EmissionsWithSmash { get; set; }

        [Display(Name = "N20 Percent Saved using SMT")]
        public string N20PercentSaved { get; set; }

        //PM2.5

        [Display(Name = "PM2.5Hauler Running Emissions")]
        public double PM25BaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "PM2.5Hauler Idling Emissions")]
        public double PM25BaselineHaulerTruckIdlingEmissions { get; set; }

        [Display(Name = "PM2.5 SMT Smashing Emissions")]
        public double PM25SmashingEmissions { get; set; }

        [Display(Name = "PM2.5 SMT Running Emissions")]
        public double PM25SMTRunningEmissions { get; set; }

        [Display(Name = "PM2.5 SMT Idling Emissions")]
        public double PM25SMTIdlingEmissions { get; set; }

        [Display(Name = "PM2.5 Hauler Running Emissions w/ Smash Services")]
        public double PM25HaulerRunningEmissionsWithCompactibility { get; set; }

        [Display(Name = "PM2.5 Hauler Idling Emissions w/ Smash Services")]
        public double PM25HaulerIdlingEmissionsWithCompactibility { get; set; }
        
        [Display(Name = "PM2.5 Total Hauler Emissions")]
        public double TotalPM25BaselineTruckEmissions { get; set; }
        
        [Display(Name = "PM10 Total SMT Emissions")]
        public double TotalPM25EmissionsWithSmash { get; set; }

        [Display(Name = "PM2.5 Percent Saved using SMT")]
        public string PM25PercentSaved { get; set; }

        //PM2.5 Emissions

        [Display(Name = "PM10 Hauler Running Emissions")]
        public double PM10BaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "PM10 Hauler Idling Emissions")]
        public double PM10BaselineHaulerTruckIdlingEmissions { get; set; }

        [Display(Name = "PM10 SMT Smashing Emissions")]
        public double PM10SmashingEmissions { get; set; }

        [Display(Name = "PM10 SMT Running Emissions")]
        public double PM10SMTRunningEmissions { get; set; }

        [Display(Name = "PM10 SMT Idling Emissions")]
        public double PM10SMTIdlingEmissions { get; set; }

        [Display(Name = "PM10 Hauler Running Emissions w/ Smash Services")]
        public double PM10HaulerRunningEmissionsWithCompactibility { get; set; }

        [Display(Name = "PM10 Hauler Idling Emissions w/ Smash Services")]
        public double PM10HaulerIdlingEmissionsWithCompactibility { get; set; }

        [Display(Name = "PM10 Total Hauler Emissions")]
        public double TotalPM10BaselineTruckEmissions { get; set; }

        [Display(Name = "PM10 Total SMT Emissions")]
        public double TotalPM10EmissionsWithSmash { get; set; }

        [Display(Name = "PM10 Percent Saved using SMT")]
        public string PM10PercentSaved { get; set; }

        //PM10 Emissions


        [Display(Name = "SO2 Hauler Running Emissions")]
        public double SO2BaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "SO2 Hauler Idling Emissions")]
        public double SO2BaselineHaulerTruckIdlingEmissions { get; set; }

        [Display(Name = "SO2 SMT Smashing Emissions")]
        public double SO2SmashingEmissions { get; set; }

        [Display(Name = "SO2 SMT Running Emissions")]
        public double SO2SMTRunningEmissions { get; set; }

        [Display(Name = "SO2 SMT Idling Emissions")]
        public double SO2SMTIdlingEmissions { get; set; }

        [Display(Name = "SO2 Hauler Running Emissions w/ Smash Services")]
        public double SO2HaulerRunningEmissionsWithCompactibility { get; set; }

        [Display(Name = "SO2 Hauler Running Emissions w/ Smash Services")]
        public double SO2HaulerIdlingEmissionsWithCompactibility { get; set; }

        [Display(Name = "SO2 Total Hauler Emissions")]
        public double TotalSO2BaselineTruckEmissions { get; set; }

        [Display(Name = "SO2 Total SMT Emissions")]
        public double TotalSO2EmissionsWithSmash { get; set; }

        [Display(Name = "SO2 Percent Saved using SMT")]
        public string SO2PercentSaved { get; set; }

        //CH4 Emissions

        [Display(Name = "CH4 Hauler Running Emissions")]
        public double CH4BaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "CH4 Hauler Idling Emissions")]
        public double CH4BaselineHaulerTruckIdlingEmissions { get; set; }

        [Display(Name = "CH4 SMT Smashing Emissions")]
        public double CH4SmashingEmissions { get; set; }

        [Display(Name = "CH4 SMT Running Emissions")]
        public double CH4SMTRunningEmissions { get; set; }

        [Display(Name = "CH4 SMT Idling Emissions")]
        public double CH4SMTIdlingEmissions { get; set; }

        [Display(Name = "CH4 Hauler Running Emissions w/ Smash Services")]
        public double CH4HaulerRunningEmissionsWithCompactibility { get; set; }

        [Display(Name = "CH4 Hauler Idling Emissions w/ Smash Services")]
        public double CH4HaulerIdlingEmissionsWithCompactibility { get; set; }

        [Display(Name = "CH4 Total Hauler Emissions")]
        public double TotalCH4BaselineTruckEmissions { get; set; }

        [Display(Name = "CH4 Total SMT Emissions")]
        public double TotalCH4EmissionsWithSmash { get; set; }

        [Display(Name = "CH4 Percent Saved using SMT")]
        public string CH4PercentSaved { get; set; }

        // CO Emissions

        [Display(Name = "CO Hauler Running Emissions")]
        public double COBaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "COHauler Idling Emissions")]
        public double COBaselineHaulerTruckIdlingEmissions { get; set; }

        [Display(Name = "CO SMT Smashing Emissions")]
        public double COSmashingEmissions { get; set; }

        [Display(Name = "CO SMT Running Emissions")]
        public double COSMTRunningEmissions { get; set; }

        [Display(Name = "CO SMT Idling Emissions")]
        public double COSMTIdlingEmissions { get; set; }

        [Display(Name = "CO Hauler Running Emissions w/ Smash Services")]
        public double COHaulerRunningEmissionsWithCompactibility { get; set; }

        [Display(Name = "CO Hauler Idling Emissions w/ Smash Services")]
        public double COHaulerIdlingEmissionsWithCompactibility { get; set; }

        [Display(Name = "CO Total Hauler Emissions")]
        public double TotalCOBaselineTruckEmissions { get; set; }

        [Display(Name = "CO Total SMT Emissions")]
        public double TotalCOEmissionsWithSmash { get; set; }

        [Display(Name = "CO Percent Saved using SMT")]
        public string COPercentSaved { get; set; }

        //VOC Emissions

        [Display(Name = "VOC Hauler Running Emissions")]
        public double VOCBaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "VOC Hauler Idling Emissions")]
        public double VOCBaselineHaulerTruckIdlingEmissions { get; set; }

        [Display(Name = "VOC SMT Smashing Emissions")]
        public double VOCSmashingEmissions { get; set; }

        [Display(Name = "VOC SMT Running Emissions")]
        public double VOCSMTRunningEmissions { get; set; }

        [Display(Name = "VOC SMT Idling Emissions")]
        public double VOCSMTIdlingEmissions { get; set; }

        [Display(Name = "VOC Hauler Running Emissions w/ Smash Services")]
        public double VOCHaulerRunningEmissionsWithCompactibility { get; set; }

        [Display(Name = "VOC Hauler Idling Emissions w/ Smash Services")]
        public double VOCHaulerIdlingEmissionsWithCompactibility { get; set; }

        [Display(Name = "VOC Total Hauler Emissions")]
        public double TotalVOCBaselineTruckEmissions { get; set; }

        [Display(Name = "VOC Total Saved Using SMT")]
        public double TotalVOCEmissionsWithSmash { get; set; }

        [Display(Name = "VOC Total SMT Emissions")]
        public string VOCPercentSaved { get; set; }

        //CO2 Emissions

        [Display(Name = "CO2 Hauler Running Emissions")]
        public double CO2BaselineHaulerTruckRunningEmissions { get; set; }

        [Display(Name = "CO2 Hauler Idling Emissions")]
        public double CO2BaselineHaulerTruckIdlingEmissions { get; set; }

        [Display(Name = "CO2 SMT Smashing Emissions")]
        public double CO2SmashingEmissions { get; set; }

        [Display(Name = "CO2 SMT Running Emissions")]
        public double CO2SMTRunningEmissions { get; set; }

        [Display(Name = "CO2 SMT Idling Emissions")]
        public double CO2SMTIdlingEmissions { get; set; }

        [Display(Name = "CO2 Hauler Running Emissions w/ Smash Services")]
        public double CO2HaulerRunningEmissionsWithCompactibility { get; set; }

        [Display(Name = "CO2 Hauler Idling Emissions w/ Smash Services")]
        public double CO2HaulerIdlingEmissionsWithCompactibility { get; set; }

        [Display(Name = "CO2 Total Hauler Emissions")]
        public double TotalCO2BaselineTruckEmissions { get; set; }

        [Display(Name = "CO2 Total SMT Emissions")]
        public double TotalCO2EmissionsWithSmash { get; set; }

        [Display(Name = "CO2 Percent Saved using SMT")]
        public string CO2PercentSaved { get; set; }


        /* This is CO2EQ not sure this will be used at all
         * 
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
        public string CO2EQPercentSaved { get; set; }*/

    }
}
