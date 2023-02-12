namespace MKTListNet.Domain.Entities
{
    public class Email
    {
        public Guid EmailId { get; set; } = new Guid();

        public string EmailAddress { get; set; } = null!;
    }
}