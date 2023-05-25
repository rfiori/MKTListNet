using AutoMapper;
using MKTListNet.Application.ViewModel;
using MKTListNet.Domain.Entities;
using MKTListNet.Infra.Repository;

namespace MKTListNet.Application.AutoMapper
{
    public class ViewModelToDamoinMappingProfile : Profile
    {
        public ViewModelToDamoinMappingProfile()
        {
            CreateMap<EmailViewModel, Email>();
            CreateMap<PagingResult<EmailViewModel>, PagingResult<Email>>();
        }
    }
}
