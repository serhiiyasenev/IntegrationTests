﻿using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
    }
}