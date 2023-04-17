using System.ComponentModel.DataAnnotations;

namespace MKTListNet.Application.ViewModel
{
    public class EmailViewModel
    {
        [Key]
        public Guid EmailId { get; set; } = new Guid();

        [Required]
        [MaxLength(200)]
        public string EmailAddress { get; set; } = null!;
    }
}
