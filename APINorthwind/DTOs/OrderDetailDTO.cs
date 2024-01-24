using APINorthwind.Models;

namespace APINorthwind.DTOs
{
    public class OrderDetailDTO
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public double Discount { get; set; }

        public virtual ProductDTO Product { get; set; } = new ProductDTO();
    }
}
