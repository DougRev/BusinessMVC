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
                FranchiseId = model.FranchiseId,
                FranchiseeId = model.FranchiseeId,

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
                        FranchiseName = e.Franchise.FranchiseName,
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
                    FranchiseeId = entity.FranchiseeId,
                    FranchiseeName = entity.Franchisee.FranchiseeName,
                    FranchiseId = entity.Franchise.FranchiseId,
                    FranchiseName = entity.Franchise.FranchiseName,
                    XferStation = entity.XferStation,
                    ToClientDist = entity.ToClientDist,
                    FromClientDist = entity.FromClientDist,
                    ToHaulerDist = entity.ToHaulerDist,
                    FromHaulerDist = entity.FromHaulerDist,
                    LandfillDist = entity.LandfillDist,
                    HaulsPerDay = entity.HaulsPerDay,
                    PreSMTYearlyHauls = entity.PreSMTYearlyHauls,
                    Num1 = entity.Num1,
                    EmissionsMath = entity.EmissionsMath,
                    BaselineHaulerTruckRunningEmissions = entity.BaselineHaulerTruckRunningEmissions,
                    BaselineHaulerTruckIdlingEmissions = entity.BaselineHaulerTruckIdlingEmissions,
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
                entity.Franchisee.FranchiseeId = model.FranchiseeId;
                entity.Franchise.FranchiseId = model.FranchiseId;
                entity.Franchise.FranchiseName = model.FranchiseName;
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
