using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public class CreateItemDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
