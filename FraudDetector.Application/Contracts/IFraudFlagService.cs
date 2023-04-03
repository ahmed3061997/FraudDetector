using FraudDetector.Application.DTOs.Flag;
using FraudDetector.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FraudDetector.Application.Contracts
{
    public interface IFraudFlagService
    {
        Task<List<FraudFlagDto>> GetAllAsync();
        Task<FraudFlagDto?> GetByIdAsync(int id);
        Task<FraudFlagDto> Create(FraudFlagDto dto);
        Task<FraudFlagDto> Update(FraudFlagDto dto);
        Task<bool> Delete(int id);
    }
}
