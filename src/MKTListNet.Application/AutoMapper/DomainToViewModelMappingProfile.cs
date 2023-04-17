using AutoMapper;
using MKTListNet.Application.ViewModel;
using MKTListNet.Domain.Entities;

namespace MKTListNet.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Email, EmailViewModel>();
        }
    }
}