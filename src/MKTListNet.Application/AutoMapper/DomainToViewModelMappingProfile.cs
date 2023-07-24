using AutoMapper;
using MKTListNet.Application.ViewModel;
using MKTListNet.Application.ViewModwl;
using MKTListNet.Domain.Entities;
using MKTListNet.Infra.Repository;

namespace MKTListNet.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Email, EmailViewModel>();
            CreateMap<EmailList, EmailListViewModel>();
            CreateMap<PagingResult<Email>, PagingResult<EmailViewModel>>();
            CreateMap<EmailEmailList, EmailEmailListViewModel>();
        }
    }
}