using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Models
{
    public class StockRequestModel
    {
        public string VariantCode { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}
