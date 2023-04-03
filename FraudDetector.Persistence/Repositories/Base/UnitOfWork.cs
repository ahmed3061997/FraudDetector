using FraudDetector.Domain.Repositories;
using FraudDetector.Domain.Repositories.Base;
using FraudDetector.Persistence.Context;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FraudDetector.Persistence.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IFraudFlagRepository FraudFlags { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            FraudFlags = new FraudFlagRepository(context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
