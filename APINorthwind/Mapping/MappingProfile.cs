using APINorthwind.DTOs;
using APINorthwind.Models;
using AutoMapper;

namespace APINorthwind.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

            CreateMap<OrderDetail, OrderDetailDTO>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                 .MaxDepth(1);

            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.Supplier))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .MaxDepth(1);

            CreateMap<Supplier, SupplierDTO>()
                .ForMember(dest => dest.Products, opt => opt.Ignore())
                .MaxDepth(1);

            CreateMap<Product, ProductsDTO>();
            CreateMap<Order, ReporteDTO>();
            CreateMap<OrderDetail, OrderDetailsDTO>();
            CreateMap<Supplier, SuppliersDTO>();
            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.Picture, opt => opt.Ignore())
                .ForMember(dest => dest.Products, opt => opt.Ignore());
            CreateMap<Shipper, ShipperDTO>()
               .ForMember(dest => dest.Orders, opt => opt.Ignore());
            CreateMap<Customer, CustomerDTO>()
               .ForMember(dest => dest.Orders, opt => opt.Ignore())
               .ForMember(dest => dest.CustomerTypes, opt => opt.Ignore());
            CreateMap<Employee, EmployeeDTO>()
               .ForMember(dest => dest.Photo, opt => opt.Ignore())
               .ForMember(dest => dest.InverseReportsToNavigation, opt => opt.Ignore())
               .ForMember(dest => dest.Orders, opt => opt.Ignore())
               .ForMember(dest => dest.ReportsToNavigation, opt => opt.Ignore())
               .ForMember(dest => dest.Territories, opt => opt.Ignore());
        }
    }
}
