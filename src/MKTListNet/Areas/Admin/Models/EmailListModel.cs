namespace MKTListNet.Areas.Admin.Models
{
    public class EmailListModel
    {
        public RetAddEmailModel? RetAddEmail = new();

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
