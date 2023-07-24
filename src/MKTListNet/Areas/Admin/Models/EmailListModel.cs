using MKTListNet.Application.ViewModel;

namespace MKTListNet.Areas.Admin.Models
{
    public record RetAddEmail
    {
        public int EmailAdd { get; set; }
        public int EmailReject { get; set; }
    }

    //---------------------------------------------------------------------------//

    public record EmailListDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Type { get; set; }
        public int totalEmailCount { get; set; }
    }

    //---------------------------------------------------------------------------//

    public class EmailListModel
    {
        public RetAddEmail? RetAddEmail = new();

        /// <summary>
        /// List of EmailList
        /// </summary>
        public IEnumerable<EmailListDataModel>? EmailLists { get; set; }

        /// <summary>
        /// Mensagens for View.
        /// </summary>
        public string? ViewMSG { get; set; }
    }
}
