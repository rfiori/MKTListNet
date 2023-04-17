using AutoMapper;
using MKTListNet.Application.ViewModel;
using MKTListNet.Domain.Entities;

namespace MKTListNet.Application.AutoMapper
{
    internal class ViewModelToDamoinMappingProfile : Profile
    {
        public ViewModelToDamoinMappingProfile()
        {
            CreateMap<EmailViewModel, Email>();
        }
    }
}
