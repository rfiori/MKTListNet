using AutoMapper;
using MKTListNet.Application.ViewModel;
using MKTListNet.Domain.Entities;
using MKTListNet.Infra.Repository;

namespace MKTListNet.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Email, EmailViewModel>();
            CreateMap<PagingResult<Email>, PagingResult<EmailViewModel>>();
        }
    }
}