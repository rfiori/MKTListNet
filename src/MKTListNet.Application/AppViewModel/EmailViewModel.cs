using System.ComponentModel.DataAnnotations;

namespace MKTListNet.Application.AppViewModel
{
    public class EmailViewModel
    {
        [Key]
        public Guid Id { get; set; } = new Guid();

        public String? Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string EmailAddress { get; set; } = null!;
    }
}
