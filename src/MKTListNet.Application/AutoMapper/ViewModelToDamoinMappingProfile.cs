﻿using AutoMapper;
using MKTListNet.Application.ViewModel;
using MKTListNet.Application.ViewModwl;
using MKTListNet.Domain.Entities;
using MKTListNet.Infra.Repository;

namespace MKTListNet.Application.AutoMapper
{
    public class ViewModelToDamoinMappingProfile : Profile
    {
        public ViewModelToDamoinMappingProfile()
        {
            CreateMap<EmailViewModel, Email>();
            CreateMap<EmailListViewModel, EmailList>();
            CreateMap<PagingResult<EmailViewModel>, PagingResult<Email>>();
            CreateMap<EmailEmailListViewModel, EmailEmailList>();
        }
    }
}
