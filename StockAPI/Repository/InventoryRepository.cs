using StockAPI.Data;
using StockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Repository
{
    public class InventoryRepository : IRepository<Inventory>
    {
        ApplicationDbContext _dbContext;
        public InventoryRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Inventory> Create(Inventory _object)
        {
            var obj = await _dbContext.Inventory.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public async Task<List<Inventory>> GetAllListAsync()
        {
            return  _dbContext.Inventory.ToList();
        }

        public Inventory GetById(int Id)
        {
            return _dbContext.Inventory.Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
