using MKTListNet.Application.Interface;
using MKTListNet.Application.ViewModel;

namespace MKTListNet.Areas.Admin.Models
{
    public record RetAddEmail
    {
        public int EmailAdd { get; set; }
        public int EmailReject { get; set; }
    }

    //---------------------------------------------------------------------------//

    public class EmailListModel
    {
        public RetAddEmail? RetAddEmail = new();

        /// <summary>
        /// List of EmailList
        /// </summary>
        public IEnumerable<EmailListViewModel>? EmailLists { get; set; }

        /// <summary>
        /// Mensagens for View.
        /// </summary>
        public string? ViewMSG { get; set; }
    }
}
