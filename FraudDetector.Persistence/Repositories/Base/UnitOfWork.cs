using FraudDetector.Domain.Common;
using FraudDetector.Domain.Repositories;
using FraudDetector.Domain.Repositories.Base;
using FraudDetector.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FraudDetector.Persistence.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string appUser = "SampleApplication";
        public IFraudFlagRepository FraudFlags { get; private set; }

        public UnitOfWork(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            FraudFlags = new FraudFlagRepository(context);
            if (httpContextAccessor != null)
            {
                _httpContextAccessor = httpContextAccessor;
            }
        }

        public async Task CompleteAsync()
        {
            AddAuditInfo();
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        #region Auditing
        private void AddAuditInfo()
        {
            var entities = _context.ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            var utcNow = DateTime.UtcNow;
            var user = _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? appUser;

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.Created = utcNow;
                    entity.Entity.CreatedBy = user;
                }

                if (entity.State == EntityState.Modified)
                {
                    entity.Entity.LastModified = utcNow;
                    entity.Entity.LastModifiedBy = user;
                }

            }
        }
        #endregion
    }
}
