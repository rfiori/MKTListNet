using System.ComponentModel.DataAnnotations;

namespace MKTListNet.Application.ViewModwl
{
    public class EmailEmailListViewModel
    {
        [Key]
        public Guid EmailId { get; set; }

        [Key]
        public int EmailListId { get; set; }
    }
}
