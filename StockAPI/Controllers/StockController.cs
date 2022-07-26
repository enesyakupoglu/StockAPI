using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockAPI.Models;
using StockAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Controllers
{
    [Route("api/[controller]")]
    public class BeymenStockController : ControllerBase
    {
        private readonly IRepository<Product> _product;
        private readonly IRepository<Inventory> _inventory;
        private readonly ILogger _logger;

        public BeymenStockController(IRepository<Product> product, IRepository<Inventory> inventory, ILogger<BeymenStockController> logger)
        {
            _product = product;
            _inventory = inventory;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> LoadStock(StockRequestModel stockRequestModel)
        {
            Inventory inventory = new Inventory
            {
                ProductCode = stockRequestModel.ProductCode,
                VariantCode = stockRequestModel.VariantCode,
                Quantity = stockRequestModel.Quantity,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var response = await _inventory.Create(inventory);

            _logger.LogInformation("LoadStock successfully." +
                " Id:" + response.Id +
                ", ProductCode:" + response.ProductCode +
                ", VariantCode:" + response.VariantCode +
                ", Quantity:" + response.Quantity +
                ", CreateDate:" + response.CreatedDate +
                ", UpdateDate:" + response.UpdatedDate
                 );

            return Ok();
        }

        [HttpGet("{variantCode}")]
        public async Task<IActionResult> GetStockByVariantCode(string variantCode)
        {
            var response = await _inventory.GetAllListAsync();
            var stock = response.Where(k => k.VariantCode == variantCode).ToList();

            if (stock == null)
            {
                _logger.LogInformation("Stock not found for VariantCode:" + variantCode);
                return Ok(variantCode + "Variant koda ait stok bulunamadı.");
            }

            _logger.LogInformation("GetStockByVariantCode successfully.Stock for variantcode:" + variantCode + " Quantity:" + stock.FirstOrDefault().Quantity);

            return Ok(stock);
        }

        [HttpGet("{productId}/products")]
        public async Task<IActionResult> GetStockByStoreCode(int productId)
        {
            var product = _product.GetById(productId);

            if (product == null)
            {
                _logger.LogInformation("Product not found for productId:" + productId);
                return NotFound("Ürün bulunamadı.");
            }

            var response = await _inventory.GetAllListAsync();
            var stock = response.Where(k => k.ProductCode == product.ProductCode).ToList();

            _logger.LogInformation("GetStockByVariantCode successfully.Stock for productId:" + productId + " Quantity:" + stock.FirstOrDefault().Quantity);

            return Ok(stock);
        }
    }
}
