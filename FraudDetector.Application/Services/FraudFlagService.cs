using AutoMapper;
using FraudDetector.Application.Contracts;
using FraudDetector.Application.DTOs.Flag;
using FraudDetector.Domain.Entities;
using FraudDetector.Domain.Repositories.Base;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudDetector.Application.Services
{
    public class FraudFlagService : IFraudFlagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FraudFlagService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<FraudFlagDto>> GetAllAsync()
        {
            var flags = await _unitOfWork.FraudFlags.All();
            return flags.Select(x => _mapper.Map<FraudFlagDto>(x)).ToList();
        }

        public async Task<FraudFlagDto?> GetByIdAsync(int id)
        {
            var flag = await _unitOfWork.FraudFlags.GetByIdAsync(id);
            if (flag != null)
                return _mapper.Map<FraudFlagDto>(flag);
            return null;
        }

        public async Task<FraudFlagDto> Create(FraudFlagDto dto)
        {
            var flag = _mapper.Map<FraudFlag>(dto);
            await _unitOfWork.FraudFlags.Add(flag);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<FraudFlagDto>(flag);
        }

        public async Task<FraudFlagDto> Update(FraudFlagDto dto)
        {
            var flag = await _unitOfWork.FraudFlags.GetByIdAsync(dto.Id);
            _mapper.Map(dto, flag);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<FraudFlagDto>(flag);
        }

        public async Task<bool> Delete(int id)
        {
            var flag = await _unitOfWork.FraudFlags.GetByIdAsync(id);
            if (flag == null)
                return false;

            _unitOfWork.FraudFlags.Delete(flag);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
