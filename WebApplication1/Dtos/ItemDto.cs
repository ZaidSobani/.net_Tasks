namespace WebApplication1.Dtos
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
