namespace MKTListNet.Domain.Entities
{
    public class EmailList
    {
        public int ListId { get; set; }

        public string Name { get; set; } = null!;
        
        public string Type { get; set; } = null!;
    }
}
