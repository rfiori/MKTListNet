using MKTListNet.Application.AppViewModel;

namespace MKTListNet.Areas.Admin.Models
{
    //---------------------------------------------------------------------------//

    public class EmailListDataModel
    {
        //public int Id { get; set; }

        //public string Name { get; set; } = null!;

        //public string? Type { get; set; }

        public EmailListViewModel EmailList { get; set; } = new EmailListViewModel();

        public int TotalEmailCount { get; set; }
    }
}
