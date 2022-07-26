using System;
using System.Collections.Generic;

#nullable disable

namespace StockAPI.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ColorCode { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
