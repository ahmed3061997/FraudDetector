using AutoMapper;
using FraudDetector.Application.DTOs.Flag;
using FraudDetector.Domain.Entities;

namespace FraudDetector.Application.Mappers
{
    public class FraudFlagProfile : Profile
    {
        public FraudFlagProfile() {
            CreateMap<FraudFlag, FraudFlagDto>()
                .ReverseMap();
        }
    }
}
