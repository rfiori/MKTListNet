using AutoMapper;
using MKTListNet.Application.Interface;
using MKTListNet.Application.ViewModwl;
using MKTListNet.Domain.Entities;
using MKTListNet.Domain.Interface.Services;

namespace MKTListNet.Application.Services
{
    public class EmailEmailListAppService : IEmailEmailListAppServive
    {
        private readonly IMapper _mapper;
        private readonly IEmailEmailListService _emailEmlLstService;

        //----------------------------------------------------------//

        public EmailEmailListAppService(IMapper mapper, IEmailEmailListService emailEmlLstService)
        {
            _mapper = mapper;
            _emailEmlLstService = emailEmlLstService;
        }

        //----------------------------------------------------------//


        public int Add(Guid emailId, int emailListId)
        {
            return _emailEmlLstService.Add(emailId, emailListId);
        }

        public async Task<int> AddBulkAsync(IList<Guid> lstEmail, int emailListId)
        {
            return await _emailEmlLstService.AddBulkAsync(lstEmail, emailListId);
        }

        public IEnumerable<EmailEmailListViewModel>? GetByEmailId(Guid emailListId)
        {
            return _mapper.Map<IEnumerable<EmailEmailListViewModel>>(_emailEmlLstService.GetByEmailId(emailListId));
        }

        public IEnumerable<EmailEmailListViewModel>? GetByEmailListId(int id)
        {
            var x = _emailEmlLstService.GetByEmailListId(id);
            return _mapper.Map<IEnumerable<EmailEmailListViewModel>>(x);
        }

        public int RemoveEmailId(Guid EmailId)
        {
            return _emailEmlLstService.RemoveEmailId(EmailId);
        }

        public int RemoveEmailListId(int emailEmlLstId)
        {
            return _emailEmlLstService.RemoveEmailListId(emailEmlLstId);
        }

        public EmailEmailListViewModel? Update(EmailEmailListViewModel emailEmlLst)
        {
            var ret = _emailEmlLstService.Update(_mapper.Map<EmailEmailList>(emailEmlLst));
            return _mapper.Map<EmailEmailListViewModel>(ret);
        }

        public int SaveChanges()
        {
            return _emailEmlLstService.SaveChanges();
        }
    }
}
