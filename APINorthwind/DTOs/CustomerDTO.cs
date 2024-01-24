using APINorthwind.Models;

namespace APINorthwind.DTOs
{
    public class CustomerDTO
    {
        public string CustomerId { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string? ContactName { get; set; }

        public string? ContactTitle { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }

        public string? Fax { get; set; }

        public virtual ICollection<OrderDTO> Orders { get; set; } = new List<OrderDTO>();

        public virtual ICollection<Customerdemographic> CustomerTypes { get; set; } = new List<Customerdemographic>();
    }
}
