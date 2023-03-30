using BusinessData;
using BusinessModels.Franchise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using BusinessData.Enum;

namespace BusinessServices
{
    public  class FranchiseService
    {
        private readonly Guid _userId;

        public FranchiseService(Guid userId)
        {
            _userId = userId;
        }
        public FranchiseService() { }


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



        /*public FranchiseDetails GetClientsByFranchiseId(int franchiseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var franchise = ctx.Franchises
                    .Single(f => f.FranchiseId == franchiseId);

                var clients = franchise.Clients
                    .Where(c => c.FranchiseId == franchiseId) // Filter the clients by franchise ID
                    .ToList();

                return new FranchiseDetails
                {
                    FranchiseId = franchise.FranchiseId,
                    FranchiseName = franchise.FranchiseName,
                    State = franchise.State,
                    Clients = clients // Set the clients for the franchise
                };
            }
        }*/

        public FranchiseDetails GetClientsByFranchiseId(int franchiseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var franchise = ctx.Franchises
                    .SingleOrDefault(f => f.FranchiseId == franchiseId);

                if (franchise == null)
                {
                    return null;
                }

                var clients = ctx.Clients
                    .Where(c => c.FranchiseId == franchiseId)
                    .ToList();

                return new FranchiseDetails
                {
                    FranchiseId = franchise.FranchiseId,
                    FranchiseName = franchise.FranchiseName,
                    Clients = clients
                };
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

        public double GetTotalCO2SavedForFranchiseById(int franchiseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
            double totalCO2Saved = 0;
            var franchise = ctx.Franchises
                                .Include(f => f.Clients)
                                .SingleOrDefault(f => f.FranchiseId == franchiseId);

            if (franchise != null)
            {
                foreach (var client in franchise.Clients)
                {
                    totalCO2Saved += client.TotalCO2SavedV2;
                }
            }
            return totalCO2Saved;

            }

        }
        public int CountDistinctStatesWithClientsByFranchiseId(int franchiseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                int stateReach = 0;
                var franchise = ctx.Franchises
                                    .Include(f => f.Clients)
                                    .SingleOrDefault(f => f.FranchiseId == franchiseId);

                if (franchise != null)
                {
                    // Count distinct states of the clients within the franchise
                    return stateReach = franchise.Clients.Select(c => c.State).Distinct().Count();
                }

                return 0;
            }
        }

        public int CountClientsByFranchiseId(int franchiseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var franchise = ctx.Franchises
                                    .Include(f => f.Clients)
                                    .SingleOrDefault(f => f.FranchiseId == franchiseId);

                if (franchise != null)
                {
                    // Count the clients within the franchise
                    return franchise.Clients.Count;
                }

                return 0;
            }
        }


    }
}
