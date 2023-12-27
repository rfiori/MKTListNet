namespace MKTListNet.Domain.Entities
{
    public class Email
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public String? Name { get; set; }

        public string EmailAddress { get; set; } = null!;


        public virtual ICollection<EmailList>? EmailList { get; set; }
    }
}
