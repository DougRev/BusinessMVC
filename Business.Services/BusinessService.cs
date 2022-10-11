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
    public class BusinessService
    {
        private readonly Guid _userId;

        public BusinessService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBusiness(BusinessCreate model)
        {
            var entity = new Business()
            {
                OwnerId = _userId,
                BusinessId = model.BusinessId,
                BusinessName = model.BusinessName,
                FranchiseeId = model.FranchiseeId,

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Businesses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BusinessListItem> GetBusinesses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Businesses
                    .Select(e => new BusinessListItem
                    {
                        BusinessId = e.BusinessId,
                        BusinessName = e.BusinessName,
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
                    .Businesses
                    .Single(e => e.BusinessId == businessId);
                return
                new BusinessDetails
                {
                    BusinessId = entity.BusinessId,
                    BusinessName = entity.BusinessName,
                    FranchiseeId = entity.FranchiseeId,
                    FranchiseeName = entity.Franchisee.FranchiseeName,
                };
            }
        }

        public bool UpdateBusinesses(BusinessEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Businesses
                    .Single(e => e.BusinessId == model.BusinessId);
                entity.BusinessName = model.BusinessName;
                entity.Franchisee.FranchiseeId = model.FranchiseeId;

                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteBusiness(int businessId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Businesses
                    .Single(e => e.BusinessId == businessId);

                ctx.Businesses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
