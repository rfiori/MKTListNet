namespace MKTListNet.Domain.Entities
{
    public class Email
    {
        public Guid Id { get; } = new Guid();

        public String? Name { get; set; }

        public string EmailAddress { get; set; } = null!;
    }
}
