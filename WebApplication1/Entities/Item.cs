using WebApplication1.Dtos;

namespace WebApplication1.Entities
{
    public record Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

    }
}
