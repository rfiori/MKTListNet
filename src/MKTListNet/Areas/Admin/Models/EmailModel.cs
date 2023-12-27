using MKTListNet.Application.AppViewModel;
using MKTListNet.Domain.Interfaces.Repository;
using System.Collections.ObjectModel;

namespace MKTListNet.Areas.Admin.Models
{
    public class EmailModel
    {
        public IPagingResult<EmailViewModel>? PagingReult { get; set; }

        public ICollection<EmailListDataModel> EmailListDM { get; set; } = new Collection<EmailListDataModel>();

        public int EmailListSelected { get; set; } = 0;

        public String? SearchData { get; set; }
    }
}
