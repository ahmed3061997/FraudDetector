using System;
using System.Threading.Tasks;

namespace FraudDetector.Domain.Repositories.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IFraudFlagRepository FraudFlags { get; }
        Task CompleteAsync();
    }
}
