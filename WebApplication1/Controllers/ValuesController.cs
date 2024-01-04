using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ItemContext _dbContext;

        public ValuesController(ItemContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            if(_dbContext.Items == null)
            {
                return NotFound();
            }
            return _dbContext.Items;
        }

        [HttpGet("{id}")] 
        public ActionResult<Item> GetItem(Guid id) 
        {
            var item = _dbContext.Items.Where(item => item.Id == id).SingleOrDefault();

            if(item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public ActionResult<Item> CreateItem(Item item)
        {
            item = new Item
            {
                Id = Guid.NewGuid(),
                Name = item.Name,
                Price = item.Price,
                CreatedDate = DateTime.Now,
            };

            _dbContext.Items.Add(item);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof (GetItem), new {id = item.Id}, item);
        }


        [HttpPut("{id}")]
        public ActionResult<Item> UpdateItem(Guid id, Item item)
        {
            
            //if (id != item.Id)
            //{
            //    return BadRequest();
            //}

            var existingItem = _dbContext.Items.Find(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = item.Name;
            existingItem.Price = item.Price;

            //_dbContext.Entry(item).State = EntityState.Modified;
            
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = _dbContext.Items.Find(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            _dbContext.Items.Remove(existingItem);
            _dbContext.SaveChanges();

            return NoContent();
        }

        private bool TodoItemExists(Guid id)
        {
            return _dbContext.Items.Any(e => e.Id == id);
        }

    }
}
