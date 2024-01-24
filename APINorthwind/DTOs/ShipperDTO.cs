using APINorthwind.Models;

namespace APINorthwind.DTOs
{
    public class ShipperDTO
    {
        public int ShipperId { get; set; }

        public string CompanyName { get; set; } = null!;

        public string? Phone { get; set; }

        public virtual ICollection<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
    }
}
