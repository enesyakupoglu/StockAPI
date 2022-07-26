using System;
using System.Collections.Generic;

#nullable disable

namespace StockAPI.Models
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public string VariantCode { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
