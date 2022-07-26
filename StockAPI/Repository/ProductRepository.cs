using StockAPI.Data;
using StockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Product> Create(Product _object)
        {
            var obj = await _dbContext.Products.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public async Task<List<Product>> GetAllListAsync()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetById(int Id)
        {
            return _dbContext.Products.Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
