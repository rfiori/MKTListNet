namespace MKTListNet.Domain.Entities
{
    public class EmailList
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Type { get; set; }


        public virtual ICollection<Email> Emails { get; set; } = null!;
    }
}
