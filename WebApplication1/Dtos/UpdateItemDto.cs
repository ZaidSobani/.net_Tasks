using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public record UpdateItemDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        public double Price { get; init; }
    }
}
