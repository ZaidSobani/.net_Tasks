using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1
{
    public static class Extension
    {
        public static ItemDto AsDto(this Item item) 
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate,
            };
        }
    }
}
