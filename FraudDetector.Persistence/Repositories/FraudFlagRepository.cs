using FraudDetector.Domain.Entities;
using FraudDetector.Domain.Repositories;
using FraudDetector.Persistence.Context;
using FraudDetector.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FraudDetector.Persistence.Repositories
{
    public class FraudFlagRepository : GenericRepository<FraudFlag>, IFraudFlagRepository
    {
        public FraudFlagRepository(ApplicationDbContext context) : base(context) { }

        public override async Task<IEnumerable<FraudFlag>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "{Repo} All function error", typeof(FraudFlagRepository));
                return new List<FraudFlag>();
            }
        }
    }
}
