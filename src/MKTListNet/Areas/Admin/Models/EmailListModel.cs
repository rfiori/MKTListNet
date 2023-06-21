using MKTListNet.Application.ViewModel;

namespace MKTListNet.Areas.Admin.Models
{
    public class EmailListModel
    {
        /// <summary>
        /// List of EmailList
        /// </summary>
        public IEnumerable<EmailListViewModel>? lstEmailList;

        /// <summary>
        /// Mensagens for View.
        /// </summary>
        public string? ViewMSG;
    }
}
