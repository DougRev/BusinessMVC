using BusinessData;
using BusinessModels.Franchise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public  class FranchiseService
    {
        private readonly Guid _userId;

        public FranchiseService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFranchise(FranchiseCreate model)
        {
            var entity = new Franchise()
            {
                OwnerId = _userId,
                FranchiseId = model.FranchiseId,
                FranchiseName = model.FranchiseName,
                State = model.State,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Franchises.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FranchiseListItem> GetFranchises()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Franchises
                    .Select(e => new FranchiseListItem
                    {
                        FranchiseId = e.FranchiseId,
                        FranchiseName = e.FranchiseName,
                        State = e.State,


                    });
                return query.ToArray();
            }
        }


        public FranchiseDetails GetFranchiseById(int franchiseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Franchises.Single(e => e.FranchiseId == franchiseId);
                return
                    new FranchiseDetails
                    {
                        FranchiseId = entity.FranchiseId,
                        FranchiseName = entity.FranchiseName,
                        State = entity.State,
                    };
            }
        }


        public bool UpdateFranchise(FranchiseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Franchises.Single(e => e.FranchiseId == model.FranchiseId);
                entity.FranchiseName = model.FranchiseName;
                entity.State = model.State;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFranchise(int franchiseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Franchises.Single(e => e.FranchiseId == franchiseId);
                ctx.Franchises.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
