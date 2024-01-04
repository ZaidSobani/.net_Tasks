using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Entities;



namespace WebApplication1.Repositories
{
    public class inMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Sword", Price = 10, CreatedDate = DateTimeOffset.Now},
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 7, CreatedDate = DateTimeOffset.Now },
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 5, CreatedDate = DateTimeOffset.Now },
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}
