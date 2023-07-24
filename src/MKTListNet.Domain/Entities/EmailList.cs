namespace MKTListNet.Domain.Entities
{
    public class EmailList
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Type { get; set; }


        public ICollection<Email> Email { get; set; }
    }
}
