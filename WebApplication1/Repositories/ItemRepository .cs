using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly List<Item> _items = new List<Item>
        {
            new Item { Id = 1, Name = "Item1" },
            new Item { Id = 2, Name = "Item2" }
        };

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await Task.FromResult(_items);
        }
    }
}