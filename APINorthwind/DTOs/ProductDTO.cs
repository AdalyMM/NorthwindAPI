﻿using APINorthwind.Models;

namespace APINorthwind.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }

        public string? QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public ulong Discontinued { get; set; }

        public virtual CategoryDTO? Category { get; set; }

        public virtual SupplierDTO Supplier { get; set; } = new SupplierDTO();
    }
}
