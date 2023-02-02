using BusinessData;
using BusinessModels;
using BusinesssData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public class ClientService
    {
        private readonly Guid _userId;

        public ClientService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBusiness(BusinessCreate model)
        {
            var entity = new Client()
            {
                OwnerId = _userId,
                BusinessId = model.BusinessId,
                BusinessName = model.BusinessName,
                State = model.State,
                //FranchiseId = model.FranchiseId,
                //FranchiseeId = model.FranchiseeId,

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BusinessListItem> GetBusinesses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Clients
                    .Select(e => new BusinessListItem
                    {
                        BusinessId = e.BusinessId,
                        BusinessName = e.BusinessName,
                        State = e.State,
                        //FranchiseName = e.Franchise.FranchiseName,
                    });
                return query.ToArray();
            }
        }

        public BusinessDetails GetBusinessById(int businessId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Clients
                    .Single(e => e.BusinessId == businessId);
                return
                new BusinessDetails
                {
                    BusinessId = entity.BusinessId,
                    BusinessName = entity.BusinessName,
                    State = entity.State,
                    //FranchiseeId = entity.FranchiseeId,
                    //FranchiseeName = entity.Franchisee.FranchiseeName,
                    //FranchiseId = entity.Franchise.FranchiseId,
                    //FranchiseName = entity.Franchise.FranchiseName,
                    Compactibility = entity.Compactibility,
                    XferStation = entity.XferStation,
                    ToClientDist = entity.ToClientDist,
                    FromClientDist = entity.FromClientDist,
                    ToHaulerDist = entity.ToHaulerDist,
                    FromHaulerDist = entity.FromHaulerDist,
                    LandfillDist = entity.LandfillDist,
                    HaulsPerDay = entity.HaulsPerDay,
                    PreSMTYearlyHauls = entity.PreSMTYearlyHauls,

                    NOXBaselineHaulerTruckRunningEmissions = entity.NOXBaselineHaulerTruckRunningEmissions,
                    NOXBaselineHaulerTruckIdlingEmissions = entity.NOXBaselineHaulerTruckIdlingEmissions,
                    NOXSmashingEmissions = entity.NOXSmashingEmissions,
                    NOXSMTRunningEmissions = entity.NOXSMTRunningEmissions,
                    NOXSMTIdlingEmissions = entity.NOXSMTIdlingEmissions,
                    NOXHaulerRunningEmissionsWithCompactibility = entity.NOXHaulerRunningEmissionsWithCompactibility,
                    NOXHaulerIdlingEmissionsWithCompactibility = entity.NOXHaulerIdlingEmissionsWithCompactibility,
                    TotalNOXBaselineTruckEmissions = entity.TotalNOXBaselineTruckEmissions,
                    TotalNOXEmissionsWithSmash = entity.TotalNOXEmissionsWithSmash,
                    NOXPercentSaved = entity.NOXPercentSaved,

                    N20BaselineHaulerTruckRunningEmissions = entity.N20BaselineHaulerTruckRunningEmissions,
                    N20BaselineHaulerTruckIdlingEmissions= entity.N20BaselineHaulerTruckIdlingEmissions,
                    N20SmashingEmissions= entity.N20SmashingEmissions,
                    N20SMTRunningEmissions= entity.N20SMTRunningEmissions,
                    N20SMTIdlingEmissions= entity.N20SMTIdlingEmissions,
                    N20HaulerRunningEmissionsWithCompactibility= entity.N20HaulerRunningEmissionsWithCompactibility,
                    N20HaulerIdlingEmissionsWithCompactibility= entity.N20HaulerIdlingEmissionsWithCompactibility,
                    TotalN20BaselineTruckEmissions= entity.TotalN20BaselineTruckEmissions,
                    TotalN20EmissionsWithSmash= entity.TotalN20EmissionsWithSmash,
                    N20PercentSaved= entity.N20PercentSaved,

                    PM25BaselineHaulerTruckRunningEmissions = entity.PM25BaselineHaulerTruckRunningEmissions,
                    PM25BaselineHaulerTruckIdlingEmissions = entity.PM25BaselineHaulerTruckIdlingEmissions,
                    PM25SmashingEmissions = entity.PM25SmashingEmissions,
                    PM25SMTRunningEmissions = entity.PM25SMTRunningEmissions,
                    PM25SMTIdlingEmissions = entity.PM25SMTIdlingEmissions,
                    PM25HaulerRunningEmissionsWithCompactibility = entity.PM25HaulerRunningEmissionsWithCompactibility,
                    PM25HaulerIdlingEmissionsWithCompactibility = entity.PM25HaulerIdlingEmissionsWithCompactibility,
                    TotalPM25BaselineTruckEmissions = entity.TotalPM25BaselineTruckEmissions,
                    TotalPM25EmissionsWithSmash = entity.TotalPM25EmissionsWithSmash,
                    PM25PercentSaved = entity.PM25PercentSaved,

                    PM10BaselineHaulerTruckRunningEmissions = entity.PM10BaselineHaulerTruckRunningEmissions,
                    PM10BaselineHaulerTruckIdlingEmissions = entity.PM10BaselineHaulerTruckIdlingEmissions,
                    PM10SmashingEmissions = entity.PM10SmashingEmissions,
                    PM10SMTRunningEmissions = entity.PM10SMTRunningEmissions,
                    PM10SMTIdlingEmissions = entity.PM10SMTIdlingEmissions,
                    PM10HaulerRunningEmissionsWithCompactibility = entity.PM10HaulerRunningEmissionsWithCompactibility,
                    PM10HaulerIdlingEmissionsWithCompactibility = entity.PM10HaulerIdlingEmissionsWithCompactibility,
                    TotalPM10BaselineTruckEmissions = entity.TotalPM10BaselineTruckEmissions,
                    TotalPM10EmissionsWithSmash = entity.TotalPM10EmissionsWithSmash,
                    PM10PercentSaved = entity.PM10PercentSaved,

                    SO2BaselineHaulerTruckRunningEmissions = entity.SO2BaselineHaulerTruckRunningEmissions,
                    SO2BaselineHaulerTruckIdlingEmissions = entity.SO2BaselineHaulerTruckIdlingEmissions,
                    SO2SmashingEmissions = entity.SO2SmashingEmissions,
                    SO2SMTRunningEmissions = entity.SO2SMTRunningEmissions,
                    SO2SMTIdlingEmissions = entity.SO2SMTIdlingEmissions,
                    SO2HaulerRunningEmissionsWithCompactibility = entity.SO2HaulerRunningEmissionsWithCompactibility,
                    SO2HaulerIdlingEmissionsWithCompactibility = entity.SO2HaulerIdlingEmissionsWithCompactibility,
                    TotalSO2BaselineTruckEmissions = entity.TotalSO2BaselineTruckEmissions,
                    TotalSO2EmissionsWithSmash = entity.TotalSO2EmissionsWithSmash,
                    SO2PercentSaved = entity.SO2PercentSaved,

                    CH4BaselineHaulerTruckRunningEmissions = entity.CH4BaselineHaulerTruckRunningEmissions,
                    CH4BaselineHaulerTruckIdlingEmissions = entity.CH4BaselineHaulerTruckIdlingEmissions,
                    CH4SmashingEmissions = entity.CH4SmashingEmissions,
                    CH4SMTRunningEmissions = entity.CH4SMTRunningEmissions,
                    CH4SMTIdlingEmissions = entity.CH4SMTIdlingEmissions,
                    CH4HaulerRunningEmissionsWithCompactibility = entity.CH4HaulerRunningEmissionsWithCompactibility,
                    CH4HaulerIdlingEmissionsWithCompactibility = entity.CH4HaulerIdlingEmissionsWithCompactibility,
                    TotalCH4BaselineTruckEmissions = entity.TotalCH4BaselineTruckEmissions,
                    TotalCH4EmissionsWithSmash = entity.TotalCH4EmissionsWithSmash,
                    CH4PercentSaved = entity.CH4PercentSaved,

                    VOCBaselineHaulerTruckRunningEmissions = entity.VOCBaselineHaulerTruckRunningEmissions,
                    VOCBaselineHaulerTruckIdlingEmissions = entity.VOCBaselineHaulerTruckIdlingEmissions,
                    VOCSmashingEmissions = entity.VOCSmashingEmissions,
                    VOCSMTRunningEmissions = entity.VOCSMTRunningEmissions,
                    VOCSMTIdlingEmissions = entity.VOCSMTIdlingEmissions,
                    VOCHaulerRunningEmissionsWithCompactibility = entity.VOCHaulerRunningEmissionsWithCompactibility,
                    VOCHaulerIdlingEmissionsWithCompactibility = entity.VOCHaulerIdlingEmissionsWithCompactibility,
                    TotalVOCBaselineTruckEmissions = entity.TotalVOCBaselineTruckEmissions,
                    TotalVOCEmissionsWithSmash = entity.TotalVOCEmissionsWithSmash,
                    VOCPercentSaved = entity.VOCPercentSaved,

                    CO2BaselineHaulerTruckRunningEmissions = entity.CO2BaselineHaulerTruckRunningEmissions,
                    CO2BaselineHaulerTruckIdlingEmissions = entity.CO2BaselineHaulerTruckIdlingEmissions,
                    CO2SmashingEmissions = entity.CO2SmashingEmissions,
                    CO2SMTRunningEmissions = entity.CO2SMTRunningEmissions,
                    CO2SMTIdlingEmissions = entity.CO2SMTIdlingEmissions,
                    CO2HaulerRunningEmissionsWithCompactibility = entity.CO2HaulerRunningEmissionsWithCompactibility,
                    CO2HaulerIdlingEmissionsWithCompactibility = entity.CO2HaulerIdlingEmissionsWithCompactibility,
                    TotalCO2BaselineTruckEmissions = entity.TotalCO2BaselineTruckEmissions,
                    TotalCO2EmissionsWithSmash = entity.TotalCO2EmissionsWithSmash,
                    CO2PercentSaved = entity.CO2PercentSaved,

                    CO2EQBaselineHaulerTruckRunningEmissions = entity.CO2EQBaselineHaulerTruckRunningEmissions,
                    CO2EQBaselineHaulerTruckIdlingEmissions = entity.CO2EQBaselineHaulerTruckIdlingEmissions,
                    CO2EQSmashingEmissions = entity.CO2EQSmashingEmissions,
                    CO2EQSMTRunningEmissions = entity.CO2EQSMTRunningEmissions,
                    CO2EQSMTIdlingEmissions = entity.CO2EQSMTIdlingEmissions,
                    CO2EQHaulerRunningEmissionsWithCompactibility = entity.CO2EQHaulerRunningEmissionsWithCompactibility,
                    CO2EQHaulerIdlingEmissionsWithCompactibility = entity.CO2EQHaulerIdlingEmissionsWithCompactibility,
                    TotalCO2EQBaselineTruckEmissions = entity.TotalCO2EQBaselineTruckEmissions,
                    TotalCO2EQEmissionsWithSmash = entity.TotalCO2EQEmissionsWithSmash,
                    CO2EQPercentSaved = entity.CO2EQPercentSaved,

                };
            }
        }

        public bool UpdateBusinesses(BusinessEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Clients
                    .Single(e => e.BusinessId == model.BusinessId);
                entity.BusinessName = model.BusinessName;
                //entity.Franchisee.FranchiseeId = model.FranchiseeId;
                //entity.Franchise.FranchiseId = model.FranchiseId;
                entity.Compactibility = model.Compactibility;
                entity.State = model.State;
                entity.XferStation = model.XferStation;
                entity.ToClientDist = model.ToClientDist;
                entity.FromClientDist = model.FromClientDist;
                entity.ToHaulerDist = model.ToHaulerDist;
                entity.FromHaulerDist = model.FromHaulerDist;
                entity.LandfillDist = model.LandfillDist;
                entity.HaulsPerDay = model.HaulsPerDay;


                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteBusiness(int businessId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Clients
                    .Single(e => e.BusinessId == businessId);

                ctx.Clients.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
